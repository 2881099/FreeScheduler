using FreeRedis;
using FreeScheduler.TaskHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeScheduler
{
    public static class Datafeed
	{
        public class ResultGetPage
        {
            public int Total { get; set; }
            public List<TaskInfo> Tasks { get; set; }
            public ClusterInfo[] Clusters { get; set; }

            public class ClusterInfo
            {
                public string Id { get; set; }
                public int Heartbeat { get; set; }
                public string Name { get; set; }
                public int TaskCount { get; set; }
            }
        }
        public static ResultGetPage GetPage(Scheduler scheduler, string clusterId, TaskStatus? status, int limit = 20, int page = 1)
		{
            var result = new ResultGetPage();
            var clusterRedis = scheduler._clusterContext._redis;
            var clusters = scheduler.ClusterId == null ? new ZMember[0] : clusterRedis.ZRangeByScoreWithScores("freescheduler_cluster", "-inf", "+inf");
            if (clusters.Any())
            {
                var clusterTasks = new int[clusters.Length];
                var clusterNames = new string[clusters.Length];
                using (var pipe = clusterRedis.StartPipe())
                {
                    foreach (var cluster in clusters) pipe.ZCard($"freescheduler_cluster_register_{cluster.member}");
                    foreach (var cluster in clusters) pipe.HGet($"freescheduler_cluster_name", cluster.member);
                    var ret = pipe.EndPipe();
                    for (var a = 0; a < clusters.Length; a++)
                        clusterTasks[a] = int.TryParse(ret[a]?.ToString() ?? "0", out var tryint) ? tryint : 0;
                    for (var a = 0; a < clusters.Length; a++)
                    {
                        clusterNames[a] = ret[clusters.Length + a]?.ToString();
                        if (string.IsNullOrWhiteSpace(clusterNames[a])) clusterNames[a] = clusters[a].member;
                    }
                }
                result.Clusters = clusters.Select((a, index) => new ResultGetPage.ClusterInfo { Id = a.member, Heartbeat = (int)a.score, TaskCount = clusterTasks[index], Name = clusterNames[index] })
                    .OrderByDescending(a => a.Id == scheduler.ClusterId ? int.MaxValue : a.TaskCount)
                    .ThenBy(a => a.Id).ToArray();
            }
            if (clusters.Any(a => a.member == clusterId))
            {
                var taskIds = clusterRedis.ZRevRangeByLex($"freescheduler_cluster_register_{clusterId}", "+", "-", Math.Max(0, page - 1) * limit, limit);
                taskIds = taskIds.Where(a => a.StartsWith("AddTask:")).Select(a => a.Substring(8)).ToArray();
                if (taskIds.Any())
                {
                    if (scheduler._taskHandler is FreeSqlHandler fsqlHandler)
                    {
                        result.Tasks = fsqlHandler._fsql.Select<TaskInfo>()
                            .WhereIf(status != null, a => a.Status == status)
                            .Where(a => taskIds.Contains(a.Id))
                            .OrderByDescending(a => a.Id)
                            .ToList();
                    }
                    else if (scheduler._taskHandler is FreeRedisHandler redisHandler)
                    {
                        result.Tasks = redisHandler._redis.HMGet<TaskInfo>("FreeScheduler_hset", taskIds)
                            .Where(a => status == null || a.Status == status)
                            .ToList();
                    }
                }
                else
                    result.Tasks = new List<TaskInfo>();
                result.Total = result.Clusters.Where((a, index) => a.Id == clusterId).Select(a => a.TaskCount).FirstOrDefault();
            }
            else
            {
                if (scheduler._taskHandler is FreeSqlHandler fsqlHandler)
                {
                    result.Tasks = fsqlHandler._fsql.Select<TaskInfo>()
                        .WhereIf(status != null, a => a.Status == status)
                        .Count(out var total)
                        .Page(page, limit)
                        .OrderByDescending(a => a.Id)
                        .ToList();
                    result.Total = (int)total;
                }
                else if (scheduler._taskHandler is FreeRedisHandler redisHandler)
                {
                    var zkey = status == null ? "FreeScheduler_zset_all" : $"FreeScheduler_zset_{status}";
                    var taskIds = redisHandler._redis.ZRevRangeByScore(zkey, "+inf", "-inf", Math.Max(0, page - 1) * limit, limit);
                    result.Tasks = taskIds.Any() ? redisHandler._redis.HMGet<TaskInfo>("FreeScheduler_hset", taskIds).ToList() : new List<TaskInfo>();
                    result.Total = (int)redisHandler._redis.ZCard(zkey);
                }
                else if (scheduler._taskHandler is TestHandler testHandler)
                {
                    var queryTasks = scheduler._tasks.Values.Where(a => status == null || a.Status == status.Value);
                    result.Total = queryTasks.Count();
                    result.Tasks = queryTasks.OrderByDescending(a => a.Id).Skip(Math.Max(0, page - 1) * limit).Take(limit).ToList();
                }
            }
            return result;
        }
        public static string AddTask(Scheduler scheduler, string topic, string body, int round, TaskInterval interval, string argument)
        {
            string taskId = null;
            switch (interval)
            {
                case TaskInterval.SEC:
                    var secs = argument.Split(',').Select(a => int.Parse(a.Trim())).ToArray();
                    if (secs.Length > 1) taskId = scheduler.AddTask(topic, body, secs);
                    else taskId = scheduler.AddTask(topic, body, round, secs[0]);
                    break;
                case TaskInterval.RunOnDay:
                    taskId = scheduler.AddTaskRunOnDay(topic, body, round, argument);
                    break;
                case TaskInterval.RunOnWeek:
                    taskId = scheduler.AddTaskRunOnDay(topic, body, round, argument);
                    break;
                case TaskInterval.RunOnMonth:
                    taskId = scheduler.AddTaskRunOnDay(topic, body, round, argument);
                    break;
                case TaskInterval.Custom:
                    taskId = scheduler.AddTaskCustom(topic, body, argument);
                    break;

            }
            return taskId;
        }
        public static int CleanCompletedTask(Scheduler scheduler, int reserveSeconds)
        {
            var affrows = 0;
            if (scheduler._taskHandler is FreeSqlHandler fsqlHandler)
            {
                var fsql = fsqlHandler._fsql;
                var time1 = DateTime.UtcNow.AddSeconds(-reserveSeconds);
                var taskIds = fsql.Select<TaskInfo>().Where(a => a.Status == TaskStatus.Completed && a.LastRunTime < time1).ToList(a => a.Id);
                if (taskIds.Any())
                {
                    fsql.Transaction(() =>
                    {
                        affrows += fsql.Delete<TaskLog>().Where(a => taskIds.Contains(a.TaskId)).ExecuteAffrows();
                        affrows += fsql.Delete<TaskInfo>().Where(a => taskIds.Contains(a.Id)).ExecuteAffrows();
                    });
                }
            }
            else if (scheduler._taskHandler is FreeRedisHandler redisHandler)
            {
                var redis = redisHandler._redis;
                var _2020 = new DateTime(2020, 1, 1);
                var taskScore = (decimal)DateTime.UtcNow.AddSeconds(-reserveSeconds).Subtract(_2020).TotalSeconds;
                var taskIds = redis.ZRangeByScore($"FreeScheduler_zset_{TaskStatus.Completed}", 0, taskScore);
                foreach (var taskId in taskIds)
                {
                    using (var pipe = redis.StartPipe())
                    {
                        pipe.HDel("FreeScheduler_hset", taskId);
                        pipe.ZRem($"FreeScheduler_zset_all", taskId);
                        pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Running}", taskId);
                        pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Paused}", taskId);
                        pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Completed}", taskId);
                        pipe.Del($"FreeScheduler_zset_log_all");
                        pipe.Del($"FreeScheduler_zset_log:{taskId}");
                        pipe.EndPipe();
                    }
                }
            }
            return affrows;
        }

        public class ResultGetLogs
        {
            public int Total { get; set; }
            public List<TaskLog> Logs { get; set; }
        }
        public static ResultGetLogs GetLogs(Scheduler scheduler, string taskId, int limit = 20, int page = 1)
        {
            var result = new ResultGetLogs();
            if (scheduler._taskHandler is FreeSqlHandler fsqlHandler)
            {
                result.Logs = fsqlHandler._fsql.Select<TaskLog>()
                    .WhereIf(string.IsNullOrWhiteSpace(taskId) == false, a => a.TaskId == taskId)
                    .Count(out var total)
                    .Page(page, limit)
                    .OrderByDescending(a => a.CreateTime)
                    .ToList();
                result.Total = (int)total;
            }
            else if (scheduler._taskHandler is FreeRedisHandler redisHandler)
            {
                var zkey = string.IsNullOrWhiteSpace(taskId) ? "FreeScheduler_zset_log_all" : $"FreeScheduler_zset_log:{taskId}";
                var logs = redisHandler._redis.ZRevRangeByScore(zkey, "+inf", "-inf", Math.Max(0, page - 1) * limit, limit);
                result.Logs = logs.Select(a => redisHandler._redis.Deserialize(a, typeof(TaskLog)) as TaskLog).ToList();
                result.Total = (int)redisHandler._redis.ZCard(zkey);
            }
            else if (scheduler._taskHandler is TestHandler testHandler)
            {
                throw new Exception($"{nameof(TestHandler)} 未实现 {nameof(TaskLog)} 记录");
            }
            return result;
        }
    }
}
