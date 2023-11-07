using FreeRedis;
using FreeScheduler;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using TaskStatus = FreeScheduler.TaskStatus;

namespace FreeSql.FreeScheduler.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("/FreeScheduler/[controller]")]
    public class TaskInfoController : Controller
    {
        IFreeSql fsql;
        RedisClient redis;
        Scheduler scheduler;
        public TaskInfoController(IFreeSql orm, RedisClient redis, Scheduler scheduler)
        {
            fsql = orm;
            this.redis = redis;
            this.scheduler = scheduler;
        }


        [HttpGet("callTask")]
        public ApiResult callTask([FromQuery] string id, [FromQuery] string opt)
        {
            switch (opt)
            {
                case "delete": return ApiResult.Success.SetMessage(scheduler.RemoveTask(id).ToString());
                case "exists": return ApiResult.Success.SetMessage(scheduler.ExistsTask(id).ToString());
                case "resume": return ApiResult.Success.SetMessage(scheduler.ResumeTask(id).ToString());
                case "pause": return ApiResult.Success.SetMessage(scheduler.PauseTask(id).ToString());
                case "run": return ApiResult.Success.SetMessage(scheduler.RunNowTask(id).ToString());
            }
            return ApiResult.Failed;
        }

        [HttpGet]
        async public Task<ActionResult> List([FromQuery] string key, [FromQuery] string pid, [FromQuery] TaskStatus? status, [FromQuery] int limit = 20, [FromQuery] int page = 1)
        {
            var clusters = await redis.ZRangeByScoreWithScoresAsync("freescheduler_cluster", "-inf", "+inf");
            var clusterTasks = new int[clusters.Length];
            var clusterNames = new string[clusters.Length];
            if (clusters.Any()) {
                using (var pipe = redis.StartPipe())
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
                var clustersOrder = clusters.Select((a, index) => new { cluster = a, count = clusterTasks[index] })
                    .OrderByDescending(a => a.cluster.member == scheduler.ClusterId ? int.MaxValue : a.count)
                    .ThenBy(a => a.cluster.member).ToArray();
                clusters = clustersOrder.Select(a => a.cluster).ToArray();
                clusterTasks = clustersOrder.Select(a => a.count).ToArray();

            }
            if (clusters.Any(a => a.member == pid))
            {
                var taskIds = await redis.ZRevRangeByLexAsync($"freescheduler_cluster_register_{pid}", "+", "-", Math.Max(0, page - 1) * 20, 20);
                if (taskIds.Any())
                {
                    taskIds = taskIds.Where(a => a.StartsWith("AddTask_")).Select(a => a.Substring(8)).ToArray();
                    var items = await fsql.Select<TaskInfo>()
                        .WhereIf(status != null, a => a.Status == status)
                        .Where(a => taskIds.Contains(a.Id)).OrderByDescending(a => a.Id).ToListAsync();
                    ViewBag.items = items;
                }
                else
                    ViewBag.items = new List<TaskInfo>();
                ViewBag.count = clusters.Where((a, index) => a.member == pid).Select((a, index) => clusterTasks[index]).FirstOrDefault();
            }
            else
            {
                var select = fsql.Select<TaskInfo>()
                    .WhereIf(status != null, a => a.Status == status)
                    .WhereIf(!string.IsNullOrEmpty(key), a => a.Id.Contains(key) || a.Topic.Contains(key));
                var items = await select.Count(out var count).Page(page, limit).OrderByDescending(a => a.CreateTime).ToListAsync();
                ViewBag.items = items;
                ViewBag.count = count;
            }
            ViewBag.clusters = clusters;
            ViewBag.clusterTasks = clusterTasks;
            ViewBag.clusterNames = clusterNames;
            return View();
        }

        [HttpGet("add")]
        public ActionResult Edit() => View();

        /***************************************** POST *****************************************/

        [HttpPost("add")]
        public ApiResult _Add([FromForm] string Topic, [FromForm] string Body, [FromForm] int Round, [FromForm] TaskInterval Interval, [FromForm] string IntervalArgument)
        {
            string taskId = null;
            switch (Interval)
            {
                case TaskInterval.SEC:
                    var secs = IntervalArgument.Split(',').Select(a => int.Parse(a.Trim())).ToArray();
                    if (secs.Length > 1) taskId = scheduler.AddTask(Topic, Body, secs);
                    else taskId = scheduler.AddTask(Topic, Body, Round, secs[0]);
                    break;
                case TaskInterval.RunOnDay:
                    taskId = scheduler.AddTaskRunOnDay(Topic, Body, Round, IntervalArgument);
                    break;
                case TaskInterval.RunOnWeek:
                    taskId = scheduler.AddTaskRunOnDay(Topic, Body, Round, IntervalArgument);
                    break;
                case TaskInterval.RunOnMonth:
                    taskId = scheduler.AddTaskRunOnDay(Topic, Body, Round, IntervalArgument);
                    break;
                case TaskInterval.Custom:
                    taskId = scheduler.AddTaskCustom(Topic, Body, IntervalArgument);
                    break;

            }
            return ApiResult<object>.Success.SetData(taskId);
        }
    }
}