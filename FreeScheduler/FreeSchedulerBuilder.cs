using FreeRedis;
using FreeScheduler;
using FreeScheduler.TaskHandlers;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

/// <summary>
/// Scheduler 对象构建器
/// </summary>
public class FreeSchedulerBuilder
{
    Action<TaskInfo> _executing;
    Action<TaskInfo, TaskLog> _executed;
	IFreeSql _fsql;
    RedisClient _redis;
    RedisClient _clusterRedis;
    ClusterOptions _clusterOptions;
    ITaskIntervalCustomHandler _customIntervalHandler;
    TimeSpan _scanInterval = TimeSpan.FromMilliseconds(200);
    TimeSpan _timeOffset = TimeSpan.Zero;

    /// <summary>
    /// 任务触发
    /// </summary>
    /// <returns></returns>
    public FreeSchedulerBuilder OnExecuting(Action<TaskInfo> executing)
    {
        _executing = executing;
        return this;
    }
    /// <summary>
    /// 任务触发之后
    /// </summary>
    /// <returns></returns>
    public FreeSchedulerBuilder OnExecuted(Action<TaskInfo, TaskLog> executed)
    {
		_executed = executed;
        return this;
	}
    /// <summary>
    /// 设置时区（默认UTC时区）<para></para>
    /// 北京 -> TimeSpan.FromHours(8)
    /// </summary>
    /// <param name="timeOffset"></param>
    /// <returns></returns>
    public FreeSchedulerBuilder UseTimeZone(TimeSpan timeOffset)
    {
        _timeOffset = timeOffset;
        return this;
    }
    /// <summary>
    /// 基于 数据库，使用 FreeSql ORM 持久化
    /// </summary>
    public FreeSchedulerBuilder UseStorage(IFreeSql fsql)
    {
        _fsql = fsql;
        if (_fsql != null) _redis = null;
        return this;
    }
    /// <summary>
    /// 基于 Redis，使用 FreeRedis 持久化
    /// </summary>
    public FreeSchedulerBuilder UseStorage(IRedisClient redis)
    {
        var prefix = redis?.GetType().GetProperty("Prefix", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(redis, new object[0]) as string;
        if (string.IsNullOrWhiteSpace(prefix) == false) throw new Exception($"UseStorage 不支持设置了 Prefix 前辍的 FreeRedis");

        _redis = redis as RedisClient;
        if (_redis != null) _fsql = null;
        return this;
    }

    /// <summary>
    /// 开启集群（依赖 Redis）<para></para>
    /// 特点：<para></para>
    /// - 支持 单项目，多站点部署<para></para>
    /// - 支持 多进程，不重复执行<para></para>
    /// - 支持 进程退出后，由其他进程重新加载任务（约30秒后）<para></para>
    /// - 支持 进程互通，任意进程都可以执行（RemoveTask/ExistsTask/PauseTask/RunNowTask/RemoveTempTask/ExistsTempTask）<para></para>
    /// - 支持 进程意外离线后，卸载进程内的任务，重新安排上线<para></para>
    /// </summary>
    public FreeSchedulerBuilder UseCluster(IRedisClient redis, ClusterOptions options = null)
    {
        var prefix = redis?.GetType().GetProperty("Prefix", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(redis, new object[0]) as string;
        if (string.IsNullOrWhiteSpace(prefix) == false) throw new Exception($"由于 UseCluster 核心代码使用了较多 LuaScript，因此不支持设置 FreeRedis Prefix 前辍");

        _clusterRedis = redis as RedisClient;
        _clusterOptions = options;
        return this;
    }
    /// <summary>
    /// 自定义间隔（可实现 cron）
    /// </summary>
    /// <param name="nextDelay">获取下一次定时间隔，返回 null 时结束</param>
    /// <returns></returns>
    public FreeSchedulerBuilder UseCustomInterval(Func<TaskInfo, TimeSpan?> nextDelay)
    {
        if (nextDelay == null) throw new Exception($"参数 {nameof(nextDelay)} 不能为 null");
        _customIntervalHandler = new CustomIntervalHandler { NextDelay = nextDelay };
        return this;
    }
    /// <summary>
    /// 扫描线程间隔（默认值：200毫秒）
    /// </summary>
    public FreeSchedulerBuilder UseScanInterval(TimeSpan value)
    {
        _scanInterval = value;
        return this;
    }
    public Scheduler Build()
    {
        ITaskHandler taskHandler = null;
        if (_fsql != null) taskHandler = new FreeSqlTaskHandler(_fsql) { Executing = _executing, Executed = _executed };
        else if (_redis != null) taskHandler = new FreeRedisTaskHandler(_redis) { Executing = _executing, Executed = _executed };
        else
        {
            if (_clusterRedis != null) throw new Exception($"UseCluster 集群功能仅支持 UseStorage 持久化");
            taskHandler = new MemoryTaskHandler() { Executing = _executing, Executed = _executed };
        }
        var scheduler = new Scheduler(taskHandler, _customIntervalHandler, 
            _clusterRedis != null ? new ClusterContext(_clusterRedis, _clusterOptions) : null,
            _timeOffset);
        scheduler.ScanInterval = _scanInterval;
        if (_clusterRedis != null)
            Snowfake.Default = new Snowfake(_clusterRedis.Incr($"{scheduler.ClusterOptions.RedisPrefix}_Snowfake") % 16);

        return scheduler;
    }


    class CustomIntervalHandler : ITaskIntervalCustomHandler
    {
        public Func<TaskInfo, TimeSpan?> NextDelay;
        TimeSpan? ITaskIntervalCustomHandler.NextDelay(TaskInfo task) => NextDelay?.Invoke(task);
    }
    class MemoryTaskHandler : TestHandler
    {
        public Action<TaskInfo> Executing;
		public Action<TaskInfo, TaskLog> Executed;
		public override void OnExecuting(Scheduler scheduler, TaskInfo task)
		{
			FreeSqlTaskHandler.SystemExecuting(scheduler, task);
			Executing?.Invoke(task);
		}
		public override void OnExecutedExt(TaskInfo task, TaskLog result)
		{
			Executed?.Invoke(task, result);
		}
	}
    class FreeSqlTaskHandler : FreeSqlHandler
    {
        public FreeSqlTaskHandler(IFreeSql fsql) : base(fsql) { }
        public Action<TaskInfo> Executing;
		public Action<TaskInfo, TaskLog> Executed;

		public override void OnExecuting(Scheduler scheduler, TaskInfo task)
        {
            SystemExecuting(scheduler, task);
			Executing?.Invoke(task);
		}
		public override void OnExecutedExt(TaskInfo task, TaskLog result)
		{
			Executed?.Invoke(task, result);
		}

		internal static void SystemExecuting(Scheduler scheduler, TaskInfo task)
        {
			switch (task.Topic)
			{
				case "[系统预留]清理任务数据":
					var affrows = Datafeed.CleanStorageData(scheduler, (int)uint.Parse(task.Body) + 1);
					task.Remark($"已清理 {affrows} 条数据");
					break;
			}
            if (task.Topic?.StartsWith("[系统预留]Http请求") == true)
            {
                var httpArgs = JToken.Parse(task.Body);
                using (var http = new TcpClientHttpRequest())
                {
                    http.Timeout = 1000 * (int.TryParse(httpArgs["timeout"]?.ToString() ?? "30", out var tryint) ? tryint : 30);
                    http.Method = httpArgs["method"]?.ToString();
                    http.Action = httpArgs["url"]?.ToString();
                    if (httpArgs["header"]?.Type == JTokenType.Object)
                    {
                        foreach (var head in ((JObject)httpArgs["header"]).Properties())
                            http.Headers[head.Name] = head.Value?.ToString();
                    }
                    http.Send(httpArgs["body"]?.ToString());
                    if (http.Response.ContentType.Contains("text/json") || 
                        http.Response.ContentType.Contains("application/json") ||
                        http.ContentType.Contains("application/json")) task.Remark(http.Response.StatusCode.ToString() + " " + http.Response.Xml);
                    else task.Remark(http.Response.StatusCode.ToString());
                }
            }
		}
    }
    class FreeRedisTaskHandler : FreeRedisHandler
    {
        public FreeRedisTaskHandler(RedisClient redis) : base(redis) { }
        public Action<TaskInfo> Executing;
        public Action<TaskInfo, TaskLog> Executed;

		public override void OnExecuting(Scheduler scheduler, TaskInfo task)
        {
			FreeSqlTaskHandler.SystemExecuting(scheduler, task);
			Executing?.Invoke(task);
        }
		public override void OnExecutedExt(TaskInfo task, TaskLog result)
		{
            Executed?.Invoke(task, result);
		}
	}
}
