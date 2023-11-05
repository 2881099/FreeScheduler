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

namespace FreeSql.AdminLTE.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("/AdminLTE/[controller]")]
    public class TaskLogController : Controller
    {
        IFreeSql fsql;
        public TaskLogController(IFreeSql orm) {
            fsql = orm;
        }

        [HttpGet]
        async public Task<ActionResult> List([FromQuery] string key, [FromQuery] int limit = 20, [FromQuery] int page = 1)
        {
            var select = fsql.Select<TaskLog>()
                .WhereIf(!string.IsNullOrEmpty(key), a => a.TaskId.Contains(key) || a.Exception.Contains(key) || a.Remark.Contains(key));
            var items = await select.Count(out var count).Page(page, limit).ToListAsync();
            ViewBag.items = items;
            ViewBag.count = count;
            return View();
        }

        [HttpGet("add")]
        public ActionResult Edit() => View();

        /***************************************** POST *****************************************/

        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        async public Task<ApiResult> _Add([FromForm] string TaskId, [FromForm] int Round, [FromForm] long ElapsedMilliseconds, [FromForm] bool Success, [FromForm] string Exception, [FromForm] string Remark, [FromForm] DateTime CreateTime)
        {
            var item = new TaskLog();
            item.TaskId = TaskId;
            item.Round = Round;
            item.ElapsedMilliseconds = ElapsedMilliseconds;
            item.Success = Success;
            item.Exception = Exception;
            item.Remark = Remark;
            item.CreateTime = CreateTime;
            using (var ctx = fsql.CreateDbContext())
            {
                await ctx.AddAsync(item);
                await ctx.SaveChangesAsync();
            }
            return ApiResult<object>.Success.SetData(item);
        }
    }
}