$.ajaxSettings.dataType = 'json';
$.ajaxSettings.error = function(jqXHR, textStatus, errorThrown) {
	if (jqXHR.status == 501) {
		alert("您还没有登陆");
		location.reload();
	}
};

// 最后特效，一定要放在页面底部
function tr_mouseover() {
	$('form tr td').unbind('mouseover').mouseover(function(){$(this).parent().children().css('background-color',function(index,value){if(!this.oldbgcolor)this.oldbgcolor=value;return '#eee';});});
	$('form tr td').unbind('mouseout').mouseout(function(){$(this).parent().children().css('background-color',function(index,value){return this.oldbgcolor;})});
}

function yieldTreeArray(arr, parent_id, Id, Parent_id) {
	var root = [];
	for (var a = 0; a < arr.length; a++) {
		if (!arr[a]) continue;
		if (arr[a] && arr[a][Parent_id] == parent_id) {
			arr[a]._child = yieldTreeArray(arr, arr[a][Id], Id, Parent_id);
			root.push(arr[a]);
		}
	}
	return root;
}
function yieldTreeTable(root, tpl) {
	var html = '';
	for (var a = 0; a < root.length; a++) {
		if (!root[a]) continue;
		html += bmwjs.render(tpl, root[a]);
		if (root[a]._child && root[a]._child.length > 0) html += yieldTreeTable(root[a]._child, tpl);
	}
	return html;
}
function yieldTreeSelect(items, textTpl, valueField, left) {
	var sb = left ? '' : '<select><option value="">------ 请选择 ------</option>';
	for (var a = 0; a < items.length; a++) {
		var l = a === items.length - 1 ? '└' : '├';
		var text = (left || '') + l + textTpl;
		for (var b in items[a]) text = text.replace(new RegExp('\{#' + b + '\}', 'g'), String(items[a][b]).htmlencode());
		sb += '<option value="{0}">{1}</option>'.format(items[a][valueField], text);
		if (items[a]._child && items[a]._child.length)
			sb += yieldTreeSelect(items[a]._child, textTpl, valueField, (left || '') + (a === items.length - 1 ? '　' : '│'));
	}
	sb += left ? '' : '</select>';
	return sb;
}
function renderTpl(el, data) {
	el = $(el);
	var html = bmwjs.render(el.html(), data);
	el.html(html);
}

function cms2Pager(count, pageindex, pagesize, qs, pageQueryName) {
	var maxpage = Math.ceil(count / pagesize);//总页数总数据条数/每页显示数 向上取整  
	if (pageindex <= 0) pageindex = 1;
	if (pageindex >= maxpage) pageIndex = maxpage;
	var data = {
		pageindex: pageindex, maxpage: maxpage, pagesize: pagesize, count: count, getLink: function (n) {
			qs[pageQueryName] = n;
			return '?' + qs_stringify(qs);
		}
	};
	var tpl = '<ul class="pagination" style="margin-top: 0;float:left;">\
	{%\
	var for_start = Math.max(1, pageindex - 5);\
	var for_end = Math.min(pageindex + 5, maxpage);\
	%}\
	<li @if="maxpage > 0 && pageindex > 1"><a href="{#getLink(1)}">首页</a></li>\
	<li @if="maxpage > 0 && pageindex > 1"><a href="{#getLink(pageindex - 1)}">上页</a></li>\
	<li @if="for_start > 1" class="active"><a href="{#getLink(for_start)}" onclick="return false;">..</a></li>\
	{for a for_start,for_end + 1}\
	<li @if="a == pageindex" class="active"><a href="{#getLink(a)}" onclick="return false;">{#a}</a></li>\
	<li @else=""><a href="{#getLink(a)}">{#a}</a></li>\
	{/for}\
	<li @if="for_end < maxpage" class="active"><a href="{#getLink(for_end)}" onclick="return false;">..</a></li>\
	<li @if="pageindex < maxpage"><a href="{#getLink(pageindex + 1)}">下页</a></li>\
	<li @if="pageindex < maxpage"><a href="{#getLink(maxpage)}">尾页</a></li>\
	<li><span>页数：{#pageindex}/{#maxpage} 每页：{#pagesize} 总计：{#count}</span></li>\
  </ul>';
	return bmwjs.render(tpl, data);
}
function cms2Filter(schema, query_all) {
	//query_all = qs;
	//schema = [
	//	{ name: '性别', field: 'sex', text: ['男,女'], value: [1,0] },
	//	{ name: '学历', field: 'edu', text: ['博士','硕士','本科','专科','其他'], value: [1,2,3,4,5] },
	//	{ name: '学校类别', field: 'school_type', text: [985,921] },
	//	{ name: '届次', field: 'xzyear', text: [2012,2013,2014,2015,2016] },
	//	{ name: '司龄', field: 'age', text: ['低于1年','1年','2年','3年','4年','5-10年','10年以上'] }
	//];
	for (var a = 0; a < schema.length; a++) {
		if (!schema[a].value) schema[a].value = schema[a].text;
		var sb = '<div style="line-height:36px;border-bottom:1px solid #ddd;word-wrap:break-word;word-break:break-all;">\
			<div style="float:left;width:100px;">{1}</div>\
			<div style="float:left;"><a name="a_{0}_all" field="{0}" href="#" style="padding:3px 6px 3px 6px;background-color:#eee;">全部</a>&nbsp;'.format(schema[a].field, schema[a].name);
		for (var b = 0; b < schema[a].value.length; b++)
			sb += '<a id="a_{0}_id_{1}" name="a_{0}_id" field="{0}" value="{2}" href="#" style="padding:3px 6px 3px 6px;background-color:#eee;">{3}</a>&nbsp;'.format(schema[a].field, b, schema[a].value[b], String(schema[a].text[b]).htmlencode());
		sb += '</div><div style="clear:both;"></div></div>';
		$('#form_search div#div_filter').append(sb);
		var qs_field = query_all[schema[a].field];
		if (qs_field) {
			var sel = qs_field;
			if (!isArray(sel)) sel = [sel];
			$('#form_search #div_filter a[name="a_{0}_id"]'.format(schema[a].field)).each(function (idx, ele) {
				var value = $(ele).attr('value');
				for (var a = 0; a < sel.length; a++) if (value === sel[a]) $(ele).css('color', 'white').css('backgroundColor', '#00a65e');
			});
		} else $('#form_search #div_filter a[name="a_{0}_all"]'.format(schema[a].field)).css('color', 'white').css('backgroundColor', '#00a65e');
	}
	$('#form_search #div_filter a').click(function () {
		var ele = $(this);
		var field = ele.attr('field');
		var value = ele.attr('value');
		if (!value) delete query_all[field]; //清除条件
		else if (!query_all[field]) query_all[field] = value;
		else {
			var issel = true;
			var farr = query_all[field];
			if (!isArray(farr)) farr = query_all[field] = [farr];
			for (var b = farr.length - 1; b >= 0; b--)
				if (farr[b] === value) {
					query_all[field].splice(b, 1);
					issel = false;
				}
			if (issel) query_all[field].push(value);
		}
		top.mainViewNav.goto('?' + qs_stringify(query_all));
		return false;
	});
}
function fillForm(form, obj) {
	$('form#form_add input[type="submit"]').val(obj ? '更新' : '添加');
	if (!obj || !form) return;
	for (var a in obj)
		if (form[a])
			if (String(form[a].type).toLowerCase() === 'checkbox') form[a].checked = obj[a] === '1';
			else if (obj[a] == 0) form[a].value = obj[a];
			else form[a].value = obj[a] || '';
}

function admin_init($, nav) {
	window.nav = nav;
	var div_left_router = window.div_left_router;
	var pathname = nav.url.split('?')[0];

	$(".select2").select2();
	$('[data-mask]').inputmask();
	var submit = $('form#form_add input[type="submit"]');
	$('form#form_add').submit(function (e) {
		if (submit.val() == '更新')
			if (!confirm('确认要更新数据吗？')) {
				e.stopImmediatePropagation();
				return false;
			}
	});
	$('form#form_add input[type="button"][value="取消"]').attr('onclick', '').unbind().click(function () {
		nav.goto('./');
	});
	$('table tr').each(function (i, el) {
		var td = $(el).find('td')
		if (td.length === 2) td[0].style.width = '8%';
	});
	//设置页面title
	for (var a in div_left_router) {
		var tmp1 = pathname;
		var title = div_left_router[a];
		var ele_href = a;
		if (!ele_href) continue;
		tmp1 = tmp1.replace(/\/(del|edit|add)/i, function ($0, $1, $2) {
			if ($1 === 'edit' || $1 === 'add') title = title + ' - ' + submit.val();
			return '/';
		});
		if (ele_href.indexOf(tmp1) != -1) {
			document.title2 = document.title2 || document.title;
			document.title = title + ' - ' + document.title2;
			$('#box-title:first').html(title + ' <font color="#aaa">({0})</font>'.format(nav.url));
			break;
		}
	}
	$('#btn_delete_sel').click(function () {
		if (confirm('操作不可逆，确认要删除选择项吗？')) {
			$('form#form_list').submit();
		}
		return false;
	});
	//处理multi_status，多选字段
	var multi_status_count = 0;
	$('input[multi_status]').each(function (index, el) {
		el = $(el);
		var status = el.attr('multi_status').split(',');
		var val = el.val();
		if (isNaN(parseInt(val, 10))) el.val(val = 0);
		for (var a = 0; a < status.length; a++) {
			var chkid = 'multi_status_checkbox_' + multi_status_count++;
			var chk = $('<input type="checkbox" id="' + chkid + '"' +
				((val & Math.pow(2, a)) == Math.pow(2, a) ? ' checked' : '') +
				' onclick=""/><label for="' + chkid + '">' + status[a] + '</label>');
			el.before(chk);
			(function (a) {
				$('#' + chkid).click(function () {
					el.val(val = parseInt(val, 10) + (this.checked ? 1 : -1) * Math.pow(2, a));
				});
			})(a);
		}
	});
	//处理百度编辑器
	//$('textarea').each(function (i, el) {
	//	if (el.style.width === '100%') {
	//		new baidu.editor.ui.Editor({
	//			scaleEnabled: true
	//		}).render(el);
	//	}
	//});
	//处理table中长文本显示问题
	$('form#form_list td').each(function (index, ele) {
		var html = ele.innerHTML;
		if (!/<[^>]+>/gi.test(html)) {
			if (html.getLength() > 36) $(ele).html('').append($('<div></div>').attr('title', html).html(html.left(36) + '...'));
		} else $(ele).find('a').each(function(index, ele) {
			var html = ele.innerHTML;
			if (html.getLength() > 36) $(ele).html(html.left(36) + '...').attr('title', html);
		});
	});
	$('img').each(function (idx, ele) {
		ele = $(ele);
		var src = nav.trans(ele.attr('src'));
		ele.attr('src', src);
	});
	$('a').click(function () {
		var href = $(this).attr('href');
		if (!href || href.substr(0, 1) === '#') return false;
		nav.goto(href, $(this).attr('target'));
		return false;
	});
	$('form').submit(function () {
		if (this.method.toLowerCase() == 'post') {
			nav.goto(this);
			return true;
		}
		var act = $(this).attr('action') || '';
		var qs = qs_parseByUrl(act);
		qs = qs_stringify(qs) + '&' + url_decode($(this).serialize());
		qs = qs_parse(qs);
		qs = qs_stringify(qs);
		nav.goto(act.split('?', 2)[0] + '?' + qs);
		return false;
	});
	tr_mouseover();
}
