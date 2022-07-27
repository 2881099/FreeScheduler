using Quartz;
using Quartz.Impl;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Examples_vs_quartz
{
    class Program
    {
        static void Main(string[] args)
        {
            //QuartzSchedulerRun().Wait();

            FluentSchedulerRun();

            //HashedWheelTimerRun();

            //FreeSchedulerRun();

            Console.ReadKey();
        }

        static FreeScheduler.Scheduler _FreeScheduler;
        static DateTime FreeSchedulerRunStartTime;
        static long FreeSchedulerRunTimes;
        static void FreeSchedulerRun()
        {
            _FreeScheduler = new FreeScheduler.Scheduler(new FreeScheduler.TaskHandlers.TestHandler());
            FreeSchedulerRunStartTime = DateTime.Now;
            FreeSchedulerRunTimes = 0;
            for (var a = 0; a < 50_0000; a++)
            {
                _FreeScheduler.AddTempTask(TimeSpan.FromSeconds(10), () =>
                {
                    Console.Out.WriteLine("Hello QuartzNet...");
                    if (Interlocked.Increment(ref Program.FreeSchedulerRunTimes) == 50_0000)
                    {
                        Console.Out.WriteLine($"FreeScheduler 执行 50w 个任务，耗时：{DateTime.Now.Subtract(Program.FreeSchedulerRunStartTime).TotalMilliseconds}ms");
                        _FreeScheduler.Dispose();
                    }
                });
                //_FreeScheduler.AddTask($"ajob{a}", $"group{a}", 1, 10);
            }

            Console.Out.WriteLine("OK   Hello QuartzNet...");
        }

        #region Quartz
        static ISchedulerFactory _quartzfactory;
        static IScheduler _quartzScheduler; 
        static DateTime QuartzSchedulerRunStartTime;
        static long QuartzSchedulerRunTimes;
        static async Task QuartzSchedulerRun()
        {
            // 创建作业调度池
            _quartzfactory = new StdSchedulerFactory();
            _quartzScheduler = await _quartzfactory.GetScheduler();
            QuartzSchedulerRunStartTime = DateTime.Now;
            QuartzSchedulerRunTimes = 0;
            for (var a = 0; a < 50_0000; a++)
            {
                // 创建作业
                IJobDetail job = JobBuilder.Create<HelloJob>()
                  .WithIdentity($"ajob{a}", $"group{a}")
                  .Build();

                // 创建触发器，每10s执行一次
                ITrigger trigger = TriggerBuilder.Create()
                  .WithIdentity($"atrigger{a}", $"group{a}")
                  .StartAt(DateTime.UtcNow.AddSeconds(10))
                  .Build();

                // 加入到作业调度池中
                await _quartzScheduler.ScheduleJob(job, trigger);
            }

            // 开始运行
            await _quartzScheduler.Start();
        }
        public class HelloJob : IJob
        {
            /// <summary>
            /// 作业调度定时执行的方法
            /// </summary>
            /// <param name="context"></param>
            /// <returns></returns>
            async public Task Execute(IJobExecutionContext context)
            {
                await Console.Out.WriteLineAsync("Hello QuartzNet...");
                if (Interlocked.Increment(ref Program.QuartzSchedulerRunTimes) == 50_0000)
                {
                    Console.Out.WriteLine($"Quartz 执行 50w 个任务，耗时：{DateTime.Now.Subtract(Program.QuartzSchedulerRunStartTime).TotalMilliseconds}ms");
                    await _quartzScheduler.Clear();
                }
            }
        }
        #endregion

        #region FluentScheduler
        static void FluentSchedulerRun()
        {
            for (var a = 0; a < 50_0000; a++)
            {
                var registry = new FluentScheduler.Registry();
                registry.Schedule<MyOtherJob>().WithName($"ajob{a}").ToRunOnceIn(10).Seconds();
                FluentScheduler.JobManager.Initialize(registry);
            }
        }
        public class MyOtherJob : FluentScheduler.IJob
        {
            public void Execute()
            {
                Console.Out.WriteLine("Hello QuartzNet...");
            }
        }
        #endregion

        #region HashedWheelTimer
        static HWT.HashedWheelTimer timer = new HWT.HashedWheelTimer(tickDuration: TimeSpan.FromSeconds(1)
                , ticksPerWheel: 100000
                , maxPendingTimeouts: 0);
        static DateTime HashedWheelTimerRunStartTime;
        static long HashedWheelTimerRunTimes;
        static void HashedWheelTimerRun()
        {
            HashedWheelTimerRunStartTime = DateTime.Now;
            HashedWheelTimerRunTimes = 0;
            for (var a = 0; a < 50_0000; a++)
            {
                timer.NewTimeout(new HwtOneTimeTask(), TimeSpan.FromSeconds(10));
            }
        }
        class HwtOneTimeTask : HWT.TimerTask
        {
            public void Run(HWT.Timeout timeout)
            {
                Console.Out.WriteLine("Hello QuartzNet...");
                if (Interlocked.Increment(ref Program.HashedWheelTimerRunTimes) == 50_0000)
                {
                    Console.Out.WriteLine($"HashedWheelTimer 执行 50w 个任务，耗时：{DateTime.Now.Subtract(Program.HashedWheelTimerRunStartTime).TotalMilliseconds}ms");
                    timer.Stop();
                }
            }
        }
        #endregion
    }
}
