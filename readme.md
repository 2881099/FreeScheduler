FreeScheduler 是利用 IdleBus 实现的轻量化定时任务调度，支持临时的延时任务和重复循环任务(可持久化)，可按秒，每天/每周/每月固定时间，自定义间隔执行，支持 .NET Core 2.1+、.NET Framework 4.0+ 运行环境。

> IdleScheduler 已正式改名为 FreeScheduler

## Quick start

> dotnet add package FreeSchduler

```c#
static Lazy<Scheduler> _schedulerLazy = new Lazy(() => new Scheduler(new MyTaskHandler()));
static Scheduler scheduler => _schedulerLazy.Value;
```

1、普通任务

```c#
class MyTaskHandler : FreeScheduler.TaskHandlers.TestHandler
{
    public override void OnExecuting(Scheduler scheduler, TaskInfo task)
    {
        //todo..
    }
}
```

2、持久化任务

```c#
// 使用 FreeSql 持久化任务
class MyTaskHandler : FreeScheduler.TaskHandlers.FreeSqlHandler
{
    public MyTaskHandler(IFreeSql fsql) : base(fsql) { }

    public override void OnExecuting(Scheduler scheduler, TaskInfo task)
    {
        Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] {task.Topic} 被执行");

        //强制使任务完成
        //task.Status = TaskStatus.Completed;
    }
}
```

## API (循环任务/可持久化)

| Method | 说明 |
| -- | -- |
| void ctor(ITaskHandler) | 指定任务调度器（单例） |
| string AddTask(string topic, string body, int round, int seconds) | 创建循环定时任务，返回 id |
| string AddTask(string topic, string body, int[] seconds) | 创建每轮间隔不同的定时任务，返回 id |
| string AddTaskRunOnDay(..) | 创建每日循环任务，返回 id |
| string AddTaskRunOnWeek(..) | 创建每周循环任务，返回 id |
| string AddTaskRunOnMonth(..) | 创建每月循环任务，返回 id |
| string AddTaskCustom(string topic, string body, string expression) | 创建自定义任务，返回 id |
| bool RemoveTask(string id) | 删除任务 |
| bool ExistsTask(string id) | 判断任务是否存在 |
| bool ResumeTask(string id) | 恢复已暂停的任务 |
| bool PauseTask(string id) | 暂停正在运行的任务 |
| TaskInfo[] FindTask(lambda) | 查询正在运行中的任务 |
| int QuantityTask | 任务数量 |

```c#
//每5秒触发，执行N次
var id = scheduler.AddTask("topic1", "body1", round: -1, 5);

//每次 不同的间隔秒数触发，执行6次
var id = scheduler.AddTask("topic1", "body1", new [] { 5, 5, 10, 10, 60, 60 });

//每天 20:00:00 触发，执行N次
var id = scheduler.AddTaskRunOnDay("topic1", "body1", round: -1, "20:00:00");

//每周一 20:00:00 触发，执行1次
var id = scheduler.AddTaskRunOnDay("topic1", "body1", round: 1, "1:20:00:00");

//每月1日 20:00:00 触发，执行12次
var id = scheduler.AddTaskRunOnDay("topic1", "body1", round: 12, "1:20:00:00");

//自定义间隔
var id = scheduler.AddTaskCustom("topic1", "body1", "0/1 * * * * ? ");
class MyCustomTaskHandler : FreeScheduler.ITaskIntervalCustomHandler
{
    public TimeSpan? NextDelay(TaskInfo task)
    {
        //利用 cron 功能库解析 task.IntervalArgument 得到下一次执行时间
        //与当前时间相减，得到 TimeSpan，若返回 null 则任务完成
        return TimeSpan.FromSeconds(5);
    }
}
```

## API (临时任务)

| Method | 说明 |
| -- | -- |
| string AddTempTask(TimeSpan, Action) | 创建临时的延时任务，返回 id |
| bool RemoveTempTask(string id) | 删除任务(临时任务) |
| bool ExistsTempTask(string id) | 判断任务是否存在(临时任务) |
| int QuantityTempTask | 任务数量(临时任务) |

## Performance

| FreeScheduler | Quartz.net | FluentScheduler | HashedWheelTimer |
| -- | -- | -- | -- |
| (500,000 Tasks + 10s) | (500,000 Tasks + 10s) | (500,000 Tasks + 10s) | (500,000 Tasks + 10s) |
| <img src="https://github.com/2881099/FreeScheduler/blob/master/Examples/Examples_FreeScheduler_VsQuartz/performance_self.png?raw=true"/> | <img src="https://github.com/2881099/FreeScheduler/blob/master/Examples/Examples_FreeScheduler_VsQuartz/performance_quartz.png?raw=true"/> | <img src="https://github.com/2881099/FreeScheduler/blob/master/Examples/Examples_FreeScheduler_VsQuartz/performance_fluentscheduler.png?raw=true"/> | <img src="https://github.com/2881099/FreeScheduler/blob/master/Examples/Examples_FreeScheduler_VsQuartz/performance_hashedwheeltimer.png?raw=true"/> |
| 383M | 1700+M | StackOverflow | 213M |
| 70563.6066ms | 50692.5365ms | 未知 | 33697.8758ms |

> FluentScheduler 单个 Registry 测试正常，但目测单线程执行(间隔1-10ms)，处理速度不理想 [View Code](https://github.com/2881099/FreeScheduler/blob/master/Examples/Examples_FreeScheduler_VsQuartz/Program.cs)

> 我尝试把 FreeScheduler 内核改成 HashedWheelTimer 内存占用更高(600兆)，结论：FreeScheduler 功能需要占用更多资源

