using FreeScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Examples_FreeScheduler_WinformNet40
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class MyTaskHandler : FreeScheduler.TaskHandlers.FreeSqlHandler
        {
            public MyTaskHandler(IFreeSql fsql) : base(fsql) { }

            public override void OnExecuting(Scheduler scheduler, TaskInfo task)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] {task.Topic} 被执行，还剩 {scheduler.QuantityTask} 个循环任务");

                if (task.CurrentRound > 5)
                    task.Status = TaskStatus.Completed;
            }
        }
        class MyCustomTaskHandler : FreeScheduler.ITaskIntervalCustomHandler
        {
            public TimeSpan? NextDelay(TaskInfo task)
            {
                return TimeSpan.FromSeconds(5);
            }
        }
        static FreeScheduler.Scheduler _scheduler;
        static IFreeSql _fsql;
        static Form1()
        {

            _fsql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, "data source=test.db;max pool size=5")
                .UseAutoSyncStructure(true)
                .UseNoneCommandParameter(true)
                .UseMonitorCommand(cmd => Console.WriteLine($"=========sql: {cmd.CommandText}\r\n"))
                .Build();
            _scheduler = new Scheduler(new MyTaskHandler(_fsql), new MyCustomTaskHandler());
        }

        string taskId = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            if (string.IsNullOrEmpty(taskId))
                taskId = _scheduler.AddTask($"test_task_{DateTime.Now.ToString("g")}", $"test_task01_body{DateTime.Now.ToString("g")}", new[] { 3, 3, 3, 3, 5, 5, 5, 5, 10, 10 });
            else
                MessageBox.Show(_scheduler.ResumeTask(taskId).ToString());
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            MessageBox.Show(_scheduler.PauseTask(taskId).ToString());
            button2.Enabled = true;
        }

        string customTaskId = "";
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;

            if (string.IsNullOrEmpty(customTaskId))
                customTaskId = _scheduler.AddTaskCustom($"test_customtask_{DateTime.Now.ToString("g")}", $"test_customtask01_body{DateTime.Now.ToString("g")}", "cron exp");
            else
                MessageBox.Show(_scheduler.ResumeTask(customTaskId).ToString());
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            MessageBox.Show(_scheduler.PauseTask(customTaskId).ToString());
            button3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _scheduler.AddTask($"test_-1_task_{DateTime.Now.ToString("g")}", $"test_-1_body{DateTime.Now.ToString("g")}", -1, 5);
        }
    }
}
