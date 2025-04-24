#if Dashboard
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FreeScheduler.Dashboard
{
	static class StaticFiles
	{

		public static Func<Stream> WwwrootStream { get; set; } = () => typeof(StaticFiles).GetTypeInfo().Assembly
			.GetManifestResourceStream("FreeScheduler.Dashboard.wwwroot.zip");

		public static IApplicationBuilder UseFreeAdminLteStaticFiles(this IApplicationBuilder app, string requestPathBase)
		{
			if (_isStaticFiles == false)
			{
				lock (_isStaticFilesLock)
				{
					if (_isStaticFiles == false)
					{
						var curPath = AppDomain.CurrentDomain.BaseDirectory;
                        //这里做了修改,增加了一层目录.主要是为了解决k8s中readOnlyRootFilesystem=true;
                        var zipPath = $"{curPath}/wwwzip/{Guid.NewGuid()}.zip";
						using (var zip = WwwrootStream())
						{
							//盘算wwwzip是否存在,不存在就创建
                            if (!Directory.Exists(System.IO.Path.GetDirectoryName(zipPath))) Directory.CreateDirectory(System.IO.Path.GetDirectoryName(zipPath));

                            using (var fs = File.Open(zipPath, FileMode.OpenOrCreate))
							{
								zip.CopyTo(fs);
								fs.Close();
							}
							zip.Close();
						}
						var wwwrootPath = Path.Combine(curPath, "FreeScheduler.Dashboard.wwwroot");
						if (Directory.Exists(wwwrootPath)) Directory.Delete(wwwrootPath, true);
						try
						{
							System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, wwwrootPath, Encoding.UTF8);
						}
						catch (Exception ex)
						{
							throw new Exception($"{nameof(FreeSchedulerUI.UseFreeSchedulerUI)} 错误，资源文件解压失败：{ex.Message}", ex);
						}
						finally
						{
							File.Delete(zipPath);
						}

						app.UseStaticFiles(new StaticFileOptions
						{
							RequestPath = requestPathBase.TrimEnd('/'),
							FileProvider = new PhysicalFileProvider(wwwrootPath)
						});

						_isStaticFiles = true;
					}
				}
			}

			return app;
		}
		static bool _isStaticFiles = false;
		static object _isStaticFilesLock = new object();
	}
}
#endif