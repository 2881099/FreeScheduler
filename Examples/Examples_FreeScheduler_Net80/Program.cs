using FreeRedis;
using FreeScheduler;
using Newtonsoft.Json;

var fsql = new FreeSql.FreeSqlBuilder()
    .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=test1.db;Pooling=true")
    .UseAutoSyncStructure(true)
    .UseNoneCommandParameter(true)
    .UseMonitorCommand(cmd => Console.WriteLine(cmd.CommandText + "\r\n"))
    .Build();

var redis = new RedisClient("127.0.0.1,poolsize=10,exitAutoDisposePool=false");
redis.Serialize = obj => JsonConvert.SerializeObject(obj);
redis.Deserialize = (json, type) => JsonConvert.DeserializeObject(json, type);
redis.Notice += (s, e) =>
{
    if (e.Exception != null)
    Console.WriteLine(e.Log);
};

Scheduler scheduler = new FreeSchedulerBuilder()
    .OnExecuting(task =>
    {
        Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] {task.Topic} 被执行");
        task.Remark("log..");
    })
    .UseStorage(redis)
    .UseCluster(redis, new ClusterOptions
    {
        Name = Environment.GetCommandLineArgs().FirstOrDefault(a => a.StartsWith("--name="))?.Substring(7),
        HeartbeatInterval = 2,
        OfflineSeconds = 5,
    })
    .Build();
if (Datafeed.GetPage(scheduler).Total == 0)
{
    scheduler.AddTask("[系统预留]清理任务数据", "86400", -1, 3600);
    scheduler.AddTaskRunOnWeek("（周一）武林大会", "json", -1, "1:12:00:00");
    scheduler.AddTaskRunOnWeek("（周日）亲子活动", "json", -1, "0:00:00:00");
    scheduler.AddTaskRunOnWeek("（周六）社交活动", "json", -1, "6:00:00:00");
    scheduler.AddTaskRunOnMonth("月尾最后一天", "json", -1, "-1:16:00:00");
    scheduler.AddTaskRunOnMonth("月初第一天", "json", -1, "1:00:00:00");
    scheduler.AddTask("定时20秒", "json", 10, 20);
    scheduler.AddTask("测试任务1", "json", new[] { 10, 30, 60, 100, 150, 200 });
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(fsql);
builder.Services.AddSingleton(redis);
builder.Services.AddSingleton(scheduler);

var app = builder.Build();

var applicationLifeTime = app.Services.GetService<IHostApplicationLifetime>();
applicationLifeTime.ApplicationStopping.Register(() =>
{
    scheduler.Dispose();
    redis.Dispose();
    fsql.Dispose();
});

app.UseFreeSchedulerUI("/freescheduler/");

app.Run();
