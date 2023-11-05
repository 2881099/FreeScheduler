using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[JsonObject(MemberSerialization.OptIn)]
public partial class ApiResult : ContentResult
{
    /// <summary>
    /// 错误代码
    /// </summary>
    [JsonProperty("code")] public int Code { get; protected set; }
    /// <summary>
    /// 错误消息
    /// </summary>
    [JsonProperty("message")] public string Message { get; protected set; }

    public ApiResult() { }
    public ApiResult(int code, string message) => this.SetCode(code);

    public virtual ApiResult SetCode(int value) { this.Code = value; return this; }
    public virtual ApiResult SetCode(Enum value) { this.Code = Convert.ToInt32(value); this.Message = value.ToString(); return this; }
    public virtual ApiResult SetMessage(string value) { this.Message = value; return this; }

    #region form 表单 target=iframe 提交回调处理
    protected void Jsonp(ActionContext context)
    {
        string __callback = context.HttpContext.Request.HasFormContentType ? context.HttpContext.Request.Form["__callback"].ToString() : null;
        if (string.IsNullOrEmpty(__callback))
        {
            this.ContentType = "text/json;charset=utf-8;";
            this.Content = JsonConvert.SerializeObject(this);
        }
        else
        {
            this.ContentType = "text/html;charset=utf-8";
            this.Content = $"<script>top.{__callback}({GlobalExtensions.Json(null, this)});</script>";
        }
    }
    public override void ExecuteResult(ActionContext context)
    {
        Jsonp(context);
        base.ExecuteResult(context);
    }
    public override Task ExecuteResultAsync(ActionContext context)
    {
        Jsonp(context);
        return base.ExecuteResultAsync(context);
    }
    #endregion

    public static ApiResult Success => new ApiResult(0, "成功");
    public static ApiResult Failed => new ApiResult(99, "失败");
}

[JsonObject(MemberSerialization.OptIn)]
public partial class ApiResult<T> : ApiResult
{
    [JsonProperty("data")] public T Data { get; protected set; }

    public ApiResult() { }
    public ApiResult(int code) => this.SetCode(code);
    public ApiResult(string message) => this.SetMessage(message);
    public ApiResult(int code, string message) => this.SetCode(code).SetMessage(message);

    new public ApiResult<T> SetCode(int value) { this.Code = value; return this; }
    new public ApiResult<T> SetCode(Enum value) { this.Code = Convert.ToInt32(value); this.Message = value.ToString(); return this; }
    new public ApiResult<T> SetMessage(string value) { this.Message = value; return this; }
    public ApiResult<T> SetData(T value) { this.Data = value; return this; }

    new public static ApiResult<T> Success => new ApiResult<T>(0, "成功");
}

public static class GlobalExtensions
{
    public static object Json(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, object obj)
    {
        string str = JsonConvert.SerializeObject(obj);
        if (!string.IsNullOrEmpty(str)) str = Regex.Replace(str, @"<(/?script[\s>])", "<\"+\"$1", RegexOptions.IgnoreCase);
        if (html == null) return str;
        return html.Raw(str);
    }
}
