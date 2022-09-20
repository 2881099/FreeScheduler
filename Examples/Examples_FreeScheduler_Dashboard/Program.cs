using FreeScheduler;
using FreeSql;

var fsql = new FreeSql.FreeSqlBuilder()
    .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=test.db;Pooling=true")
    .UseAutoSyncStructure(true)
    .UseNoneCommandParameter(true)
    .UseMonitorCommand(cmd => Console.WriteLine(cmd.CommandText + "\r\n"))
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(fsql);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 以下测试与 dashboard 无关
var scheduler = new Scheduler(new MyTaskHandler(fsql));
app.MapGet("/add", async ctx =>
{
    scheduler.AddTask("test_task", "{}", new int[] { 10, 15, 5, 3, 10 });
    await ctx.Response.WriteAsync("OK");
});

app.UseFreeAdminLtePreview("/",
    typeof(FreeScheduler.TaskInfo),
    typeof(FreeScheduler.TaskLog)
);

app.Run();


class MyTaskHandler : FreeScheduler.TaskHandlers.FreeSqlHandler
{
    public MyTaskHandler(IFreeSql fsql) : base(fsql) { }

    public override void OnExecuting(Scheduler scheduler, TaskInfo task)
    {
        if (task.Topic == "test_task")
        {
            //call test_task()
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] {task.Topic} 被执行");
        }

        //强制使任务完成
        //task.Status = TaskStatus.Completed;
    }
}