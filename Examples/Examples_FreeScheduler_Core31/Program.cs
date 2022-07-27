using FreeScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Examples_FreeScheduler_Core31
{
    class Program
    {

        class MyTaskHandler : FreeScheduler.TaskHandlers.FreeSqlHandler
        {
            public MyTaskHandler(IFreeSql fsql) : base(fsql) { }

            public override void OnExecuting(Scheduler scheduler, TaskInfo task)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] {task.Topic} 被执行，还剩 {scheduler.QuantityTask} 个循环任务");
            }
        }

        static void Main(string[] args)
        {
            var fsql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, "data source=task.db;max pool size=5")
                .UseAutoSyncStructure(true)
                .UseNoneCommandParameter(true)
                .UseMonitorCommand(cmd => Console.WriteLine($"=========sql: {cmd.CommandText}\r\n"))
                .Build();

            Scheduler scheduler = new Scheduler(new MyTaskHandler(fsql));

            var dt = DateTime.Now;
            for (var a = 0; a < 2; a++)
            {
                //临时任务
                scheduler.AddTempTask(TimeSpan.FromSeconds(20), () =>
                {
                    Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] 20秒后被执行，还剩 {scheduler.QuantityTempTask} 个临时任务");
                });

                //循环任务，执行10次，每次间隔10秒
                scheduler.AddTask(topic: "test001", body: "data1", round: 10, seconds: 10);
                scheduler.AddTask(topic: "test002", body: "data2", round: -1, seconds: 10);
            }
            var dtts = DateTime.Now.Subtract(dt).TotalMilliseconds;
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] 注册耗时 {dtts}ms，共计 {scheduler.QuantityTempTask} 个临时任务，{scheduler.QuantityTask} 个循环任务");

            Console.ReadKey();

            dtts = DateTime.Now.Subtract(dt).TotalMilliseconds;
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] 耗时 {dtts}ms，还剩 {scheduler.QuantityTempTask} 个任务，{scheduler.QuantityTask} 个循环任务");
            scheduler.Dispose();
            fsql.Dispose();
        }
    }
}
