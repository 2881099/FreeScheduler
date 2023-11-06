if (typeof $ === 'undefined') $ = jQuery;
$.ajaxSettings.dataType = 'json';

function isArray(obj) { return Object.prototype.toString.call(obj) === '[object Array]'; }
function request(name, defaultValue) { return qs_parse()[name] || defaultValue; }
function cint(str, defaultValue) { str = parseInt(str, 10); return isNaN(str) ? defaultValue || 0 : str; }
function _clone(obj) {
	var ret = {};
	if (typeof obj === 'undefined' || obj === null) return ret;
	for (var a in obj) {
		if (isArray(obj[a])) {
			ret[a] = [];
			for (var b = 0; b < obj[a].length; b++) ret[a].push(obj[a][b]);
			continue;
		}
		ret[a] = obj[a];
	}
	return ret;
}

String.prototype.trim = function () { return this.ltrim().rtrim(); }
String.prototype.ltrim = function () { return this.replace(/^\s+(.*)/g, '$1'); }
String.prototype.rtrim = function () { return this.replace(/([^ ]*)\s+$/g, '$1'); }
//中文按2位算
String.prototype.getLength = function () { return this.replace(/([\u0391-\uFFE5])/ig, '11').length; }
String.prototype.left = function (len, endstr) {
	if (len > this.getLength()) return this;
	var ret = this.replace(/([\u0391-\uFFE5])/ig, '$1\0')
	  .substr(0, len).replace(/([\u0391-\uFFE5])\0/ig, '$1');
	if (endstr) ret = ret.concat(endstr);
	return ret;
}
String.prototype.format = function () {
	var val = this.toString();
	for (var a = 0 ; a < arguments.length ; a++) val = val.replace(new RegExp("\\{" + a + "\\}", "g"), arguments[a]);
	return val;
}
var __padleftright = function (str, len, padstr, isleft) {
	str = str || ' ';
	padstr = padstr || '';
	var ret = [];
	for (var a = 0; a < len - str.length; a++) ret.push(padstr);
	if (isleft) ret.unshift(this)
	else ret.push(this);
	return ret.join('');
}
// 'a'.padleft(3, '0') => '00a'
String.prototype.padleft = function (len, padstr) {
	return __padleftright(this, len, padstr, 1);
};
// 'a'.padright(3, '0') => 'a00'
String.prototype.padright = function (len, padstr) {
	return __padleftright(this, len, padstr, 0);
};
Function.prototype.toString2 = function () {
	var str = this.toString();
	str = str.substr(str.indexOf('/*') + 2, str.length);
	str = str.substr(0, str.lastIndexOf('*/'));
	return str;
};
Number.prototype.round = function (r) {
	r = typeof (r) == 'undefined' ? 1 : r;
	var rv = String(this);
	var io = rv.indexOf('.');
	var ri = io == -1 ? '' : rv.substr(io + 1, r);
	var le = io == -1 ? (rv + '.') : rv.substr(0, io + 1 + r);
	for (var a = ri.length ; a < r ; a++) le += '0';
	return le;
};

function getObjectURL(file) {
	var url = null;
	if (window.createObjectURL != undefined) { // basic
		url = window.createObjectURL(file);
	} else if (window.URL != undefined) { // mozilla(firefox)
		url = window.URL.createObjectURL(file);
	} else if (window.webkitURL != undefined) { // webkit or chrome
		url = window.webkitURL.createObjectURL(file);
	}
	return url;
}

var qs_parse_cache = {};
function qs_parse(str) {
	str = str || location.search;
	if (str.charAt(0) === '?') str = str.substr(1, str.length);
	if (qs_parse_cache[str]) return qs_parse_cache[str];
	var qs = {};
	var y = str.split('&');
	for (var a = 0; a < y.length; a++) {
		var x = y[a].split('=', 2);
		if (x[0] === '') continue;
		var x0 = url_decode(x[0]);
		if (!qs[x0]) qs[x0] = '';
		qs[x0] += url_decode(x[1] || '') + '\r\n';
	}
	//转换数组，去重
	for (var a in qs) {
		qs[a] = qs[a].substr(0, qs[a].length - 2);
		if (qs[a].indexOf('\r\n') === -1) continue;
		var t1 = qs[a].split('\r\n');
		var t2 = {};
		qs[a] = [];
		for (var b = 0; b < t1.length; b++) {
			if (t2[t1[b]]) continue;
			t2[t1[b]] = true;
			qs[a].push(t1[b]);
		}
	}
	return qs;
}
function qs_parseByUrl(url) {
	url = url || location.href;
	url = url.split('?', 2);
	if (url.length === 1) url.push('');
	return qs_parse(url[1]);
}
function qs_stringify(query) {
	var ret = [];
	for (var a in query) {
		var z = url_encode(a); if (z === '') continue;
		if (isArray(query[a]) == false) {
			ret.push(z + '=' + url_encode(query[a]));
			continue;
		}
		for (var b = 0; b < query[a].length; b++)
			ret.push(z + '=' + url_encode(query[a][b]));
	}
	return ret.join('&');
}
function join_url(url1, url2) {
	var ds = [];
	if (url2 === '')
		ds = url1.split('/');
	else if (url2.substr(0, 1) === '?') {
		ds = url1.split('?', 2)[0].split('/');
		ds[ds.length - 1] += url2;
	}
	else {
		ds = url1.split('?', 2)[0].split('/');
		ds.pop();
		ds = ds.concat(url2.split('/'));
	}
	var ret = [];
	var nd = 0;
	while (true) {
		var d = ds.pop();
		if (d == null) break;
		if (d === '.') continue;
		if (d === '..') {
			nd++;
			continue;
		}
		if (nd > 0) {
			nd--;
			continue;
		}
		ret.unshift(d);
	}
	return ret.join('/').replace(/\/\//g, '/');
}

var mapSeries = function (items, fn, callback) {
	var rs = [];
	var func = function () {
		var item = items.pop();
		if (item) return fn(item, function (err, r) {
			if (err) return callback(err, rs);
			rs.push(r);
			return func.call(null);
		});
		else return callback(null, rs);
	};
	func.call(null);
};

var url_encode = function (str) {
	return encodeURIComponent(str)
	  .replace(/ /gi, '+')
	  .replace(/~/gi, '%7e')
	  .replace(/'/gi, '%26%2339%3b');
};
var url_decode = function (str) {
	str = String(str).replace(/%26%2339%3b/gi, '\'');
	return decodeURIComponent(str)
	  .replace(/\+/gi, ' ')
	  .replace(/%7e/gi, '~');
};
String.prototype.htmlencode = function () {
	return this
	  .replace(/&/g, '&amp;')
	  .replace(/</g, '&lt;')
	  .replace(/>/g, '&gt;')
	  .replace(/ /g, '&nbsp;')
	  .replace(/"/g, '&quot;');
};
String.prototype.htmldecode = function () {
	return this
	  .replace(/&quot;/gi, '"')
	  .replace(/&lt;/gi, '<')
	  .replace(/&gt;/gi, '>')
	  .replace(/&nbsp;/gi, ' ')
	  .replace(/&/g, '&amp;');
};

/**  
* UTF16和UTF8转换对照表  
* U+00000000 – U+0000007F   0xxxxxxx  
* U+00000080 – U+000007FF   110xxxxx 10xxxxxx  
* U+00000800 – U+0000FFFF   1110xxxx 10xxxxxx 10xxxxxx  
* U+00010000 – U+001FFFFF   11110xxx 10xxxxxx 10xxxxxx 10xxxxxx  
* U+00200000 – U+03FFFFFF   111110xx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx  
* U+04000000 – U+7FFFFFFF   1111110x 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx  
*/
var base64 = {
	// 转码表  
	table: [
	  'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
	  'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
	  'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
	  'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
	  'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
	  'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
	  'w', 'x', 'y', 'z', '0', '1', '2', '3',
	  '4', '5', '6', '7', '8', '9', '+', '/'
	],
	UTF16ToUTF8: function (str) {
		var res = [], len = str.length;
		for (var i = 0; i < len; i++) {
			var code = str.charCodeAt(i);
			if (code > 0x0000 && code <= 0x007F) {
				// 单字节，这里并不考虑0x0000，因为它是空字节  
				// U+00000000 – U+0000007F  0xxxxxxx  
				res.push(str.charAt(i));
			} else if (code >= 0x0080 && code <= 0x07FF) {
				// 双字节  
				// U+00000080 – U+000007FF  110xxxxx 10xxxxxx  
				// 110xxxxx  
				var byte11 = 0xC0 | ((code >> 6) & 0x1F);
				// 10xxxxxx  
				var byte21 = 0x80 | (code & 0x3F);
				res.push(
				  String.fromCharCode(byte11),
				  String.fromCharCode(byte21)
				  );
			} else if (code >= 0x0800 && code <= 0xFFFF) {
				// 三字节  
				// U+00000800 – U+0000FFFF  1110xxxx 10xxxxxx 10xxxxxx  
				// 1110xxxx  
				var byte1 = 0xE0 | ((code >> 12) & 0x0F);
				// 10xxxxxx  
				var byte2 = 0x80 | ((code >> 6) & 0x3F);
				// 10xxxxxx  
				var byte3 = 0x80 | (code & 0x3F);
				res.push(
				  String.fromCharCode(byte1),
				  String.fromCharCode(byte2),
				  String.fromCharCode(byte3)
				  );
			} else if (code >= 0x00010000 && code <= 0x001FFFFF) {
				// 四字节  
				// U+00010000 – U+001FFFFF  11110xxx 10xxxxxx 10xxxxxx 10xxxxxx  
			} else if (code >= 0x00200000 && code <= 0x03FFFFFF) {
				// 五字节  
				// U+00200000 – U+03FFFFFF  111110xx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx  
			} else /** if (code >= 0x04000000 && code <= 0x7FFFFFFF)*/ {
				// 六字节  
				// U+04000000 – U+7FFFFFFF  1111110x 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx  
			}
		}

		return res.join('');
	},
	UTF8ToUTF16: function (str) {
		var res = [], len = str.length;
		var i = 0;
		for (var i = 0; i < len; i++) {
			var code = str.charCodeAt(i);
			// 对第一个字节进行判断  
			if (((code >> 7) & 0xFF) == 0x0) {
				// 单字节  
				// 0xxxxxxx  
				res.push(str.charAt(i));
			} else if (((code >> 5) & 0xFF) == 0x6) {
				// 双字节  
				// 110xxxxx 10xxxxxx  
				var code2 = str.charCodeAt(++i);
				var byte1 = (code & 0x1F) << 6;
				var byte2 = code2 & 0x3F;
				var utf16 = byte1 | byte2;
				res.push(String.fromCharCode(utf16));
			} else if (((code >> 4) & 0xFF) == 0xE) {
				// 三字节  
				// 1110xxxx 10xxxxxx 10xxxxxx  
				var code22 = str.charCodeAt(++i);
				var code33 = str.charCodeAt(++i);
				var byte12 = (code << 4) | ((code22 >> 2) & 0x0F);
				var byte22 = ((code22 & 0x03) << 6) | (code33 & 0x3F);
				utf16 = ((byte12 & 0x00FF) << 8) | byte22
				res.push(String.fromCharCode(utf16));
			} else if (((code >> 3) & 0xFF) == 0x1E) {
				// 四字节  
				// 11110xxx 10xxxxxx 10xxxxxx 10xxxxxx  
			} else if (((code >> 2) & 0xFF) == 0x3E) {
				// 五字节  
				// 111110xx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx  
			} else /** if (((code >> 1) & 0xFF) == 0x7E)*/ {
				// 六字节  
				// 1111110x 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx 10xxxxxx  
			}
		}

		return res.join('');
	},
	encode: function (str) {
		if (!str) {
			return '';
		}
		var utf8 = this.UTF16ToUTF8(str); // 转成UTF8  
		var i = 0; // 遍历索引  
		var len = utf8.length;
		var res = [];
		while (i < len) {
			var c1 = utf8.charCodeAt(i++) & 0xFF;
			res.push(this.table[c1 >> 2]);
			// 需要补2个=  
			if (i == len) {
				res.push(this.table[(c1 & 0x3) << 4]);
				res.push('==');
				break;
			}
			var c2 = utf8.charCodeAt(i++);
			// 需要补1个=  
			if (i == len) {
				res.push(this.table[((c1 & 0x3) << 4) | ((c2 >> 4) & 0x0F)]);
				res.push(this.table[(c2 & 0x0F) << 2]);
				res.push('=');
				break;
			}
			var c3 = utf8.charCodeAt(i++);
			res.push(this.table[((c1 & 0x3) << 4) | ((c2 >> 4) & 0x0F)]);
			res.push(this.table[((c2 & 0x0F) << 2) | ((c3 & 0xC0) >> 6)]);
			res.push(this.table[c3 & 0x3F]);
		}

		return res.join('');
	},
	decode: function (str) {
		if (!str) {
			return '';
		}

		var len = str.length;
		var i = 0;
		var res = [];

		while (i < len) {
			var code1 = this.table.indexOf(str.charAt(i++));
			var code2 = this.table.indexOf(str.charAt(i++));
			var code3 = this.table.indexOf(str.charAt(i++));
			var code4 = this.table.indexOf(str.charAt(i++));

			var c1 = (code1 << 2) | (code2 >> 4);
			var c2 = ((code2 & 0xF) << 4) | (code3 >> 2);
			var c3 = ((code3 & 0x3) << 6) | code4;

			res.push(String.fromCharCode(c1));

			if (code3 != 64) {
				res.push(String.fromCharCode(c2));
			}
			if (code4 != 64) {
				res.push(String.fromCharCode(c3));
			}

		}

		return this.UTF8ToUTF16(res.join(''));
	}
};

var ndialog = {
	alert: function (msg) {
		clearTimeout(ndialog.alert.interval);
		var args = [].slice.call(arguments, 1);
		var closeTime;
		var callback;
		var url;
		for (var a = 0; a < args.length; a++) {
			switch (typeof args[a]) {
				case 'number':
					closeTime = args[a];
					break;
				case 'function':
					callback = args[a];
					break;
				case 'string':
					url = args[a];
					break;
			}
		}
		closeTime = closeTime || 3;
		var dg = dialog('ndialog-alert', 'Notice', msg);
		dg.onclose = function () {
			if (callback) callback();
			if (url) location.href = url;
		};
		var func = function () {
			dg.subject.innerHTML = 'closing...&nbsp;' + closeTime + '&nbsp;sec';
			if (closeTime-- <= 0) return dg.close();
			ndialog.alert.interval = setTimeout(func, 1000);
		};
		func();
		return dg;
	}
};

function extractobj(obj) {
	var parms = Array.prototype.slice.call(arguments, 1);
	parms.push('span');
	for (var a = 0; a < parms.length; a++) {
		var ts = obj.getElementsByTagName(parms[a]);
		for (var b = 0; b < ts.length; b++) if (ts[b].getAttribute('extract')) obj[ts[b].getAttribute('extract')] = ts[b];
	}
}

function dialog(id, subject, content) {
	var dg = document.getElementById(id);
	if (!dg) {
		dg = document.createElement('div');
		dg.id = id;
		dg.className = 'dialog_normal';
		dg.innerHTML = (function () {/*
<style type="text/css">
#dialog2_mask_id{z-index:1000000;width:100%;position:absolute;top:0px;left:0px;background:#aaa;filter:progid:DXImageTransform.Microsoft.Alpha(opacity=40);-moz-opacity:0.40;opacity:0.40;}
.dialog_normal {position:absolute;z-index:2000000;background:#fff;}
.dialog_normal div.dialog_normal_table {font-size:14px;margin-bottom:0px;border:2px solid #bbb;}
.dialog_normal div.dialog_normal_table dl.lr {font-weight:bold;height:24px;line-height:24px;padding:4px 0px 0px 6px;}
.dialog_normal div.dialog_normal_table dl.lr dt {float:left;color:black;font-weight:bold;margin:0px;padding:0px;}
.dialog_normal div.dialog_normal_table dl.lr dd {float:right;margin:0px;padding:0px;}
#ndialog-alert {width:430px;}
#ndialog-alert div.dialog_normal_content {padding:50px 24px 50px 24px;font-size:16px;line-height:24px;}
</style>
<div class="dialog_normal_table">
  <dl class="lr" style="cursor:pointer;">
    <dt extract="subject"></dt>
    <dd><span style="text-align:center;background:#fff;padding:0px 3px 0px 3px;margin-right:6px;border:1px solid #ccc;cursor:pointer;color:black;">х</span></dd>
  </dl>
  <div class="dialog_normal_content" extract="content"></div>
  <div class="dialog_normal_footer" extract="footer">
    
  </div>
</div>
    */}).toString2();
		extractobj(dg, 'dt', 'div');
		document.getElementById('yxq-div').appendChild(dg);
	}
	dg.subject.innerHTML = subject || '&nbsp;';
	dg.content.innerHTML = content || '<div style="padding:30px;text-align:center;"><img src="/images/yxq/ajax-loader-tr.gif"/></div>';
	dg.style.display = '';

	//dg.style.top = (document.body.clientHeight - dg.offsetHeight) / 2 + 'px';
	//dg.style.left = (document.body.offsetWidth - dg.offsetWidth - document.body.scrollLeft) / 2 + 'px';
	var top = (document.body.scrollTop || document.documentElement.scrollTop) + (document.documentElement.clientHeight - dg.offsetHeight) / 2 - 100;
	var left = (document.body.scrollLeft || document.documentElement.scrollLeft) + (document.documentElement.clientWidth - dg.offsetWidth) / 2;
	dg.style.top = top + 'px';
	dg.style.left = left + 'px';

	//dg.subject.parentNode.style.display = 'none';
	dg.close = dg.subject.onclick = dg.subject.parentNode.onclick = function () {
		dg.style.display = 'none';
		if (dg.onclose) dg.onclose();
		return false;
	};
	return dg;
}

function dialog2(id, subject, content) {
	var mask_id = 'dialog2_mask_id';
	var mask = document.getElementById(mask_id);
	if (!mask) {
		mask = document.createElement('div');
		mask.id = mask_id;
		document.getElementById('yxq-div').appendChild(mask);
	}
	mask.style.height = document.body.offsetHeight + 'px';

	var dg = dialog(id, subject, content);
	dg.style.display = mask.style.display = '';

	function setpos() {
		if (dg.style.display != '') return;

		var top = (document.body.scrollTop || document.documentElement.scrollTop) + (document.documentElement.clientHeight - dg.offsetHeight) / 2 - 100;
		var left = (document.body.scrollLeft || document.documentElement.scrollLeft) + (document.documentElement.clientWidth - dg.offsetWidth) / 2;
		if (Math.abs(parseInt(dg.style.top.replace('px', ''), 10) - top) > 100) dg.style.top = top + 'px';
		if (Math.abs(parseInt(dg.style.left.replace('px', ''), 10) - left) > 100) dg.style.left = left + 'px';
		setTimeout(setpos, 100);
	}
	setpos();

	var bak__ss = document.getElementsByTagName('select');
	var bak__selects = [];
	for (var a = 0; a < bak__ss.length; a++) {
		bak__selects.push(bak__ss[a].style.visibility);
		bak__ss[a].style.visibility = 'hidden';
	}

	dg.close = mask.onclick = dg.subject.onclick = dg.subject.parentNode.onclick = function () {
		for (var a = 0; a < bak__ss.length; a++) {
			bak__ss[a].style.visibility = bak__selects[a];
		}
		dg.style.display = mask.style.display = 'none';
		if (dg.onclose) dg.onclose();
		return false;
	};

	return dg;
}

