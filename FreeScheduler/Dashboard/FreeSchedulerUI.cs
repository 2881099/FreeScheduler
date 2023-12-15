#if Dashboard
using FreeScheduler.Dashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils = FreeScheduler.Dashboard.Utils;

namespace FreeScheduler
{
    public static class FreeSchedulerUI
    {

        public static IApplicationBuilder UseFreeSchedulerUI(this IApplicationBuilder app, string requestPathBase)
        {
            requestPathBase = requestPathBase.ToLower();
            if (requestPathBase.StartsWith("/") == false) requestPathBase = $"/{requestPathBase}";
            if (requestPathBase.EndsWith("/") == false) requestPathBase = $"{requestPathBase}/";

            var scheduler = app.ApplicationServices.GetService(typeof(Scheduler)) as Scheduler;
            if (scheduler == null) throw new Exception($"{nameof(UseFreeSchedulerUI)} 错误，找不到 Scheduler，请提前注入");

            app.UseFreeAdminLteStaticFiles(requestPathBase);

            app.Use(async (context, next) => {

                var req = context.Request;
                var res = context.Response;
                var location = req.Path.Value;
                var is301 = false;

                if (location.EndsWith("/") == false)
                {
                    is301 = true;
                    location = $"{location}/";
                }

                var reqPath = location.ToLower();
                try
                {
                    if (reqPath == requestPathBase)
                    {
                        if (is301)
                        {
                            res.StatusCode = 301;
                            res.Headers["Location"] = location;
                            return;
                        }
                        //首页
                        await res.WriteAsync(Views.Home.Replace(@"<ul class=""treeview-menu""></ul>", $@"<ul class=""treeview-menu"">
							<li><a href=""{requestPathBase}TaskInfo/""><i class=""fa fa-sort-amount-desc""></i>任务列表</a></li>
							<li><a href=""{requestPathBase}TaskLog/""><i class=""fa fa-headphones""></i>任务日志</a></li>
                            {(scheduler.ClusterId == null ? "" : $"<li><a href=\"{requestPathBase}ClusterLog/\"><i class=\"fa fa-wifi\"></i>集群日志</a></li>")}
						</ul>"));
                        return;
                    }
                    if (reqPath == "/favicon.ico/") return;
                    if (reqPath.StartsWith($"{requestPathBase}taskinfo/add"))
                    {
                        if (req.Method == "POST")
                        {
                            string taskId = Datafeed.AddTask(scheduler, 
                                req.Form["Topic"].FirstOrDefault(),
                                req.Form["Body"].FirstOrDefault(), 
                                int.Parse(req.Form["Round"].FirstOrDefault()),  
                                Enum.Parse<TaskInterval>(req.Form["Interval"].FirstOrDefault()), 
                                req.Form["IntervalArgument"].FirstOrDefault());
                            await Utils.Jsonp(context, new { code = 0, message = "成功", data = taskId });
                            return;
                        }
                        var html = Views.TaskInfo_add;
                        await res.WriteAsync(html);
                        return;
                    }
                    if (reqPath.StartsWith($"{requestPathBase}taskinfo/calltask"))
                    {
                        var result = new Func<bool?>(() =>
                        {
                            var id = req.Query["id"].FirstOrDefault();
                            switch (req.Query["opt"])
                            {
                                case "delete": return scheduler.RemoveTask(id);
                                case "exists": return scheduler.ExistsTask(id);
                                case "resume": return scheduler.ResumeTask(id);
                                case "pause": return scheduler.PauseTask(id);
                                case "run": return scheduler.RunNowTask(id);
                            }
                            return null;
                        })();
                        if (result == null) await Utils.Jsonp(context, new { code = 99, message = "失败" });
                        else  await Utils.Jsonp(context, new { code = 0, message = "成功", data = result });
                        return;
                    }
                    if (reqPath.StartsWith($"{requestPathBase}taskinfo"))
                    {
                        var dto = Datafeed.GetPage(scheduler, 
                            req.Query["clusterId"].FirstOrDefault(),
							req.Query["topic"].FirstOrDefault(),
							Enum.TryParse(typeof(TaskStatus), req.Query["status"].FirstOrDefault(), out var trystatus) ? (TaskStatus?)trystatus : null,
                            DateTime.TryParse(req.Query["createtime_1"].FirstOrDefault() ?? "", out var trydt) ? (DateTime?)trydt.AddHours(-8) : null,
                            DateTime.TryParse(req.Query["createtime_2"].FirstOrDefault() ?? "", out trydt) ? (DateTime?)trydt.AddHours(-8) : null,

                            int.TryParse(req.Query["limit"].FirstOrDefault() ?? "20", out var trylimit) ? trylimit : 20,
                            int.TryParse(req.Query["page"].FirstOrDefault() ?? "1", out var trypage) ? trypage : 1);
                        await res.WriteAsync(Views.TaskInfo_list.Replace("var dto = {};", "var dto = " + Utils.SerializeObject(dto)));
                        return;
                    }
                    if (reqPath.StartsWith($"{requestPathBase}tasklog"))
                    {
                        var dto = Datafeed.GetLogs(scheduler,
                            req.Query["taskId"].FirstOrDefault(),
                            int.TryParse(req.Query["limit"].FirstOrDefault() ?? "20", out var trylimit) ? trylimit : 20,
                            int.TryParse(req.Query["page"].FirstOrDefault() ?? "1", out var trypage) ? trypage : 1);
                        if (req.Query["download"] == "1")
                        {
                            res.ContentType = "application/x-compress";
                            res.Headers["Content-Disposition"] = $"attachment;filename=log.txt";
                            await res.WriteAsync($"日志总数量：{dto.Total} 本次下载数量：{Math.Min(dto.Total, trylimit)}\r\n");
                            foreach (var log in dto.Logs) await res.WriteAsync($"[{log.CreateTime.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss.fff")}] {log.TaskId} 第{log.Round}轮 {(log.Success ? "成功" : "失败")} {log.ElapsedMilliseconds}ms {log.Remark}{(string.IsNullOrWhiteSpace(log.Exception) ? "" : $" 报错：{log.Exception}")}\r\n");
                            return;
                        }
                        await res.WriteAsync(Views.TaskLog_list.Replace("var dto = {};", "var dto = " + Utils.SerializeObject(dto)));
                        return;
                    }
                    if (reqPath.StartsWith($"{requestPathBase}clusterlog"))
                    {
                        var dto = Datafeed.GetClusterLogs(scheduler,
                            int.TryParse(req.Query["limit"].FirstOrDefault() ?? "20", out var trylimit) ? trylimit : 20,
                            int.TryParse(req.Query["page"].FirstOrDefault() ?? "1", out var trypage) ? trypage : 1);
                        if (req.Query["download"] == "1")
                        {
                            res.ContentType = "application/x-compress";
                            res.Headers["Content-Disposition"] = $"attachment;filename=log.txt";
                            await res.WriteAsync($"日志总数量：{dto.Total} 本次下载数量：{Math.Min(dto.Total, trylimit)}\r\n");
                            foreach (var log in dto.Logs) await res.WriteAsync($"[{log.CreateTime.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss.fff")}] {log.ClusterId} {log.ClusterName} {log.Message}\r\n");
                            return;
                        }
                        await res.WriteAsync(Views.ClusterLog_list.Replace("var dto = {};", "var dto = " + Utils.SerializeObject(dto)));
                        return;
                    }
                }
                catch (Exception ex)
                {
                    await Utils.Jsonp(context, new { code = 500, message = ex.Message });
                    return;
                }
                await next();
            });

            return app;
        }

        public static string IsNullOrEmtpty(this string that, string newvalue) => string.IsNullOrEmpty(that) ? newvalue : that;
        public static string FirstLineOrValue(this string that, string newvalue)
        {
            if (string.IsNullOrEmpty(that)) return newvalue;
            return that.Split('\n').First().Trim();
        }
    }
}
#endif