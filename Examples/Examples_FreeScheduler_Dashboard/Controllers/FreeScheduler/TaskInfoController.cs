using FreeScheduler;
using FreeSql;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
        Scheduler scheduler;
        public TaskInfoController(IFreeSql orm, Scheduler scheduler) {
            fsql = orm;
            this.scheduler = scheduler;
        }


        [HttpGet("callTask")]
        public ApiResult callTask([FromQuery] string id, [FromQuery] string opt)
        {
            var task = fsql.Select<TaskInfo>().Where(a => a.Id == id).First();
            switch(opt)
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
        async public Task<ActionResult> List([FromQuery] string key, [FromQuery] int limit = 20, [FromQuery] int page = 1)
        {
            var select = fsql.Select<TaskInfo>()
                .WhereIf(!string.IsNullOrEmpty(key), a => a.Id.Contains(key) || a.Topic.Contains(key) || a.Body.Contains(key) || a.IntervalArgument.Contains(key));
            var items = await select.Count(out var count).Page(page, limit).OrderByDescending(a => a.CreateTime).ToListAsync();
            ViewBag.items = items;
            ViewBag.count = count;
            return View();
        }

        [HttpGet("add")]
        public ActionResult Edit() => View();

        /***************************************** POST *****************************************/

        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        async public Task<ApiResult> _Add([FromForm] string Topic, [FromForm] string Body, [FromForm] int Round, [FromForm] TaskInterval Interval, [FromForm] string IntervalArgument)
        {
            string taskId = null;
            switch (Interval)
            {
                case TaskInterval.SEC:
                    taskId = scheduler.AddTask(Topic, Body, Round, int.Parse(IntervalArgument));
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