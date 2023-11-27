using FreeRedis;
using FreeScheduler;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

//使用 FreeSql 持久化，以下两行必须执行（FreeRedis 无要求）
Enum.GetValues(typeof(TaskInterval));
Enum.GetValues(typeof(FreeScheduler.TaskStatus));

var fsql = new FreeSql.FreeSqlBuilder()
	//.UseConnectionString(FreeSql.DataType.MySql, $"Data Source=127.0.0.1;Port=3306;User ID=root;Password=root; Initial Catalog=cccddd;Charset=utf8; SslMode=none;Min pool size=1")
	.UseConnectionString(FreeSql.DataType.Sqlite, $"Data Source={AppContext.BaseDirectory}/test1.db;Pooling=true")
	//.UseConnectionString(FreeSql.DataType.PostgreSQL, "Host=192.168.164.10;Port=5432;Username=postgres;Password=123456;Database=toc;Pooling=true;Maximum Pool Size=2")
	//.UseNameConvert(FreeSql.Internal.NameConvertType.ToLower)
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
    //.UseCluster(redis, new ClusterOptions
    //{
    //    Name = Environment.GetCommandLineArgs().FirstOrDefault(a => a.StartsWith("--name="))?.Substring(7),
    //    HeartbeatInterval = 2,
    //    OfflineSeconds = 5,
    //})
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

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddSingleton(fsql);
builder.Services.AddSingleton(scheduler);
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();
var applicationLifeTime = app.Services.GetService<IHostApplicationLifetime>();
applicationLifeTime.ApplicationStopping.Register(() =>
{
    scheduler.Dispose();
    //redis.Dispose();
    fsql.Dispose();
});
app.UseFreeSchedulerUI("/freescheduler/");

var sampleTodos = new Todo[] {
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
