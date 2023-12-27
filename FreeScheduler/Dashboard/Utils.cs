#if Dashboard
using FreeSql.Internal.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FreeScheduler.Dashboard
{
	static class Utils
	{
		async public static Task<string> GetBodyRawText(HttpRequest req)
		{
			var charsetIndex = req.ContentType.IndexOf("charset=");
			var charset = Encoding.UTF8;
			if (charsetIndex != -1)
			{
				var charsetText = req.ContentType.Substring(charsetIndex + 8);
				charsetIndex = charsetText.IndexOf(';');
				if (charsetIndex != -1) charsetText = charsetText.Remove(charsetIndex);
				switch (charsetText.ToLower())
				{
					case "utf8":
					case "utf-8":
						break;
					default:
						charset = Encoding.GetEncoding(charsetText);
						break;
				}
			}
			req.Body.Position = 0;
			using (var ms = new MemoryStream())
			{
				await req.Body.CopyToAsync(ms);
				return charset.GetString(ms.ToArray());
			}
		}

		static Utils()
		{
            JsonSerializerSettings = new JsonSerializerSettings();
			JsonSerializerSettings.Converters.Add(new StringEnumConverter());
			JsonSerializerSettings.Converters.Add(new DateTimeConverter());
        }
		class DateTimeConverter : DateTimeConverterBase
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
				return null;
                //if (reader.TokenType != JsonToken.Integer)
                //    throw new Exception($"Unexpected token parsing date. Expected Integer, got {reader.TokenType}.");

                //var ticks = (long)reader.Value;

                //var date = new DateTime(1970, 1, 1);
                //date = date.AddSeconds(ticks);

                //return date;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
                if (value is DateTime || value is DateTime?)
                {
					writer.WriteValue(((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"));
					return;
     //               var epoc = new DateTime(1970, 1, 1);
     //               var delta = ((DateTime)value) - epoc;
     //               if (delta.TotalSeconds < 0)
     //                   throw new ArgumentOutOfRangeException("Unix epoc starts January 1st, 1970");
					//writer.WriteValue((long)delta.TotalSeconds);
                }
                else
                    throw new Exception("Expected date object value.");
            }
		}

		public static JsonSerializerSettings JsonSerializerSettings { get; private set; }
		public static string SerializeObject(object options) => JsonConvert.SerializeObject(options, JsonSerializerSettings);

        public static Task Jsonp(HttpContext context, object options)
		{
			string __callback = context.Request.HasFormContentType ? context.Request.Form["__callback"].ToString() : null;
			if (string.IsNullOrEmpty(__callback))
			{
				context.Response.ContentType = "text/json;charset=utf-8;";
				return context.Response.WriteAsync(SerializeObject(options));
			}
			else
			{
				context.Response.ContentType = "text/html;charset=utf-8";
				return context.Response.WriteAsync($"<script>top.{__callback}({SerializeObject(options)});</script>");
			}
		}
	}
}
#endif