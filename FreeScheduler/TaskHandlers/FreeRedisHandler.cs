using FreeRedis;
using System;
using System.Collections.Generic;
using System.Linq;

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
				pipe.ZAdd($"FreeScheduler_zset_q:{task.Topic}_all", taskScore, task.Id);
				pipe.ZAdd($"FreeScheduler_zset_q:{task.Topic}_{task.Status}", taskScore, task.Id);
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

				pipe.ZRem($"FreeScheduler_zset_q:{task.Topic}_all", task.Id);
				pipe.ZRem($"FreeScheduler_zset_q:{task.Topic}_{TaskStatus.Running}", task.Id);
				pipe.ZRem($"FreeScheduler_zset_q:{task.Topic}_{TaskStatus.Paused}", task.Id);
				pipe.ZRem($"FreeScheduler_zset_q:{task.Topic}_{TaskStatus.Completed}", task.Id);

				pipe.Del($"FreeScheduler_zset_log:{task.Id}");
                foreach (var scan in _redis.ZScan($"FreeScheduler_zset_log:{task.Id}", "*", 100))
                    if (scan.Length > 0)
                        pipe.ZRem("FreeScheduler_zset_log_all", scan.Select(a => a.member).ToArray());
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
                    {
                        pipe.ZRem($"FreeScheduler_zset_{status}", task.Id);
						pipe.ZRem($"FreeScheduler_zset_q:{task.Topic}_{status}", task.Id);
					}
                    pipe.ZAdd($"FreeScheduler_zset_{t.Status}", taskScore, task.Id);
					pipe.ZAdd($"FreeScheduler_zset_q:{task.Topic}_{t.Status}", taskScore, task.Id);

					pipe.ZAdd($"FreeScheduler_zset_log:{task.Id}", resultScore, resultMember);
					pipe.ZAdd("FreeScheduler_zset_log_all", resultScore, resultMember);
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