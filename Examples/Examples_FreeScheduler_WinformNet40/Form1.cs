using FreeScheduler;
using FreeRedis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Examples_FreeScheduler_WinformNet40
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static FreeScheduler.Scheduler _scheduler;
        static IFreeSql _fsql;
        static RedisClient _cli;
        static Form1()
        {
            _fsql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, "data source=:memory:")
                .UseAutoSyncStructure(true)
                .UseNoneCommandParameter(true)
                .UseMonitorCommand(cmd => Console.WriteLine($"=========sql: {cmd.CommandText}\r\n"))
                .Build();

            //_cli = new FreeRedis.RedisClient("127.0.0.1:6379");
            //_cli.Serialize = obj => JsonConvert.SerializeObject(obj);
            //_cli.Deserialize = (json, type) => JsonConvert.DeserializeObject(json, type);

            _scheduler = new FreeSchedulerBuilder()
                .OnExecuting(task =>
                {
                    Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss.fff")}] {task.Topic} 被执行，还剩 {_scheduler.QuantityTask} 个循环任务");

                    if (task.CurrentRound > 5)
                        task.Status = TaskStatus.Completed;
                })
                .UseCustomInterval(task =>
                {
                    return TimeSpan.FromSeconds(5);
                })
                .UseStorage(_fsql)
                .Build();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        string taskId = "";
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            if (string.IsNullOrEmpty(taskId))
                taskId = _scheduler.AddTask($"test_task_{DateTime.Now.ToString("g")}", $"test_task01_body{DateTime.Now.ToString("g")}", new[] { 20, 30, 30, 30, 50, 50, 50, 50, 110, 110 });
            else
                MessageBox.Show(_scheduler.ResumeTask(taskId).ToString());
            button1.Enabled = true;
            button8.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            MessageBox.Show(_scheduler.PauseTask(taskId).ToString());
            button2.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Console.WriteLine(_scheduler.RunNowTask(taskId).ToString());
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

        string tempTaskId = "";
        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            tempTaskId = _scheduler.AddTempTask(TimeSpan.FromSeconds(5), callback);
            button7.Enabled = true;

            void callback()
            {
                Console.WriteLine($"[{DateTime.Now.ToString("G")}] {tempTaskId} 到时触发");
                tempTaskId = _scheduler.AddTempTask(TimeSpan.FromSeconds(5), callback);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            MessageBox.Show(_scheduler.RemoveTempTask(tempTaskId).ToString());
            tempTaskId = "";
            button6.Enabled = true;
        }
    }
}
