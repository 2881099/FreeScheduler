using FreeRedis;
using FreeScheduler.TaskHandlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeScheduler
{
    public static class Datafeed
	{
        public class ResultGetPage
        {
            public int Timestamp { get; set; }
            public string Description { get; set; }
            public int Total { get; set; }
            public List<TaskInfo> Tasks { get; set; }
            public List<DateTime?> NextTimes { get; private set; }

			public ClusterInfo[] Clusters { get; set; }

            public class ClusterInfo
            {
                public string Id { get; set; }
                public int Heartbeat { get; set; }
                public string Name { get; set; }
                public int TaskCount { get; set; }
            }

            internal ResultGetPage RefershNextTimes(Scheduler scheduler)
            {
                var now = scheduler.GetDateTime();
				NextTimes = Tasks?.Select(t =>
				{
                    if (t.Status == TaskStatus.Completed) return null;
                    TimeSpan? interval = null;
                    if (t.Interval == TaskInterval.Custom)
                        interval = scheduler._taskIntervalCustomHandler?.NextDelay(t);
                    else
                        interval = t.GetInterval(now, t.CurrentRound);
					return interval != null ? now.Add(interval.Value) : (DateTime?)null;
				}).ToList();
                return this;
			}
		}
		public static Func<Scheduler, string, string, TaskStatus?, DateTime?, DateTime?, int, int, ResultGetPage> GetPageExtend;
		public static ResultGetPage GetPage(Scheduler scheduler, string clusterId = null, string topic = null, TaskStatus? status = null, DateTime? betweenTime = null, DateTime? endTime = null, int limit = 20, int page = 1)
		{
            topic = topic?.Trim();
            if (GetPageExtend != null) return GetPageExtend(scheduler, clusterId, topic, status, betweenTime, endTime, limit, page).RefershNextTimes(scheduler);

			var result = new ResultGetPage();
            result.Timestamp = Scheduler.GetJsTime();
            var timezone = $"{(scheduler.TimeOffset >= TimeSpan.Zero ? "+" : "-")}{scheduler.TimeOffset.Hours.ToString().PadLeft(2, '0')}:{scheduler.TimeOffset.Minutes.ToString().PadLeft(2, '0')}";
            result.Description = $"时区: {timezone}, 集群: {(scheduler.ClusterId == null ? "否" : $"是, 名称: {(string.IsNullOrWhiteSpace(scheduler.ClusterOptions.Name) ? scheduler.ClusterId : scheduler.ClusterOptions.Name)}")}";
            if (scheduler._taskHandler is FreeSqlHandler) result.Description += $", 存储: FreeSql";
            else if (scheduler._taskHandler is FreeRedisHandler) result.Description += $", 存储: Redis";
            else if (scheduler._taskHandler is TestHandler) result.Description += $", 存储: Memory";
            var clusterRedis = scheduler._clusterContext?._redis;
            var clusters = scheduler.ClusterId == null ? new ZMember[0] : clusterRedis.ZRangeByScoreWithScores($"{scheduler.ClusterOptions.RedisPrefix}", "-inf", "+inf");
            if (clusters.Any())
            {
                var clusterTasks = new int[clusters.Length];
                var clusterNames = new string[clusters.Length];
                using (var pipe = clusterRedis.StartPipe())
                {
                    foreach (var cluster in clusters) pipe.ZCard($"{scheduler.ClusterOptions.RedisPrefix}_register_{cluster.member}");
                    foreach (var cluster in clusters) pipe.HGet($"{scheduler.ClusterOptions.RedisPrefix}_name", cluster.member);
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
                var taskIds = clusterRedis.ZRevRangeByLex($"{scheduler.ClusterOptions.RedisPrefix}_register_{clusterId}", "+", "-", Math.Max(0, page - 1) * limit, limit);
                taskIds = taskIds.Where(a => a.StartsWith($"{nameof(Scheduler.AddTask)}_")).Select(a => a.Substring(8)).ToArray();
                if (taskIds.Any())
                {
                    if (scheduler._taskHandler is FreeSqlHandler fsqlHandler)
                    {
                        result.Tasks = fsqlHandler._fsql.Select<TaskInfo>()
                            .Where(a => taskIds.Contains(a.Id))
                            .OrderByDescending(a => a.Id)
                            .ToList()
						    .Where(a => string.IsNullOrWhiteSpace(topic) || a.Topic == topic)
							.Where(a => status == null || a.Status == status)
                            .Where(a => (betweenTime == null || a.CreateTime > betweenTime) && (endTime == null || a.CreateTime <= endTime))
                            .ToList();
                    }
                    else if (scheduler._taskHandler is FreeRedisHandler redisHandler)
                    {
                        result.Tasks = redisHandler._redis.HMGet<TaskInfo>("FreeScheduler_hset", taskIds)
						    .Where(a => string.IsNullOrWhiteSpace(topic) || a.Topic == topic)
							.Where(a => status == null || a.Status == status)
                            .Where(a => (betweenTime == null || a.CreateTime > betweenTime) && (endTime == null || a.CreateTime <= endTime))
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
                        .WhereIf(string.IsNullOrWhiteSpace(topic) == false, a => a.Topic == topic)
                        .WhereIf(status != null, a => a.Status == status)
                        .WhereIf(betweenTime != null, a => a.CreateTime > betweenTime)
                        .WhereIf(endTime != null, a => a.CreateTime <= endTime)
                        .Count(out var total)
                        .Page(page, limit)
                        .OrderByDescending(a => a.Id)
                        .ToList();
                    result.Total = (int)total;
                }
                else if (scheduler._taskHandler is FreeRedisHandler redisHandler)
                {
                    var zkey = "FreeScheduler_zset_all";
                    if (string.IsNullOrWhiteSpace(topic) == false) zkey = status == null ? $"FreeScheduler_zset_q:{topic}_all" : $"FreeScheduler_zset_q:{topic}_{status}";
                    else zkey = status == null ? "FreeScheduler_zset_all" : $"FreeScheduler_zset_{status}";
                    var max = endTime == null ? "+inf" : string.Concat(Math.Max(0, (int)endTime.Value.Subtract(_2020).TotalSeconds));
                    var min = betweenTime == null ? "-inf" : string.Concat(Math.Max(0, (int)betweenTime.Value.Subtract(_2020).TotalSeconds));
                    var taskIds = redisHandler._redis.ZRevRangeByScore(zkey, max, min, Math.Max(0, page - 1) * limit, limit);
                    result.Tasks = taskIds.Any() ? redisHandler._redis.HMGet<TaskInfo>("FreeScheduler_hset", taskIds).ToList() : new List<TaskInfo>();
                    result.Total = (int)redisHandler._redis.ZCard(zkey);
                }
                else if (scheduler._taskHandler is TestHandler testHandler)
                {
                    var queryTasks = testHandler._memoryTasks.Values
						.Where(a => string.IsNullOrWhiteSpace(topic) || a.Topic == topic)
						.Where(a => status == null || a.Status == status.Value)
                        .Where(a => (betweenTime == null || a.CreateTime > betweenTime) && (endTime == null || a.CreateTime <= endTime));
                    result.Total = queryTasks.Count();
                    result.Tasks = queryTasks.OrderByDescending(a => a.Id).Skip(Math.Max(0, page - 1) * limit).Take(limit).ToList();
                }
            }
			return result.RefershNextTimes(scheduler);
		}
        static readonly DateTime _2020 = new DateTime(2020, 1, 1);
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
                    taskId = scheduler.AddTaskRunOnWeek(topic, body, round, argument);
                    break;
                case TaskInterval.RunOnMonth:
                    taskId = scheduler.AddTaskRunOnMonth(topic, body, round, argument);
                    break;
                case TaskInterval.Custom:
                    taskId = scheduler.AddTaskCustom(topic, body, argument);
                    break;

            }
            return taskId;
        }
        public static int CleanStorageData(Scheduler scheduler, int reserveSeconds)
        {
            var affrows = 0;
            if (scheduler._taskHandler is FreeSqlHandler fsqlHandler)
            {
                var fsql = fsqlHandler._fsql;
                var time1 = scheduler.GetDateTime().AddSeconds(-reserveSeconds);
                var taskIds = fsql.Select<TaskInfo>().Where(a => a.Status == TaskStatus.Completed && a.LastRunTime < time1).ToList(a => a.Id);
                if (taskIds.Any())
                {
                    fsql.Transaction(() =>
                    {
                        affrows += fsql.Delete<TaskLog>().Where(a => taskIds.Contains(a.TaskId)).ExecuteAffrows();
                        affrows += fsql.Delete<TaskInfo>().Where(a => taskIds.Contains(a.Id)).ExecuteAffrows();
                        affrows += fsql.Delete<TaskLog>().Where(a => a.CreateTime < time1).ExecuteAffrows();
                    });
                }
            }
            else if (scheduler._taskHandler is FreeRedisHandler redisHandler)
            {
                var redis = redisHandler._redis;
                var taskScore = (decimal)scheduler.GetDateTime().AddSeconds(-reserveSeconds).Subtract(_2020).TotalSeconds;
                var taskIds = redis.ZRangeByScore($"FreeScheduler_zset_{TaskStatus.Completed}", 0, taskScore);
                if (taskIds.Any())
                {
                    var tasks = redis.HMGet<TaskInfo>("FreeScheduler_hset", taskIds);
                    for (var taskIndex = 0; taskIndex < taskIds.Length; taskIndex++)
                    {
                        var taskId = taskIds[taskIndex];
                        var task = tasks[taskIndex];
                        using (var pipe = redis.StartPipe())
                        {
                            pipe.HDel("FreeScheduler_hset", taskId);
                            pipe.ZRem($"FreeScheduler_zset_all", taskId);
                            pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Running}", taskId);
                            pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Paused}", taskId);
                            pipe.ZRem($"FreeScheduler_zset_{TaskStatus.Completed}", taskId);

                            if (task != null)
                            {
                                pipe.ZRem($"FreeScheduler_zset_q:{task.Topic}_all", taskId);
                                pipe.ZRem($"FreeScheduler_zset_q:{task.Topic}_{TaskStatus.Running}", taskId);
                                pipe.ZRem($"FreeScheduler_zset_q:{task.Topic}_{TaskStatus.Paused}", taskId);
                                pipe.ZRem($"FreeScheduler_zset_q:{task.Topic}_{TaskStatus.Completed}", taskId);
                            }

                            pipe.Del($"FreeScheduler_zset_log:{taskId}");
                            foreach (var scan in redis.ZScan($"FreeScheduler_zset_log:{taskId}", "*", 100))
                                if (scan.Length > 0)
                                    pipe.ZRem("FreeScheduler_zset_log_all", scan.Select(a => a.member).ToArray());
                            var ret = pipe.EndPipe();
                            affrows += int.Parse(ret[0]?.ToString());
                            for (var a = 6; a < ret.Length; a++) affrows += int.Parse(ret[a]?.ToString());
                        }
                    }
                }
                var logs = redis.ZRangeByScore("FreeScheduler_zset_log_all", 0, taskScore);
                if (logs.Any())
                {
                    using (var pipe = redis.StartPipe())
                    {
                        pipe.ZRemRangeByScore("FreeScheduler_zset_log_all", 0, taskScore);
                        foreach (var log in logs)
                        {
                            var resultMember = redis.Deserialize(log, typeof(TaskLog)) as TaskLog;
                            if (resultMember == null) continue;
                            pipe.ZRem($"FreeScheduler_zset_log:{resultMember.TaskId}", log);
                        }
                        var ret = pipe.EndPipe();
                        for (var a = 0; a < ret.Length; a++) affrows += int.Parse(ret[a]?.ToString());
                    }
                }
            }
            if (scheduler._clusterContext != null)
            {
                var redis = scheduler._clusterContext._redis;
                var timestamp = Scheduler.GetJsTime();
                foreach (var scan in redis.HScan($"{scheduler.ClusterOptions.RedisPrefix}_offline", "*", 100))
                {
                    var fields = scan.Where(a => int.TryParse(a.Value ?? "", out var tryint) && timestamp - tryint > 86400).Select(a => a.Key).ToArray();
                    if (fields.Any()) redis.HDel($"{scheduler.ClusterOptions.RedisPrefix}_offline", fields);
                }
            }
            return affrows;
        }

        public class ResultGetLogs
        {
            public int Total { get; set; }
            public List<TaskLog> Logs { get; set; }
        }
        public static Func<Scheduler, string, int, int, ResultGetLogs> GetLogsExtend;
        public static ResultGetLogs GetLogs(Scheduler scheduler, string taskId, int limit = 20, int page = 1)
        {
            if (GetLogsExtend != null) return GetLogsExtend(scheduler, taskId, limit, page);
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
            else if (scheduler._taskHandler is TestHandler)
            {
                throw new Exception($"{nameof(TestHandler)} 未实现 {nameof(TaskLog)} 日志记录");
            }
            return result;
        }

        public class ResultGetClusterLogs
        {
            public int Total { get; set; }
            public List<ClusterLog> Logs { get; set; }
        }
        public class ClusterLog
        {
            public DateTime CreateTime { get; set; }
            public string ClusterId { get; set; }
            public string ClusterName { get; set; }
            public string Message { get; set; }
        }
        public static ResultGetClusterLogs GetClusterLogs(Scheduler scheduler, int limit = 20, int page = 1)
        {
            var result = new ResultGetClusterLogs();
            if (scheduler._clusterContext == null)
                throw new Exception("未开启集群，无法使用该操作");

            var redis = scheduler._clusterContext._redis;
            var logkey = $"{scheduler.ClusterOptions.RedisPrefix}_log";
            result.Total = (int)redis.LLen(logkey);
            result.Logs = redis.LRange(logkey, Math.Max(0, page - 1) * limit, Math.Max(0, page) * limit).Select(a =>
            {
                var cols = a.Split(new[] { "|" }, 4, StringSplitOptions.None);
                return new ClusterLog
                {
                    CreateTime = new DateTime(1970, 1, 1).Add(scheduler.TimeOffset).AddSeconds(int.TryParse(cols[0], out var tryint) ? tryint : 0),
                    ClusterId = cols[1],
                    ClusterName = cols[2],
                    Message = cols[3],
                };
            }).ToList();
            return result;
        }
    }
}
