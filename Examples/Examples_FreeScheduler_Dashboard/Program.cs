using FreeRedis;
using FreeScheduler;
using FreeSql;
using Microsoft.Extensions.Hosting.Internal;
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
redis.Notice += (s, e) => Console.Write(e.Log);

Scheduler scheduler = null;
scheduler = new FreeSchedulerBuilder()
    .OnExecuting(task =>
    {
        Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] {task.Topic} ±»Ö´ÐÐ");
    })
    .UseFreeSql(fsql)
    .UseCluster(redis)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(fsql);
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

