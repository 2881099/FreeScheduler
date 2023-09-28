using FreeRedis;
using System;
using System.Collections.Generic;

namespace FreeScheduler.TaskHandlers
{
    public class FreeRedisHandler : ITaskHandler
    {
        readonly RedisClient _cli;
        public FreeRedisHandler(RedisClient cli)
        {
            if (cli.Serialize == null || cli.Deserialize == null) throw new Exception("FreeRedis 必须设置了序列化/反序列化 cli.Serialize/Deserialize");
            _cli = cli;
        }

        public IEnumerable<TaskInfo> LoadAll()
        {
            var taskIds = _cli.ZRange($"FreeScheduler_zset_{TaskStatus.Running}", 0, -1);
            if (taskIds.Length == 0) return new TaskInfo[0];
            return _cli.HMGet<TaskInfo>("FreeScheduler_hset", taskIds);
        }
        public TaskInfo Load(string id)
        {
            return _cli.HGet<TaskInfo>("FreeScheduler_hset", id);
        }
        public void OnAdd(TaskInfo task)
        {
            var taskScore = (decimal)task.CreateTime.Subtract(_2020).TotalSeconds;
            using (var pipe = _cli.StartPipe())
            {
                pipe.HSet("FreeScheduler_hset", task.Id, task);
                pipe.ZAdd($"FreeScheduler_zset_{task.Status}", taskScore, task.Id);
                pipe.EndPipe();
            }
        }
        public void OnRemove(TaskInfo task)
        {
            using (var pipe = _cli.StartPipe())
            {
                pipe.HDel("FreeScheduler_hset", task.Id);
                pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Running}", task.Id);
                pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Paused}", task.Id);
                pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Completed}", task.Id);
                pipe.HDel($"FreeScheduler_zset_log_{task.Id}");
                pipe.EndPipe();
            }
        }
        public void OnExecuted(Scheduler scheduler, TaskInfo task, TaskLog result)
        {
            try
            {

                var t = Load(task.Id);
                var status = t.Status;
                t.CurrentRound = task.CurrentRound;
                t.ErrorTimes = task.ErrorTimes;
                t.LastRunTime = task.LastRunTime;
                t.Status = task.Status;
                var taskScore = (decimal)task.CreateTime.Subtract(_2020).TotalSeconds;
                var resultScore = (decimal)result.CreateTime.Subtract(_2020).TotalSeconds;
                var resultMember = _cli.Serialize(result)?.ToString();
                using (var pipe = _cli.StartPipe())
                {
                    pipe.HSet("FreeScheduler_hset", task.Id, task);
                    if (status != t.Status)
                        pipe.ZRem($"FreeScheduler_zset_{status}", task.Id);
                    pipe.ZAdd($"FreeScheduler_zset_{t.Status}", taskScore, task.Id);
                    //pipe.ZAdd("FreeScheduler_zset_log", resultScore, resultMember);
                    pipe.ZAdd($"FreeScheduler_zset_log_{task.Id}", resultScore, resultMember);
                    pipe.EndPipe();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {task.Topic} FreeRedisHandler.OnExecuted 错误：{ex.Message}");
            }
}
        readonly DateTime _2020 = new DateTime(2020, 1, 1);

        public virtual void OnExecuting(Scheduler scheduler, TaskInfo task)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {task.Topic} 被执行，还剩 {scheduler.QuantityTask} 个循环任务");
        }
    }
}