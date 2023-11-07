using FreeRedis;
using System;
using System.Collections.Generic;

namespace FreeScheduler.TaskHandlers
{
    public class FreeRedisHandler : ITaskHandler
    {
        internal readonly RedisClient _redis;
        public FreeRedisHandler(RedisClient redis)
        {
            if (redis.Serialize == null || redis.Deserialize == null) throw new Exception("FreeRedis 必须设置了序列化/反序列化 cli.Serialize/Deserialize");
            _redis = redis;
        }

        public IEnumerable<TaskInfo> LoadAll(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 100;
            var taskScore = (decimal)DateTime.UtcNow.Subtract(_2020).TotalSeconds;
            var taskIds = _redis.ZRangeByScore($"FreeScheduler_zset_{TaskStatus.Running}", 0, taskScore, Math.Max(0, pageNumber - 1) * pageSize, pageSize);
            if (taskIds.Length == 0) return new TaskInfo[0];
            return _redis.HMGet<TaskInfo>("FreeScheduler_hset", taskIds);
        }
        public TaskInfo Load(string id)
        {
            return _redis.HGet<TaskInfo>("FreeScheduler_hset", id);
        }
        public void OnAdd(TaskInfo task)
        {
            var taskScore = (decimal)task.CreateTime.Subtract(_2020).TotalSeconds;
            using (var pipe = _redis.StartPipe())
            {
                pipe.HSet("FreeScheduler_hset", task.Id, task);
                pipe.ZAdd($"FreeScheduler_zset_all", taskScore, task.Id);
                pipe.ZAdd($"FreeScheduler_zset_{task.Status}", taskScore, task.Id);
                pipe.EndPipe();
            }
        }
        public void OnRemove(TaskInfo task)
        {
            using (var pipe = _redis.StartPipe())
            {
                pipe.HDel("FreeScheduler_hset", task.Id);
                pipe.ZRem($"FreeScheduler_zset_all", task.Id);
                pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Running}", task.Id);
                pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Paused}", task.Id);
                pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Completed}", task.Id);
                pipe.Del($"FreeScheduler_zset_log_{task.Id}");
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
                var resultMember = _redis.Serialize(result)?.ToString();
                using (var pipe = _redis.StartPipe())
                {
                    pipe.HSet("FreeScheduler_hset", task.Id, task);
                    if (status != t.Status)
                        pipe.ZRem($"FreeScheduler_zset_{status}", task.Id);
                    pipe.ZAdd($"FreeScheduler_zset_{t.Status}", taskScore, task.Id);
                    //pipe.ZAdd("FreeScheduler_zset_log", resultScore, resultMember);
                    pipe.ZAdd($"FreeScheduler_zset_log_{task.Id}", resultScore, resultMember);
                    //pipe.ZRemRangeByScore($"FreeScheduler_zset_log_{task.Id}", 0, resultScore - 86400 * 7);
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