using FreeScheduler;
using Microsoft.AspNetCore.Mvc;

namespace FreeSql.FreeScheduler.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("/FreeScheduler/[controller]")]
    public class TaskLogController : Controller
    {
        Scheduler scheduler;
        public TaskLogController(Scheduler scheduler)
        {
            this.scheduler = scheduler;
        }

        [HttpGet]
        async public Task<ActionResult> List([FromQuery] string taskId, [FromQuery] int limit = 20, [FromQuery] int page = 1)
        {
            var dto = Datafeed.GetLogs(scheduler, taskId, limit, page);
            ViewBag.items = dto.Logs;
            ViewBag.count = dto.Total;
            return View();
        }
    }
}