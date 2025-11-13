using FreeRedis;
using FreeScheduler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
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
        Scheduler scheduler;
        public TaskInfoController(Scheduler scheduler)
        {
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
        async public Task<ActionResult> List([FromQuery] string key, [FromQuery] string clusterId, [FromQuery] string topic, [FromQuery] TaskStatus? status, [FromQuery] int limit = 20, [FromQuery] int page = 1)
        {
            var result = Datafeed.GetPage(scheduler, clusterId, topic, status, null, null, limit, page);
            ViewBag.dto = result;
            return View();
        }

        //[HttpGet("add")]
        //public ActionResult Edit() => View();

        [HttpGet("add")]
        public ActionResult Edit([FromQuery] string tpl)
        {
            if(tpl != "CleanStorageData")
            {
				var result = Datafeed.GetTask(scheduler, tpl);
				ViewBag.dto = result;
			}
			
			return View();
		}



        /***************************************** POST *****************************************/

        [HttpPost("add")]
        public ApiResult _Add([FromForm] string Id,[FromForm] string Topic, [FromForm] string Body, [FromForm] int Round, [FromForm] TaskInterval Interval, [FromForm] string IntervalArgument)
        {
            if(Id !=null)
            {
				scheduler.RemoveTask(Id);
			}
			string taskId = Datafeed.AddTask(scheduler, Topic, Body, Round, Interval, IntervalArgument);
			return ApiResult<object>.Success.SetData(taskId);
		}
    }
}