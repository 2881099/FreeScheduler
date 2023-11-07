using FreeRedis;
using FreeScheduler;
using FreeSql;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;

var fsql = new FreeSql.FreeSqlBuilder()
    .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=test1.db;Pooling=true")
    .UseAutoSyncStructure(true)
    .UseNoneCommandParameter(true)
    //.UseMonitorCommand(cmd => Console.WriteLine(cmd.CommandText + "\r\n"))
    .Build();

var redis = new RedisClient("127.0.0.1,poolsize=10,exitAutoDisposePool=false");
redis.Serialize = obj => JsonConvert.SerializeObject(obj);
redis.Deserialize = (json, type) => JsonConvert.DeserializeObject(json, type);
//redis.Notice += (s, e) => Console.Write(e.Log);

Scheduler scheduler = new FreeSchedulerBuilder()
    .OnExecuting(task =>
    {
        Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] {task.Topic} ��ִ��");
    })
    .UseFreeSql(fsql)
    .UseCluster(redis, new ClusterOptions
    {
        Name = Environment.GetCommandLineArgs().FirstOrDefault(a => a.StartsWith("--name="))?.Substring(7),
        HeartbeatInterval = 2,
        OfflineSeconds = 5,
    })
    .Build();
if (fsql.Select<TaskInfo>().Any() == false)
{
    scheduler.AddTaskRunOnWeek("���ִ��", "json", -1, "1:20:00:00");
    scheduler.AddTask("��ʱ20��", "json", 10, 20);
    scheduler.AddTask("��������1", "json", new[] { 10, 30, 60, 100, 150, 200 });
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
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


app.UseAuthorization();
app.UseDefaultFiles().UseStaticFiles();
app.MapControllers();

app.Run();

