using FreeRedis;
using FreeScheduler;
using FreeScheduler.TaskHandlers;
using System;
using System.Reflection;

/// <summary>
/// Scheduler 对象构建器
/// </summary>
public class FreeSchedulerBuilder
{
    Action<TaskInfo> _executing;
    IFreeSql _fsql;
    RedisClient _redis;
    RedisClient _clusterRedis;
    ClusterOptions _clusterOptions;
    ITaskIntervalCustomHandler _customIntervalHandler;
    TimeSpan _scanInterval = TimeSpan.FromMilliseconds(200);

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
        if (string.IsNullOrEmpty(prefix) == false) throw new Exception($"UseStorage 不支持设置了 Prefix 前辍的 FreeRedis");

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
        if (string.IsNullOrEmpty(prefix) == false) throw new Exception($"由于 UseCluster 核心代码使用了较多 LuaScript，因此不支持设置 FreeRedis Prefix 前辍");

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
        if (_fsql != null) taskHandler = new FreeSqlTaskHandler(_fsql) { Executing = _executing };
        else if (_redis != null) taskHandler = new FreeRedisTaskHandler(_redis) { Executing = _executing };
        else
        {
            if (_clusterRedis != null) throw new Exception($"UseCluster 集群功能仅支持 UseStorage 持久化");
            taskHandler = new MemoryTaskHandler() { Executing = _executing };
        }
        var scheduler = new Scheduler(taskHandler, _customIntervalHandler, _clusterRedis != null ? new ClusterContext(_clusterRedis, _clusterOptions) : null);
        scheduler.ScanInterval = _scanInterval;
        if (_clusterRedis != null)
            Snowfake.Default = new Snowfake(_clusterRedis.Incr($"{scheduler.ClusterOptions.RedisPrefix}_Snowfake"));

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
        public override void OnExecuting(Scheduler scheduler, TaskInfo task)
        {
            Executing?.Invoke(task);
        }
    }
    class FreeSqlTaskHandler : FreeSqlHandler
    {
        public FreeSqlTaskHandler(IFreeSql fsql) : base(fsql) { }
        public Action<TaskInfo> Executing;

        public override void OnExecuting(Scheduler scheduler, TaskInfo task)
        {
            if (task.Topic == "[系统预留]清理任务数据")
            {
                var affrows = Datafeed.CleanStorageData(scheduler, (int)uint.Parse(task.Body) + 1);
                task.Remark($"已清理 {affrows} 条数据");
            }
            Executing?.Invoke(task);
        }
    }
    class FreeRedisTaskHandler : FreeRedisHandler
    {
        public FreeRedisTaskHandler(RedisClient redis) : base(redis) { }
        public Action<TaskInfo> Executing;

        public override void OnExecuting(Scheduler scheduler, TaskInfo task)
        {
            if (task.Topic == "[系统预留]清理任务数据")
            {
                var affrows = Datafeed.CleanStorageData(scheduler, (int)uint.Parse(task.Body) + 1);
                task.Remark($"已清理 {affrows} 条数据");
            }
            Executing?.Invoke(task);
        }
    }
}
