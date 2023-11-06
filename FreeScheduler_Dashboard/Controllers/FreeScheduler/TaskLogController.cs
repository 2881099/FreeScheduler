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
        IFreeSql fsql;
        public TaskLogController(IFreeSql orm)
        {
            fsql = orm;
        }

        [HttpGet]
        async public Task<ActionResult> List([FromQuery] string key, [FromQuery] int limit = 20, [FromQuery] int page = 1)
        {
            var select = fsql.Select<TaskLog>()
                .WhereIf(!string.IsNullOrEmpty(key), a => a.TaskId.Contains(key) || a.Exception.Contains(key) || a.Remark.Contains(key));
            var items = await select.Count(out var count).Page(page, limit).OrderByDescending(a => a.CreateTime).ToListAsync();
            ViewBag.items = items;
            ViewBag.count = count;
            return View();
        }
    }
}