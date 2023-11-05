using FreeRedis;
using FreeScheduler;
using FreeScheduler.TaskHandlers;
using System;

/// <summary>
/// Scheduler 对象构建器
/// </summary>
public class FreeSchedulerBuilder
{
    Action<TaskInfo> _executing;
    IFreeSql _fsql;
    RedisClient _redis;
    RedisClient _clusterRedis;
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
    /// 基于 数据库，使用 FreeSql ORM 持久化<para></para>
    /// UseFreeSql/UseFreeRedis 二选一
    /// </summary>
    public FreeSchedulerBuilder UseFreeSql(IFreeSql fsql)
    {
        if (_redis != null) throw new Exception("UseFreeSql/UseFreeRedis 二选一");
        _fsql = fsql;
        return this;
    }
    /// <summary>
    /// 基于 Redis，使用 FreeRedis 持久化<para></para>
    /// UseFreeSql/UseFreeRedis 二选一
    /// </summary>
    public FreeSchedulerBuilder UseFreeRedis(IRedisClient redis)
    {
        if (_fsql != null) throw new Exception("UseFreeSql/UseFreeRedis 二选一");
        _redis = redis as RedisClient;
        return this;
    }

    /// <summary>
    /// 开启集群（依赖 Redis）<para></para>
    /// 特点：<para></para>
    /// 1. 多进程，不重复触发任务<para></para>
    /// 2. 多进程，各自加载自己的任务，AddTask/ResumeTask/AddTempTask 本进程执行<para></para>
    /// 3. 支持跨进程执行 RemoveTask/ExistsTask/PauseTask/RunNowTask/RemoveTempTask/ExistsTempTask
    /// </summary>
    public FreeSchedulerBuilder UseCluster(IRedisClient redis)
    {
        _clusterRedis = redis as RedisClient;
        return this;
    }
    /// <summary>
    /// 自定义间隔（可实现 cron）
    /// </summary>
    /// <param name="nextDelay"></param>
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
        else taskHandler = new MemoryTaskHandler() { Executing = _executing };
        var scheduler = new Scheduler(taskHandler, _customIntervalHandler, 1);
        scheduler.ScanInterval = _scanInterval;
        if (_clusterRedis != null) scheduler._clusterContext = new ClusterContext(scheduler, _clusterRedis);
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
            Executing?.Invoke(task);
        }
    }
    class FreeRedisTaskHandler : FreeRedisHandler
    {
        public FreeRedisTaskHandler(RedisClient redis) : base(redis) { }
        public Action<TaskInfo> Executing;
        public override void OnExecuting(Scheduler scheduler, TaskInfo task)
        {
            Executing?.Invoke(task);
        }
    }
}
