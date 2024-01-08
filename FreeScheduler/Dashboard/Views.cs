#if Dashboard

namespace FreeScheduler.Dashboard
{
	//private set 预留给外部设置
    public static class Views
    {
		public static string ClusterLog_list { get; private set; } = @"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3>
		<span class=""form-group mr15""></span><button class=""btn btn-success pull-right"" onclick=""top.downloadLog()"">下载日志</button>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_list"" action=""./del"" method=""post"">
				<input type=""hidden"" name=""__callback"" value=""del_callback""/>
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						<th scope=""col"">时间</th>
						<th scope=""col"">集群Id</th>
						<th scope=""col"">集群名称</th>
						<th scope=""col"">内容</th>
					</tr>
					<tbody id=dto_list>
					</tbody>
				</table>
			</form>
			<div id=""kkpager""></div>
		</div>
	</div>
</div>

<script type=""text/javascript"">
	(function () {
var dto = {};
var sb = [];
for (var a = 0; a < dto.Logs.length; a++) {
	var log = dto.Logs[a];
	for(var b in log) if(log[b]==null)log[b]='';
	sb.push('<tr>\
								<td>' + log.CreateTime + '</td>\
								<td>' + log.ClusterId + '</td>\
								<td>' + log.ClusterName + '</td>\
								<td style=""overflow-wrap: break-word;word-break: break-all;"">' + log.Message + '</td>\
                            </tr>');
}
if (sb.length > 0) $('#dto_list').html(sb);

		top.downloadLog = function() {
			var line = prompt('请输入日志行数...');
			if (typeof(line) == 'string' && cint(line) > 0) {
				var dqs = _clone(top.mainViewNav.query);
				dqs.paxrefersh = new Date().getTime();
				dqs.download = 1;
				delete dqs.page;
				dqs.limit = line;
				var act = top.mainViewNav.trans('?' + qs_stringify(dqs));
				window.open(act);
			} else {
				alert('标签名输入错误.')
			}
		};
		top.del_callback = function(rt) {
			if (rt.code == 0) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		};

		var qs = _clone(top.mainViewNav.query);
		var page = cint(qs.page, 1);
		delete qs.page;
		$('#kkpager').html(cms2Pager(dto.Total, page, 20, qs, 'page'));
		var fqs = _clone(top.mainViewNav.query);
		delete fqs.page;
		var fsc = [
			null
		];
		fsc.pop();
		cms2Filter(fsc, fqs);
		top.mainViewInit();
	})();
</script>
";

        public static string TaskLog_list { get; private set; } = @"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3>
		<span class=""form-group mr15""></span><button class=""btn btn-success pull-right"" onclick=""top.downloadLog()"">下载日志</button>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_list"" action=""./del"" method=""post"">
				<input type=""hidden"" name=""__callback"" value=""del_callback""/>
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						<th scope=""col"">任务编号</th>
						<th scope=""col"" class=""text-right"">第几轮</th>
						<th scope=""col"" class=""text-right"">耗时</th>
						<th scope=""col"" class=""text-center"">是否成功</th>
						<th scope=""col"">异常信息</th>
						<th scope=""col"">备注</th>
						<th scope=""col"">创建时间</th>
					</tr>
					<tbody id=dto_list>
					</tbody>
				</table>
			</form>
			<div id=""kkpager""></div>
		</div>
	</div>
</div>

<script type=""text/javascript"">
	(function () {

function htmlEncode(html){
    var temp = document.createElement (""div"");
    (temp.textContent != undefined ) ? (temp.textContent = html) : (temp.innerText = html);
    var output = temp.innerHTML;
    temp = null;
    return output;
}
var dto = {};
var sb = [];
for (var a = 0; a < dto.Logs.length; a++) {
	var log = dto.Logs[a];
	for(var b in log) if(log[b]==null)log[b]='';
	sb.push('<tr>\
								<td>' + log.TaskId + '</td>\
								<td class=""text-right"">' + log.Round + '</td>\
								<td class=""text-right"">' + log.ElapsedMilliseconds + 'ms</td>\
								<td class=""text-center"">' + (log.Success ? '<font color=green>是</font>' : '<font color=red>否</font>') + '</td>\
								<td style=""overflow-wrap: break-word;word-break: break-all;"">' + log.Exception + '</td>\
								<td style=""overflow-wrap: break-word;word-break: break-all;"">' + htmlEncode(log.Remark) + '</td>\
								<td>' + log.CreateTime + '</td>\
                            </tr>');
}
if (sb.length > 0) $('#dto_list').html(sb);

		top.downloadLog = function() {
			var line = prompt('请输入日志行数...');
			if (typeof(line) == 'string' && cint(line) > 0) {
				var dqs = _clone(top.mainViewNav.query);
				dqs.paxrefersh = new Date().getTime();
				dqs.download = 1;
				delete dqs.page;
				dqs.limit = line;
				var act = top.mainViewNav.trans('?' + qs_stringify(dqs));
				window.open(act);
			} else {
				alert('标签名输入错误.')
			}
		};
		top.del_callback = function(rt) {
			if (rt.code == 0) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		};

		var qs = _clone(top.mainViewNav.query);
		var page = cint(qs.page, 1);
		delete qs.page;
		$('#kkpager').html(cms2Pager(dto.Total, page, 20, qs, 'page'));
		var fqs = _clone(top.mainViewNav.query);
		delete fqs.page;
		var fsc = [
			null
		];
		fsc.pop();
		cms2Filter(fsc, fqs);
		top.mainViewInit();
	})();
</script>
";

        public static string TaskInfo_list { get; private set; } = @"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3> （<span id=dto_Description></span>）
		<span class=""form-group mr15""></span><a href=""./add"" data-toggle=""modal"" class=""btn btn-success pull-right"">添加</a>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_search"">
				<div id=""div_filter""></div>
			</form>
			<div style=""line-height:36px;border-bottom:1px solid #ddd;word-wrap:break-word;word-break:break-all;"">
				<div style=""float:left;width:70px;"">标题</div>
				<div style=""float:left;width:80%"">
					<input id=topic_1 type=""text"" placeholder=""按【标题】搜索""
						onkeyup=""if(event.keyCode==13)top.searchByTopic();"" 
						style=""font-size:16px;padding:0 9px 0 9px;margin:0;height:32px"" />
				</div>
				<div style=""clear:both;""></div>
			</div>
			<div style=""line-height:36px;border-bottom:1px solid #ddd;word-wrap:break-word;word-break:break-all;"">
				<div style=""float:left;width:70px;"">创建时间</div>
				<div style=""float:left;width:80%"">
					<input id=createtime_1 type=""text"" value=""2020-01-01"" 
						onkeyup=""if(event.keyCode==13)top.searchByCreateTime();"" 
						style=""font-size:16px;padding:0 9px 0 9px;margin:0;height:32px"" />
					至
					<input id=createtime_2 type=""text"" value=""2023-11-11""
						onkeyup=""if(event.keyCode==13)top.searchByCreateTime();"" 
						style=""font-size:16px;padding:0 9px 0 9px;margin:0;height:32px"" />
				</div>
				<div style=""clear:both;""></div>
			</div>
			<form id=""form_list"" action=""./del"" method=""post"">
				<input type=""hidden"" name=""__callback"" value=""del_callback""/>
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						<th scope=""col"">操作</th>
						<th scope=""col"">编号</th>
						<th scope=""col"">标题</th>
						<th scope=""col"">定时</th>
						<th scope=""col"" class=""text-right"">轮次</th>
						<th scope=""col"">状态</th>
						<th scope=""col"">Body</th>
						<th scope=""col"">创建时间</th>
						<th scope=""col"">最后运行时间</th>
						<th scope=""col"">下次运行时间</th>
						<th scope=""col"">错次数</th>
					</tr>
					<tbody id=dto_list>
					</tbody>
				</table>
			</form>
			<div id=""kkpager""></div>
		</div>
	</div>
</div>

<script type=""text/javascript"">
	(function () {
var dto = {};
$('#dto_Description').html(dto.Description.replace(/存储\: (FreeSql|Redis)/, '存储: $1 <a href=""./add?tasktpl=2"">数据太多如何清理？</a>'));
var fscClusterText = [];
var fscClusterValue = [];
for (var a = 0; dto.Clusters != null && a < dto.Clusters.length; a++) {
    var cluster = dto.Clusters[a];
	var name = cluster.Name;
	if (name == null || name == '') name = cluster.Id;
    if (dto.Timestamp - cluster.Heartbeat < 10) name = name + '(' + cluster.TaskCount + ')';
    else if (dto.Timestamp - cluster.Heartbeat < 30) name = '<font color=red>' + name + '(' + cluster.TaskCount + ')[可能离线]</font>';
	else name = '<font color=red>' + name + '(' + cluster.TaskCount + ')[离线]</font>';
	fscClusterText.push(name);
	fscClusterValue.push(cluster.Id);
}
var sb = [];
for (var a = 0; a < dto.Tasks.length; a++) {
	var task = dto.Tasks[a];
	for(var b in task) if(task[b]==null)task[b]='';
	sb.push('<tr>\
								<td class=""text-nowrap"">\
									<input type=""button"" class=""btn btn-xs btn-danger"" value=""删除"" onclick=""if (confirm(\'确认删除吗？\')) top.callTask(\'delete\', \'' + task.Id + '\')"" /> \
' + (function() {
	if (task.Status == 2 || task.Status == 'Completed') return '';
	var btn = '';
	if (task.Status == 1 || task.Status == 'Paused') btn += '<input type=""button"" class=""btn btn-xs btn-success"" value=""恢复"" onclick=""top.callTask(\'resume\', \'' + task.Id + '\')"" /> ';
	if (task.Status == 0 || task.Status == 'Running') btn += '<input type=""button"" class=""btn btn-xs btn-warning"" value=""暂停"" onclick=""top.callTask(\'pause\', \'' + task.Id + '\')"" /> ';
	return btn + '<input type=""button"" class=""btn btn-xs btn-info"" value=""立即触发"" onclick=""top.callTask(\'run\', \'' + task.Id + '\')"" />';
})() + '\
								</td>\
								<td>' + task.Id + '</td>\
								<td class=""text-nowrap"">' + task.Topic + '</td>\
								<td class=""text-nowrap"">' + task.Interval + ' ' + task.IntervalArgument + '</td>\
								<td class=""text-right"">' + (function() {
	if (dto.Description.indexOf('存储: Memory') == -1) return '<a href=""../TaskLog/?taskId=' + task.Id + '"">' + task.CurrentRound + '/' + task.Round + '</a>';
	return task.CurrentRound + '/' + task.Round;
})() + '</td>\
								<td>' + task.Status + '</td>\
								<td style=""overflow-wrap: break-word;word-break: break-all;"">' + task.Body + '</td>\
								<td>' + task.CreateTime + '</td>\
								<td>' + (function() {
	if (dto.Description.indexOf('存储: Memory') == -1) return '<a href=""../TaskLog/?taskId=' + task.Id + '"">' + task.LastRunTime + '</a>';
	return task.LastRunTime;
})() + '</td>\
								<td>' + (dto.NextTimes[a] == null ? '' : dto.NextTimes[a]) + '</td>\
								<td>' + task.ErrorTimes + '</td>\
                            </tr>');
}
if (sb.length > 0) $('#dto_list').html(sb);

		top.callTask = function(opt, id) {
			$.ajax({
				type: 'GET',
				url: top.mainViewNav.trans('./callTask'),
				data: { id: id, opt: opt },
				dataType: 'json',
				success: (rt) => {
					console.log(rt);
					setTimeout(top.mainViewNav.reload, 1000);
				},
			});
		};
		top.searchByTopic = function() {
			var qs = _clone(top.mainViewNav.query);
			delete qs.page;
			qs.topic = $('#topic_1').val();
			console.log(qs)
			top.mainViewNav.goto('?' + qs_stringify(qs));
		};
		top.searchByCreateTime = function() {
			var qs = _clone(top.mainViewNav.query);
			delete qs.page;
			qs.createtime_1 = $('#createtime_1').val();
			qs.createtime_2 = $('#createtime_2').val();
			console.log(qs)
			top.mainViewNav.goto('?' + qs_stringify(qs));
		};

		top.del_callback = function(rt) {
			if (rt.code == 0) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		};

		var qs = _clone(top.mainViewNav.query);
		$('#topic_1').val((qs.topic || '').trim());
		var yyyy = new Date().getYear() + 1900;
		var mm = new Date().getMonth() + 1;
		var dd = new Date().getDate();
		dd += 1;
		var maxdd = 0;
		if (mm == 1 || mm == 3 || mm == 5 || mm == 7 || mm == 8 || mm == 10 || mm == 12) maxdd = 31;
		else if (mm == 2) maxdd = (yyyy - 2000) % 4 == 0 ? 28 : 29;
		else maxdd = 30;
		if (dd > maxdd) {
			dd = 1;
			mm += 1;
			if (mm > 12) {
				mm = 1;
				yyyy += 1;
			}
		}
		var date = yyyy + '-' + mm + '-' + dd;
		if (qs.createtime_1) $('#createtime_1').val(qs.createtime_1);
		$('#createtime_2').val(qs.createtime_2 || date);
		var page = cint(qs.page, 1);
		delete qs.page;
		$('#kkpager').html(cms2Pager(dto.Total, page, 20, qs, 'page'));
		var fqs = _clone(top.mainViewNav.query);
		delete fqs.page;
		var fsc = [
			{ name: '集群', field: 'clusterId', single: 1, text: fscClusterText, value: fscClusterValue },
			{ name: '状态', field: 'status', single: 1, text: ['运行中','暂停中','已完成'], value: [0,1,2] },
			null
		];
		fsc.pop();
		cms2Filter(fsc, fqs);
		top.mainViewInit();
	})();
</script>
";

		public static string TaskInfo_add { get; private set; } = @"
<div class=""box"">
	<div class=""box-header with-border"">
		<h3 class=""box-title"" id=""box-title""></h3>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_add"" method=""post"">
				<input type=""hidden"" name=""__callback"" value=""edit_callback"" />
				<div>
					<table cellspacing=""0"" rules=""all"" class=""table table-bordered table-hover"" border=""1"" style=""border-collapse:collapse;"">
						<tr>
							<td>模板</td>
							<td>
								<input id=tasktpl_01 name=tasktpl type=radio value=1 /><label for=tasktpl_01>HTTP请求</label>
								<input id=tasktpl_02 name=tasktpl type=radio value=2 /><label for=tasktpl_02>清理任务数据</label>

							</td>
						</tr>
						<tr>
							<td>标题</td>
							<td><input name=""Topic"" type=""text"" class=""datepicker"" style=""width:60%;"" placeholder=""用在 OnExecuting 区分任务"" /></td>
						</tr>
					    <tr>
							<td id=""BodyLabel"">数据</td>
							<td><textarea name=""Body"" style=""width:60%;height:200px;"" editor=""ueditor"" placeholder=""用在 OnExecuting 区分相同 Title 任务的参数数据""></textarea></td>
						</tr>
					    <tr>
							<td>轮次</td>
							<td><input name=""Round"" type=""text"" class=""datepicker"" style=""width:60%;"" placeholder=""循环多少次，-1 是永久循环"" /></td>
						</tr>
					    <tr>
							<td>定时类型</td>
							<td>
                                <select name=""Interval"" onchange=""top.IntervalChange(this.value);""><option value="""">------ 请选择 ------</option>
									<option value=""SEC"">SEC 秒间隔</option>
									<option value=""RunOnDay"">RunOnDay 每天</option>
									<option value=""RunOnWeek"">RunOnWeek 每周</option>
									<option value=""RunOnMonth"">RunOnMonth 每月</option>
									<option value=""Custom"">Custom 自定义</option>
								</select>
                            </td>
						</tr>
					    <tr>
							<td>定时参数(UTC)</td>
							<td>
								<input name=""IntervalArgument"" type=""text"" class=""datepicker"" style=""width:60%;"" />
								<div id=""IntervalArgument_tips""></div>
							</td>
						</tr>
						<tr>
							<td width=""8%"">&nbsp</td>
							<td><input type=""submit"" class=""btn btn-info"" value=""添加"" />&nbsp;<input type=""button"" class=""btn"" value=""取消"" /></td>
						</tr>
					</table>
				</div>
			</form>

		</div>
	</div>
</div>

<script type=""text/javascript"">
	(function () {
		var form = $('#form_add')[0];

$('input[name=tasktpl]').change(function() {
	var val = $(this).val();
	if (val == '1') {
		form.Topic.value = '[系统预留]Http请求';
		form.Body.value = `{
	""method"": ""get"",
	""url"": ""https://freesql.net/guide/freescheduler.html"",
	""header"":
	{
		""Content-Type"": ""application/json"",
	},
	""body"": ""{}"",
}
`;
		form.Round.value = -1;
		return;
	}
	if (val == '2') {
		form.Topic.value = '[系统预留]清理任务数据';
		form.Body.value = '86400';
		$('#form_add #BodyLabel').html('清理多久之前的记录（单位：秒）<br>已完成的任务');
		form.Round.value = -1;
		return;
	}
});
if (top.mainViewNav.query.tasktpl) {
	var radio = $('input[name=tasktpl][value=' + top.mainViewNav.query.tasktpl + ']');
	radio.click();
}

		top.IntervalChange = function(val) {
			var tips = null;
			if (val == 'SEC') {
				form.IntervalArgument.value = '5'
				tips = `
//每5秒触发，执行N次
var id = scheduler.AddTask(""topic1"", ""body1"", round: -1, 5)

//每次 不同的间隔秒数触发，执行6次
var id = scheduler.AddTask(""topic1"", ""body1"", new [] { 5, 5, 10, 10, 60, 60 })`
			}
			if (val == 'RunOnDay') {
				form.IntervalArgument.value = '08:00:00'
				tips = `
//每天 08:00:00 触发，执行N次（注意时区）
var id = scheduler.AddTaskRunOnDay(""topic1"", ""body1"", round: -1, ""08:00:00"")`
			}
			if (val == 'RunOnWeek') {
				form.IntervalArgument.value = '1:08:00:00'
				tips = `
//每周一 08:00:00 触发，执行1次（注意时区）
var id = scheduler.AddTaskRunOnWeek(""topic1"", ""body1"", round: 1, ""1:08:00:00"")

//每周日 08:00:00 触发，执行1次（注意时区）
var id = scheduler.AddTaskRunOnWeek(""topic1"", ""body1"", round: 1, ""0:08:00:00"")`
			}
			if (val == 'RunOnMonth') {
				form.IntervalArgument.value = '1:08:00:00'
				tips = `
//每月1日 08:00:00 触发，执行12次（注意时区）
var id = scheduler.AddTaskRunOnMonth(""topic1"", ""body1"", round: 12, ""1:08:00:00"")

//每月最后一日 08:00:00 触发，执行12次
var id = scheduler.AddTaskRunOnMonth(""topic1"", ""body1"", round: 12, ""-1:08:00:00"")`
			}
			if (val == 'Custom') {
				form.IntervalArgument.value = '0/1 * * * * ?'
				tips = `
//自定义间隔 cron
var id = scheduler.AddTaskCustom(""topic1"", ""body1"", ""0/1 * * * * ? "")

new FreeSchedulerBuilder()
    ...
    .UseCustomInterval(task =>
    {
        //利用 cron 功能库解析 task.IntervalArgument 得到下一次执行时间
        //与当前时间相减，得到 TimeSpan，若返回 null 则任务完成
        return TimeSpan.FromSeconds(5);
    })
    .Build();`
			}
			if (tips) $('#IntervalArgument_tips').html(tips.replace(/ /g, '&nbsp;').replace(/\n/g, '<br>'))
		}
		top.edit_callback = function (rt) {
			if (rt.code == 0) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		};

		
		var item = null;

		top.mainViewInit();
	})();
</script>
";

        public static string Home { get; private set; } = @"
<!DOCTYPE html>
<html lang=""zh-cmn-Hans"">
<head>
	<meta charset=""utf-8"" />
	<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
	<title>FreeScheduler</title>
	<meta content=""width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"" name=""viewport"" />
	<link href=""./htm/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/font-awesome/css/font-awesome.min.css"" rel=""stylesheet"" />
	<link href=""./htm/css/skins/_all-skins.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/pace/pace.min.css"" rel=""stylesheet"" />
	<link href=""./htm/css/system.css"" rel=""stylesheet"" />
	<link href=""./htm/css/index.css"" rel=""stylesheet"" />
	<script type=""text/javascript"" src=""./htm/js/jQuery-2.1.4.min.js""></script>
	<script type=""text/javascript"" src=""./htm/bootstrap/js/bootstrap.min.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/pace/pace.min.js""></script>
	<script type=""text/javascript"" src=""./htm/js/lib.js""></script>
	<script type=""text/javascript"" src=""./htm/js/bmw.js""></script>
	<!--[if lt IE 9]>
	<script type='text/javascript' src='./htm/plugins/html5shiv/html5shiv.min.js'></script>
	<script type='text/javascript' src='./htm/plugins/respond/respond.min.js'></script>
	<![endif]-->
</head>
<body class=""hold-transition skin-blue sidebar-mini"">
	<div class=""wrapper"">
		<!-- Main Header-->
		<header class=""main-header"">
			<!-- Logo--><a href=""./"" class=""logo"">
				<!-- mini logo for sidebar mini 50x50 pixels--><span class=""logo-mini""><b>Free</b></span>
				<!-- logo for regular state and mobile devices--><span class=""logo-lg""><b>FreeScheduler</b></span>
			</a>
			<!-- Header Navbar-->
			<nav role=""navigation"" class=""navbar navbar-static-top"">
				<!-- Sidebar toggle button--><a href=""#"" data-toggle=""offcanvas"" role=""button"" class=""sidebar-toggle""><span class=""sr-only"">Toggle navigation</span></a>
				<!-- Navbar Right Menu-->
				<div class=""navbar-custom-menu"">
					<ul class=""nav navbar-nav"">
						<li>
							<a href=""https://www.cnblogs.com/FreeSql/gallery/image/338860.html"" target=""_blank"">支付宝打赏</a>
						</li>
						<li>
							<a href=""https://www.cnblogs.com/FreeSql/gallery/image/338859.html"" target=""_blank"">微信打赏</a>
						</li>
					</ul>
				</div>
			</nav>
		</header>
		<!-- Left side column. contains the logo and sidebar-->
		<aside class=""main-sidebar"">
			<!-- sidebar: style can be found in sidebar.less-->
			<section class=""sidebar"">
				<!-- Sidebar Menu-->
				<ul class=""sidebar-menu"">
					<!-- Optionally, you can add icons to the links-->

					<li class=""treeview active"">
						<a href=""#""><i class=""fa fa-laptop""></i><span>通用管理</span><i class=""fa fa-angle-left pull-right""></i></a>
						<ul class=""treeview-menu""></ul>
					</li>

					<li class=""treeview active"">
						<a href=""#""><i class=""fa fa-laptop""></i><span>开发文档</span><i class=""fa fa-angle-left pull-right""></i></a>
						<ul class=""treeview-menu"">
							<li><a href=""https://freesql.net/guide/freescheduler.html"" target=""_blank""><i class=""fa fa-circle-o""></i>FreeScheduler</a></li>
							<li><a href=""https://freesql.net/"" target=""_blank""><i class=""fa fa-circle-o""></i>FreeSql</a></li>
							<li><a href=""https://freesql.net/guide/freeredis.html"" target=""_blank""><i class=""fa fa-circle-o""></i>FreeRedis</a></li>
							<li><a href=""https://freesql.net/guide/freeim.html"" target=""_blank""><i class=""fa fa-circle-o""></i>FreeIM</a></li>
						</ul>
					</li>
				</ul>
				<!-- /.sidebar-menu-->
			</section>
			<!-- /.sidebar-->
		</aside>
		<!-- Content Wrapper. Contains page content-->
		<div class=""content-wrapper"">
			<!-- Main content-->
			<section id=""right_content"" class=""content"">
				<div style=""display:none;"">
					<!-- Your Page Content Here-->
					Loading...
				</div>
			</section>
			<!-- /.content-->
		</div>
		<!-- /.content-wrapper-->
	</div>
	<!-- ./wrapper-->
	<script type=""text/javascript"" src=""./htm/js/system.js""></script>
	<script type=""text/javascript"" src=""./htm/js/admin.js?v=1""></script>
	<script type=""text/javascript"">
		if (!location.hash) $('#right_content div:first').show();
		// 路由功能
		//针对上面的html初始化路由列表
		function hash_encode(str) { return url_encode(base64.encode(str)).replace(/%/g, '_'); }
		function hash_decode(str) { return base64.decode(url_decode(str.replace(/_/g, '%'))); }
		window.div_left_router = {};
		$('li.treeview.active ul li a').each(function (index, ele) {
			if (ele.target == '_blank') return;
			var href = $(ele).attr('href');
			$(ele).attr('href', '#base64url' + hash_encode(href));
			window.div_left_router[href] = $(ele).text();
        });
        if (!location.hash) $('li.treeview.active ul li a')[0].click();
		(function () {
			function Vipspa() {
			}
			Vipspa.prototype.start = function (config) {
				Vipspa.mainView = $(config.view);
				startRouter();
				window.onhashchange = function () {
					if (location._is_changed) return location._is_changed = false;
					startRouter();
				};
			};
			function startRouter() {
				var hash = location.hash;
				if (hash === '') return //location.hash = $('li.treeview.active ul li a:first').attr('href');//'#base64url' + hash_encode('/resume_type/');
				if (hash.indexOf('#base64url') !== 0) return;
				var act = hash_decode(hash.substr(10, hash.length - 10));
				//加载或者提交form后，显示内容
				function ajax_success(refererUrl) {
					if (refererUrl == location.pathname) { startRouter(); return function(){}; }
					var hash = '#base64url' + hash_encode(refererUrl);
					if (location.hash != hash) {
						location._is_changed = true;
						location.hash = hash;
					}'\''
					return function (data, status, xhr) {
						var div;
						Function.prototype.ajax = $.ajax;
						top.mainViewNav = {
							url: refererUrl,
							trans: function (url) {
								var act = url;
								act = act.substr(0, 1) === '/' || act.indexOf('://') !== -1 || act.indexOf('data:') === 0 ? act : join_url(refererUrl, act);
								return act;
							},
							goto: function (url_or_form, target) {
								var form = url_or_form;
								if (typeof form === 'string') {
									var act = this.trans(form);
									if (String(target).toLowerCase() === '_blank') return window.open(act);
									location.hash = '#base64url' + hash_encode(act);
								}
								else {
									if (!window.ajax_form_iframe_max) window.ajax_form_iframe_max = 1;
									window.ajax_form_iframe_max++;
									var iframe = $('<iframe name=""ajax_form_iframe{0}""></iframe>'.format(window.ajax_form_iframe_max));
									Vipspa.mainView.append(iframe);
									var act = $(form).attr('action') || '';
									act = act.substr(0, 1) === '/' || act.indexOf('://') !== -1 ? act : join_url(refererUrl, act);
									if ($(form).find(':file[name]').length > 0) $(form).attr('enctype', 'multipart/form-data');
									$(form).attr('action', act);
									$(form).attr('target', iframe.attr('name'));
									iframe.on('load', function () {
										var doc = this.contentWindow ? this.contentWindow.document : this.document;
										if (doc.body.innerHTML.length === 0) return;
										if (doc.body.innerHTML.indexOf('Error:') === 0) return alert(doc.body.innerHTML.substr(6));
										//以下 '<script ' + '是防止与本页面相匹配，不要删除
										if (doc.body.innerHTML.indexOf('<script ' + 'type=""text/javascript"">location.href=""') === -1) {
											ajax_success(doc.location.pathname + doc.location.search)(doc.body.innerHTML, 200, null);
										}
									});
								}
							},
							reload: startRouter,
							query: qs_parseByUrl(refererUrl)
						};
						top.mainViewInit = function () {
							if (!div) return setTimeout(top.mainViewInit, 10);
							admin_init(function (selector) {
								if (/<[^>]+>/.test(selector)) return $(selector);
								return div.find(selector);
							}, top.mainViewNav);
						};
						if (/<body[^>]*>/i.test(data))
							data = data.match(/<body[^>]*>(([^<]|<(?!\/body>))*)<\/body>/i)[1];
						div = Vipspa.mainView.html(data);
					};
				};
				$.ajax({
					type: 'GET',
					url: act,
					dataType: 'html',
					success: ajax_success(act),
					error: function (jqXHR, textStatus, errorThrown) {
						var data = jqXHR.responseText;
						if (/<body[^>]*>/i.test(data))
							data = data.match(/<body[^>]*>(([^<]|<(?!\/body>))*)<\/body>/i)[1];
						Vipspa.mainView.html(data);
					}
				});
			}
			window.vipspa = new Vipspa();
		})();
		$(function () {
			vipspa.start({
				view: '#right_content',
			});
		});
		// 页面加载进度条
		$(document).ajaxStart(function() { Pace.restart(); });
	</script>
</body>
</html>
";
    }
}
#endif
