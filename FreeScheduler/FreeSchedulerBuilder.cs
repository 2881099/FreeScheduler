﻿using FreeRedis;
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
    /// - 支持 单项目，多站点部署<para></para>
    /// - 支持 多进程，不重复执行<para></para>
    /// - 支持 进程退出后，由其他进程重新加载任务（约30秒后）<para></para>
    /// - 支持 进程互通，任意进程都可以执行（RemoveTask/ExistsTask/PauseTask/RunNowTask/RemoveTempTask/ExistsTempTask）<para></para>
    /// - 支持 进程意外离线后，卸载进程内的任务，重新安排上线<para></para>
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
        else
        {
            if (_clusterRedis != null) throw new Exception($"UseCluster 集群功能仅支持 UseFreeSql/UseFreeRedis 持久化");
            taskHandler = new MemoryTaskHandler() { Executing = _executing };
        }
        var scheduler = new Scheduler(taskHandler, _customIntervalHandler, _clusterRedis != null ? new ClusterContext(_clusterRedis) : null);
        scheduler.ScanInterval = _scanInterval;
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