using FreeRedis;
using FreeScheduler;
using FreeScheduler.Login.Dashboard;
using FreeScheduler.Login.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

var fsql = new FreeSql.FreeSqlBuilder()
    .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=test1.db;Pooling=true")
    .UseAutoSyncStructure(true)
    .UseNoneCommandParameter(true)
    .UseMonitorCommand(cmd => Console.WriteLine(cmd.CommandText + "\r\n"))
    .Build();

var repo = fsql.GetRepository<RoleUserEntity>();
var user = fsql.GetRepository<User>();
user.InsertOrUpdate(new User { UserName = "admin", Pwd = "123456" });

repo.InsertOrUpdate(new RoleUserEntity { RoleId = 1, UserId = 1 });

repo = fsql.GetRepository<RoleUserEntity>();
repo.InsertOrUpdate(new RoleUserEntity { RoleId = 1, UserId = 1 });

var redis = new RedisClient("127.0.0.1,poolsize=10,exitAutoDisposePool=false");
redis.Serialize = obj => JsonConvert.SerializeObject(obj);
redis.Deserialize = (json, type) => JsonConvert.DeserializeObject(json, type);
redis.Notice += (s, e) =>
{
    if (e.Exception != null)
        Console.WriteLine(e.Log);
};
//redis.FlushDb();
Scheduler scheduler = new FreeSchedulerBuilder()
    .OnExecuting(task =>
    {
        Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] {task.Topic} ��ִ��");
        task.Remark("log..");
    })
    .UseTimeZone(TimeSpan.FromHours(8))
    .UseStorage(fsql)
    //.UseCluster(redis, new ClusterOptions
    //{
    //    Name = Environment.GetCommandLineArgs().FirstOrDefault(a => a.StartsWith("--name="))?.Substring(7),
    //    HeartbeatInterval = 2,
    //    OfflineSeconds = 5,
    //})
    .Build();
if (Datafeed.GetPage(scheduler).Total == 0)
{
    scheduler.AddTask("[ϵͳԤ��]������������", "86400", -1, 3600);
    scheduler.AddTaskRunOnWeek("����һ�����ִ��", "json", -1, "1:12:00:00");
    scheduler.AddTaskRunOnWeek("�����գ����ӻ", "json", -1, "0:00:00:00");
    scheduler.AddTaskRunOnWeek("���������罻�", "json", -1, "6:00:00:00");
    scheduler.AddTaskRunOnMonth("��β���һ��", "json", -1, "-1:16:00:00");
    scheduler.AddTaskRunOnMonth("�³���һ��", "json", -1, "1:00:00:00");
    scheduler.AddTask("��ʱ20��", "json", 10, 20);
    scheduler.AddTask("��������1", "json", new[] { 10, 30, 60, 100, 150, 200 });
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(fsql);
builder.Services.AddSingleton(redis);
builder.Services.AddSingleton(scheduler);
builder.Services.AddLogin();

var app = builder.Build();
var applicationLifeTime = app.Services.GetService<IHostApplicationLifetime>();
applicationLifeTime.ApplicationStopping.Register(() =>
{
    scheduler.Dispose();
    redis.Dispose();
    fsql.Dispose();
});

app.UseFreeSchedulerLoginUI("/freescheduler/");
app.UseFreeSchedulerUI("/freescheduler/");

app.Run();

public class RoleUserEntity
{
    [Key]
    public long RoleId { get; set; }
    [Key]
    public long UserId { get; set; }
}