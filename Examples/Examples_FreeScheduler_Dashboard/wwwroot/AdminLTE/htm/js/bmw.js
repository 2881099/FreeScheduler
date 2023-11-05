var bmwjs = typeof exports === 'undefined' ? (exports = {}) : exports;

(function() {
  var fs = typeof require === 'function' ? require('fs') : null;
  var path = typeof require === 'function' ? require('path') : null;
  if (typeof JSON === 'undefined') JSON = { stringify: function(str) { return '"' + String(str).replace(/"/g, '\\"').replace(/\r/g, '\\r').replace(/\n/g, '\\n') + '"'; } };
  var compiles = {};

  function getContextArg(context) {
    var argkeys = [];
    var argvalues = [];
    var argkey = '';
    for (var a in context) argkeys.push(a);
    argkeys = argkeys.sort();
    var argkeys_len = argkeys.length;
    for (var b = 0; b < argkeys_len; b++) {
      argvalues.push(context[argkeys[b]]);
      if (b > 0) argkey += ', ';
      argkey += argkeys[b];
    }
    return { argkeys: argkeys, argvalues: argvalues, argkey: argkey };
  }

  function include(view, context) {
    var carg = getContextArg(context);
    function func_exec(isnew) {
      var cv = compiles[view];
      if (isnew || typeof cv.exec[carg.argkey] !== 'function') {
        try {
          cv.exec[carg.argkey] = Function.apply(context,
            ['$BMW__dirname', '$BMW__lib'].concat(carg.argkeys)
              .concat([cv.exec['$BMW__handle']]));
        } catch (e1) {
          cv.exec[carg.argkey] = function(dirname, lib) {
            return '编译失败，请检查 ' + view + '\r\n' + (e1.message || JSON.stringify(e1));
          };
        }
      }
      if (isnew === 2) return;
      try {
        var ret = cv.exec[carg.argkey].apply(context,
          [cv.dirname, lib].concat(carg.argvalues));
        return ret;
      } catch (e1) {
        console.log(e1);
        return '运行错误，' + view + '\r\n' + (e1.message || JSON.stringify(e1));
      }
    }
    if (compiles[view]) {
      var cv = compiles[view];
      if (cv.exec['$BMW__handle_ok']) {
        var ret = func_exec(0);
        //检查内容是否修改，10秒检查一次
        var timeout = new Date().getTime() - cv.chktime;
        if (isNaN(timeout) || timeout > 10000) {
          cv.chktime = new Date().getTime();
          fs.stat(view, function(err, r) {
            if (!r) {
              cv.exec[carg.argkey] = function(dirname, lib) {
                return '文件不存在，或者无权限访问 ' + view;
              };
              return;
            }
            var mtime = r.mtime.getTime();
            if (cv.mtime !== mtime) {
              delete cv.exec;
              cv.exec = {};
              cv.mtime = mtime;
              cv.chktime = new Date().getTime();
              cv.exec[carg.argkey] = function(dirname, lib) {
                return '正在编译... ' + view;
              };
              fs.readFile(view, 'utf-8', function(err, content) {
                if (err)
                  return console.log('文件不存在，或者无权限访问 ' + view);
                var r = compile2(content);
                //fs.writeFile(view + '.js', r, { encoding: 'utf-8' });
                cv.exec['$BMW__handle_ok'] = 1;
                cv.exec['$BMW__handle'] = r;
                func_exec(2);
              });
            }
          });
        }
        return ret;
      }
    }
    var cv2 = compiles[view] = { dirname: path.dirname(view), exec: {} };
    var content = '';
    try { content = fs.readFileSync(view, 'utf-8'); } catch (e1) { content = '文件不存在，或者无权限访问 ' + view; }
    var r = compile2(content);
    //fs.writeFile(view + '.js', r, { encoding: 'utf-8' });
    cv2.exec['$BMW__handle_ok'] = 1;
    cv2.exec['$BMW__handle'] = r;
    return func_exec(1);
  };
  exports.renderFile = function(view, context) {
    //view = path.join(view); 请在调用 renderFile 之前格式化好 view
    return include(view, context).toString();
  };
  exports.render = function(text, context) {
    var carg = getContextArg(context);
    var source = compile2(text);
    if (typeof __dirname === 'undefined') __dirname = 'render';
    return Function.apply(context,
      ['$BMW__dirname', '$BMW__lib'].concat(carg.argkeys)
        .concat(source)).apply(context,
      [__dirname, lib].concat(carg.argvalues)).toString();
  };

  var compile2 = exports.compile2 = function(content) {
    var sb = ['var $BMW__this = this;\n\
var $BMW__sb = \'\';\n\
var $BMW__blocks = { toString : function() { return $BMW__sb; }, set__sb : function(sb) { $BMW__sb = sb; } };\n\
var $BMW__blocks_list = [];\n\
var $BMW__forc = null;\n\
function $BMW__exp(a) { return a===0?a:(a||\'\'); };\n\
function print(a) { $BMW__sb += $BMW__exp(a); };\n\
if (typeof $BMW__importAs === \'undefined\') $BMW__importAs = {};', '', '', '$BMW__sb += \''];
    var fori = [];
    var includes = 0;
    var extend = '';
    var codeTree = [];
    var bmw_tmpid = 0;

    var error = null;
    var throwError = function(msg) {
      error = 'return \'' + msg + '\';';
    }
    var codeTreeEnd = function(tag) {
      var ret = '';
      var pop = [];
      for (var a = codeTree.length - 1; a >= 0; a--) {
        var isbreak = false;
        switch (codeTree[a]) {
          case 'import':
          case 'include':
            //ret += '});';
            pop.push(1);
            break;
          case tag:
            pop.unshift(2);
            ret = '\';' + ret;
            isbreak = true;
            break;
          default:
            if (!isbreak && tag !== 'undefined') pop = [];
            isbreak = true;
        }
        if (isbreak) break;
      }
      if (pop.length === 0 && tag !== 'undefined')
        throwError('语法错误，{' + tag + '} ' + ' {/' + tag + '} 并没配对');
      while (pop.pop()) codeTree.pop();
      return ret;
    };
    //{miss}...{/miss}块内容将不被解析
    var tmp_content_arr = reg_split(content, /\{\/?miss\}/g);
    if (tmp_content_arr.length > 1) {
      sb.push('\'; var $BMW__MISS = []; ');
      var miss_len = 0;
      for (var a = 1; a < tmp_content_arr.length; a += 2) {
        sb.push('$BMW__MISS.push(' + JSON.stringify(tmp_content_arr[a]) + ');');
        tmp_content_arr[a] = '{#$BMW__MISS[' + miss_len++ + ']}';
      }
      sb.push('$BMW__sb += \'');
      content = tmp_content_arr.join('');
    }
    //扩展语法如 <div @if="表达式"></div>
    content = htmlSyntax(content, 3); //<div @if="表达式" @for="index 1,100"></div>
    //处理 {% %} 块js代码
    var rep_jsstr = function(str) {
      return str.replace(/\\/g, '\\\\')
        .replace(/'/g, '\\\'')
        .replace(/\r/g, '\\r')
        .replace(/\n/g, '\\n');
    };
    tmp_content_arr = reg_split(content, /(\{%|%\})/g);
    if (tmp_content_arr.length === 1) {
      content = rep_jsstr(content)
        .replace(/\{%/g, '{$BMW__CODE}')
        .replace(/%\}/g, '{/$BMW__CODE}');
    } else {
      tmp_content_arr[0] = rep_jsstr(tmp_content_arr[0]);
      for (var a = 1; a < tmp_content_arr.length; a += 4) {
        tmp_content_arr[a] = '{$BMW__CODE}';
        tmp_content_arr[a + 2] = '{/$BMW__CODE}';
        tmp_content_arr[a + 3] = rep_jsstr(tmp_content_arr[a + 3]);
      }
      content = tmp_content_arr.join('');
    }

    var cmd_reg = /\{(\$BMW__CODE|\/\$BMW__CODE|import\s+|module\s+|extends\s+|block\s+|include\s+|for\s+|if\s+|#|\/for|elseif|else|\/if|\/block|\/module)([^\}]*)\}/g;
    sb.push(content.replace(cmd_reg, function($0, $1, $2) {
      if (error) return $0;

      $1 = trim($1, ' ', '\t');
      $2 = $2.replace(/\\'/g, '\'');
      switch ($1) {
        case '$BMW__CODE':
          //{% print('这个块内可以编写js代码'); %}
          codeTree.push('$BMW__CODE');
          return '\';\n';
        case '/$BMW__CODE':
          if (codeTree[codeTree.length - 1] !== '$BMW__CODE') {
            throwError('编译出错，{% 与 %} 并没配对');
            return $0;
          }
          codeTree.pop();
          return ';\n\
$BMW__sb += \'';

        case 'include':
          //{include ../inc/header.html}
          includes++;
          codeTree.push('include');
          return '\' + $BMW__include.call(null, ' + JSON.stringify($2) + ', null) + \'';

        case 'import':
          //{import ../inc/module.html as mymodule}
          var retimport = '';
          $2.replace(/^([^\s]+)\s+as\s+([\w_]+)$/i, function($0, $1, $2) {
            retimport = '\';\n\
var ' + $2 + ' = {};\n\
(function() { var r = $BMW__include.call(null, ' + JSON.stringify($1) + ', ' + $2 + '); if (typeof r === \'string\') $BMW__sb += r; }).call(null);\n\
$BMW__sb += \'';
            includes++;
            codeTree.push('import');
          });
          if (retimport.length > 0) return retimport;
          return $0;

        case 'module':
          var rettemplate = '';
          $2.replace(/^([\w_]+)(\s+([\w_,]+))?$/i, function($0, $1, $2, $3) {
            rettemplate = '\';\n\
$BMW__importAs.' + $1 + ' = function(' + $3 + ') {\n\
	var $BMW__sb;\n\
	var print = function(a) { $BMW__sb += $BMW__exp(a); };\n\
	$BMW__sb = \'';
            codeTree.push('module');
          });
          if (rettemplate.length > 0) return rettemplate;
          return $0;

        case '/module':
          var endmodule = codeTreeEnd('module');
          if (endmodule.length === 0) return $0;
          return endmodule + '\n\
	return $BMW__sb;\n\
};\n\
$BMW__sb += \'';

        case 'extends':
          //{extends ../inc/layout.html}
          if (extend) return $0;
          extend = $2;
          return '';

        case 'block':
          codeTree.push('block');
          return '\';\n\
$BMW__blocks_list.push($BMW__blocks[' + JSON.stringify(trim($2, ' ', '\t')) + '] = [$BMW__sb.length, 0]);\n\
$BMW__sb += \'';

        case '/block':
          var endblock = codeTreeEnd('block');
          if (endblock.length === 0) return $0;
          return endblock + '\n\
var $BMW__tmp' + ++bmw_tmpid + ' = $BMW__blocks_list.pop();\n\
$BMW__tmp' + bmw_tmpid + '[1] = $BMW__sb.length - $BMW__tmp' + bmw_tmpid + '[0];\n\
$BMW__sb += \'';

        case '#':
          //{#user.username}
          if ($2.charAt(0) === '#') //{##a} 容错输出
            return '\' + (function(){var ret;try{ret=' + $2.substr(1) + ';}catch(e1){}return $BMW__exp(ret);}).call(null) + \'';
          return '\' + (' + $2 + ') + \'';

        case 'for':
          var retfor = '\';';
          if (fori.length === 0) {
            retfor += '\n\
$BMW__forc = {};';
          }
          var test = false;

          //{for item,index in array}
          //{for item,index in [1,2,3,4,item]}
          $2.replace(/^([\w_]+)\s*,?\s*([\w_]+)?\s+in\s+(.+)/i, function($0, $1, $2, $3) {
            $1 = trim($1, ' ', '\t');
            $2 = trim($2, ' ', '\t');
            retfor += '\n\
var $BMW__tmp' + ++bmw_tmpid + ' = ' + $3 + ';\n\
var $BMW__tmp' + ++bmw_tmpid + ' = $BMW__tmp' + (bmw_tmpid - 1) + '.length;\n\
for (var $BMW__tmp' + ++bmw_tmpid + ' = 0; $BMW__tmp' + bmw_tmpid + ' < $BMW__tmp' + (bmw_tmpid - 1) + '; $BMW__tmp' + bmw_tmpid + '++) {\n\
	var ' + $1 + ' = $BMW__forc.' + $1 + ' = $BMW__tmp' + (bmw_tmpid - 2) + '[$BMW__tmp' + bmw_tmpid + '];';
            if ($2) {
              retfor += '\n\
	var ' + $2 + ' = $BMW__forc.' + $2 + ' = $BMW__tmp' + bmw_tmpid + ';';
            }
            retfor += '\n\
	$BMW__sb += \'';
            test = true;
            codeTree.push('for');
            fori.push('Array.forEach');

            return $0;
          });
          if (test) return retfor;

          //{for key,item,index on jsonObject}
          $2.replace(/^([\w_]+)\s*,?\s*([\w_]+)?,?\s*([\w_]+)?\s+on\s+(.+)/i, function($0, $1, $2, $3, $4) {
            $1 = trim($1, ' ', '\t');
            $2 = trim($2, ' ', '\t');
            $3 = trim($3, ' ', '\t');
            if ($3)
              retfor += '\n\
var ' + $3 + ' = -1;';
            retfor += '\n\
var $BMW__tmp' + ++bmw_tmpid + ' = ' + $4 + ';\n\
for (var ' + $1 + ' in $BMW__tmp' + bmw_tmpid + ') {\n\
	$BMW__forc.' + $1 + ' = ' + $1 + ';';
            if ($2)
              retfor += '\n\
	var ' + $2 + ' = $BMW__forc.' + $2 + ' = $BMW__tmp' + bmw_tmpid + '[' + $1 + '];';
            if ($3)
              retfor += '\n\
	$BMW__forc.' + $3 + ' = ++' + $3 + ';';
            retfor += '\n\
	$BMW__sb += \'';
            test = true;
            codeTree.push('for');
            fori.push('JSON.forin');
            return $0;
          });
          if (test) return retfor;

          //{for a forstart,forend} 支持模板变量，保证forstart表达式中没有逗号
          $2.replace(/^([\w_]+)\s+([^,]+)\s*,\s*(.+)/i, function($0, $1, $2, $3) {
            $1 = trim($1, ' ', '\t');
            retfor += '\n\
var $BMW__tmp' + ++bmw_tmpid + ' = ' + $3 + ';\n\
var $BMW__tmp' + ++bmw_tmpid + ' = ' + $2 + ';\n\
while ($BMW__tmp' + bmw_tmpid + ' < $BMW__tmp' + (bmw_tmpid - 1) + ') {\n\
	var ' + $1 + ' = $BMW__forc.' + $1 + ' = $BMW__tmp' + bmw_tmpid + '++;\n\
	$BMW__sb += \'';
            test = true;
            codeTree.push('for');
            fori.push('for.a2b');
            return $0;
          });
          if (test) return retfor;
          return $0;

        case '/for':
          var endfor = codeTreeEnd('for');
          if (endfor.length === 0) return $0;
          fori.pop();
          return endfor + '\n\
}' + //(fori.pop() === 'Array.forEach' ? ');' : '') + 
            (fori.length <= 0 ? '\n$BMW__forc = null;' : '') + '\n\
$BMW__sb += \'';

        case 'if':
          //{if user.id === 0 || user.isadmin === true && user.point > 100}
          //(function(){var test=false;try{test=' + $2 + ';}catch(e1){};return test;}).call(null)
          codeTree.push('if');
          return '\';\n\
if (' + $2 + ') {\n\
	$BMW__sb += \'';

        case 'elseif':
          //{elseif user.id === 0 || user.isadmin === true && user.point > 100}
          (function() { var test = false; try { test = ' + $2 + '; } catch (e1) { }; return test; }).call(null)
          var endelseif = codeTreeEnd('if');
          if (endelseif.length === 0) return $0;
          codeTree.push('if');
          return endelseif + '\n\
} else if (' + $2 + ') {\n\
	$BMW__sb += \'';

        case 'else':
          var endelse = codeTreeEnd('if');
          if (endelse.length === 0) return $0;
          codeTree.push('if');
          return endelse + '\n\
} else {\n\
	$BMW__sb += \'';

        case '/if':
          var endif = codeTreeEnd('if');
          if (endif.length === 0) return $0;
          return endif + '\n\
}\n\
$BMW__sb += \'';
      }
      return $0;
    }));

    sb.push('\';');
    if (extend) {
      sb.push('\n\
var r = $BMW__lib.include($BMW__lib.path.join($BMW__dirname, ' + JSON.stringify(extend) + '), $BMW__this);\n\
if (!r) return \'\';\n\
if (typeof r === \'string\') return r;\n\
var rstr = r.toString();\n\
var rstr_changed = false;\n\
for (var a in $BMW__blocks)\n\
	if ($BMW__blocks[a].length === 2 && typeof $BMW__blocks[a][0] === \'number\' && typeof $BMW__blocks[a][1] === \'number\') {\n\
		var sb2 = $BMW__sb.substr($BMW__blocks[a][0], $BMW__blocks[a][1]);\n\
		if (r[a] && r[a].length === 2 && typeof r[a][0] === \'number\' && typeof r[a][1] === \'number\') {\n\
			for (var b in r)\n\
				if (r[b].length === 2 && typeof r[a][0] === \'number\' && r[b][0] > r[a][0])\n\
					r[b][0] = r[b][0] - r[a][1] + sb2.length;\n\
			rstr = rstr.substr(0, r[a][0]) + sb2 + rstr.substr(r[a][0] + r[a][1]);\n\
			r[a][1] = sb2.length;\n\
			rstr_changed = true;\n\
		}\n\
	}\n\
if (rstr_changed) r.set__sb(rstr);\n\
return r;');
    } else {
      sb.push('\n\
return $BMW__blocks;');
    }

    for (var z = 0; z < codeTree.length; z++) {
      if (codeTree[z] !== 'import' && codeTree[z] !== 'include') {
        throwError('编译出错，{' + codeTree[z] + '} 没有结束标记 {/' + codeTree[z] + '}');
        return false;
      }
    }
    //var endundefined = codeTreeEnd('undefined');
    //sb.push(endundefined);

    if (includes > 0) {
      sb[1] = '\n\
var $BMW__include = function(file, $BMW__importAs) {\n\
	var context_tmp = { };\n\
	for (var a in $BMW__this) context_tmp[a] = $BMW__this[a];\n\
	if (typeof $BMW__forc === \'object\') for (var a in $BMW__forc) context_tmp[a] = $BMW__forc[a];\n\
	if ($BMW__importAs) context_tmp.$BMW__importAs = $BMW__importAs;\n\
	var view = $BMW__lib.path.join($BMW__dirname, file);\n\
	return $BMW__lib.include(view, context_tmp);\n\
};';
    }
    return error || sb.join('')
      .replace(/\s*\$BMW__sb\s*\+=\s*'';\s*/g, '');
    //.replace(/\\/g, '\\\\');
  };

  var htmlSyntax = function(content, num) {
    while (num-- > 0) {
      var arr = reg_split(content, /<(\w+)\s+@(if|for|else)\s*="([^"]*)"/gi);
      if (arr.length === 1) break;
      for (var a = 1; a < arr.length; a += 4) {
        var tag = '<' + arr[a];
        var end = '</' + arr[a] + '>';
        var fc = 1;
        for (var b = a; fc > 0 && b < arr.length; b += 4) {
          if (b > a && arr[a].toLowerCase() === arr[b].toLowerCase()) fc++;
          var bpos = 0;
          while (true) {
            var fa = arr[b + 3].indexOf(tag, bpos);
            var fb = arr[b + 3].indexOf(end, bpos);
            if (b === a) {
              var z = arr[b + 3].indexOf("/>");
              if ((fb === -1 || z < fb) && z !== -1) {
                var y = arr[b + 3].substr(0, z + 2);
                if (!/<\/?\w+[^>]*>/.test(y))
                  fb = z - end.length + 2;
              }
            }
            if (fa === -1 && fb === -1) break;
            if (fa !== -1 && (fa < fb || fb == -1)) {
              fc++;
              bpos = fa + tag.length;
              continue;
            }
            if (fb !== -1) fc--;
            if (fc <= 0) {
              var a1 = arr[a + 1];
              var end3 = '{/' + a1 + '}';
              if (a1.toLowerCase() === 'else') {
                if (String(arr[a - 4 + 3]).replace(/\s+/g, '').slice(-5).toLowerCase() === '{/if}') {
                  var idx = arr[a - 4 + 3].lastIndexOf('{/if}');
                  arr[a - 4 + 3] = arr[a - 4 + 3].substr(0, idx) + arr[a - 4 + 3].substr(idx + 5);
                  //如果 @else="有条件内容"，则变换成 elseif 条件内容
                  if (arr[a + 2].replace(/\s+/g, '').length > 0) a1 = 'elseif';
                  end3 = '{/if}';
                } else {
                  arr[a] = '指令 @' + arr[a + 1] + '="' + arr[a + 2] + '" 没紧接着 if/else 指令之后，无效. <' + arr[a];
                  arr[a + 1] = arr[a + 2] = '';
                }
              }
              if (arr[a + 1].length > 0) {
                if (arr[a + 2].replace(/\s+/g, '').length > 0 || a1.toLowerCase() === 'else') {
                  arr[b + 3] = arr[b + 3].substr(0, fb + end.length) + end3 + arr[b + 3].substr(fb + end.length);
                  arr[a] = '{' + a1 + ' ' + arr[a + 2] + '}<' + arr[a];
                  arr[a + 1] = arr[a + 2] = '';
                } else {
                  arr[a] = '<' + arr[a];
                  arr[a + 1] = arr[a + 2] = '';
                }
              }
              break;
            }
            bpos = fb + end.length;
          }
        }
        if (fc > 0) {
          arr[a] = '不严谨的html格式，请检查 ' + arr[a] + ' 的结束标签, @' + arr[a + 1] + '="' + arr[a + 2] + '" 指令无效. <' + arr[a];
          arr[a + 1] = arr[a + 2] = '';
        }
      }
      if (arr.length > 0) content = arr.join('');
    }
    return content;
  };

  var ltrim = function() {
    var args = [].slice.call(arguments);
    var str = args[0] || '';
    args.shift();
    var reg = new RegExp('^(' + args.join('|') + ')', 'gi');
    return str.replace(reg, '');
  };
  var rtrim = function() {
    var args = [].slice.call(arguments);
    var str = args[0] || '';
    args.shift();
    var reg = new RegExp('(' + args.join('|') + ')$', 'gi');
    return str.replace(reg, '');
  };
  var trim = function() {
    arguments[0] = ltrim.apply(this, arguments);
    return rtrim.apply(this, arguments)
  };
  var reg_split = function(str, reg) {
    if (fs) return str.split(reg); //服务端的话直接使用 split
    //解决 ie6 8 和其他浏览器的 split 使用方法不兼容
    var ret = [];
    var exec = null;
    var idx = 0;
    while (exec = reg.exec(str)) {
      var idx2 = idx;
      idx = str.indexOf(exec[0], idx2);
      ret.push(str.substring(idx2, idx));
      for (var a = 1; a < exec.length; a++)
        ret.push(exec[a]);
      idx += exec[0].length;
    }
    if (ret.length > 0) ret.push(str.substr(idx));
    return ret.length ? ret : [str];
  };

  var lib = {
    path: path,
    JSON: JSON,
    include: include
  };
})();