#if Dashboard
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using FreeScheduler.Login.Model;

namespace FreeScheduler.Login.Dashboard
{
    public static class FreeSchedulerLoginUI
    {
        public static IApplicationBuilder UseFreeSchedulerLoginUI(this IApplicationBuilder app, string requestPathBase)
        {
            requestPathBase = requestPathBase.ToLower();
            if (requestPathBase.StartsWith("/") == false) requestPathBase = $"/{requestPathBase}";
            if (requestPathBase.EndsWith("/") == false) requestPathBase = $"{requestPathBase}/";

            app.Use(async (context, next) =>
            {
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
                    if (reqPath.StartsWith($"{requestPathBase}account/index"))
                    {
                        if (is301)
                        {
                            res.StatusCode = 301;
                            res.Headers["Location"] = location;
                            return;
                        }
                        await res.WriteAsync(LoginViews.Login.Replace("{0}account/login", $"{requestPathBase}account/login"));
                        return;
                    }
                    if (reqPath.StartsWith($"{requestPathBase}account/login"))
                    {
                        if (req.Method == "POST")
                        {
                            var username = req.Form["username"].FirstOrDefault();
                            var pwd = req.Form["pwd"].FirstOrDefault();
                            var freeSql = context.RequestServices.GetRequiredService<IFreeSql>();
                            var loginResult = freeSql.Select<User>().Where(a => a.UserName == username && a.Pwd == pwd).AnyAsync();
                            if (await loginResult)
                            {
                                // 写入Cookies
                                var claims = new List<Claim> {
                                    new Claim("userName",username)
                                };
                                await context.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme))); //Cookie 验证

                                res.Redirect(requestPathBase);
                                return;
                            }
                            else
                            {
                                await res.WriteAsync("Please login again The account or password is incorrect");
                                return;
                            }
                        }
                        res.Redirect($"{requestPathBase}account/index");
                        return;
                    }
                    if (reqPath.StartsWith($"{requestPathBase}account/logout"))
                    {
                        await context.SignOutAsync();
                        res.Redirect($"{requestPathBase}account/index");
                        return;
                    }
                    if (reqPath.StartsWith($"{requestPathBase}"))
                    {
                        // 验证Cookies
                        var schemes = context.RequestServices.GetRequiredService<IAuthenticationSchemeProvider>();
                        context.Features.Set((IAuthenticationFeature)new AuthenticationFeature
                        {
                            OriginalPath = context.Request.Path,
                            OriginalPathBase = context.Request.PathBase
                        });
                        var handlers = context.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
                        foreach (var authenticationScheme in await schemes.GetRequestHandlerSchemesAsync())
                        {
                            if (await handlers.GetHandlerAsync(context, authenticationScheme.Name) is IAuthenticationRequestHandler handlerAsync)
                            {
                                await handlerAsync.HandleRequestAsync();
                            }
                            else
                            {
                                res.Redirect($"{requestPathBase}account/index");
                                return;
                            }
                        }
                        var authenticateSchemeAsync = await schemes.GetDefaultAuthenticateSchemeAsync();
                        if (authenticateSchemeAsync != null)
                        {
                            var authenticateResult = await context.AuthenticateAsync(authenticateSchemeAsync.Name);
                            if (authenticateResult?.Principal != null)
                            {
                                context.User = authenticateResult.Principal;
                                var user = context.User;
                                if ((user?.Identity == null ? 1 : user.Identities.Any((i => i.IsAuthenticated))
                                        ? 0 : 1) != 0)
                                {
                                    res.Redirect($"{requestPathBase}account/index");
                                    return;
                                }
                            }
                            else
                            {
                                res.Redirect($"{requestPathBase}account/index");
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    await res.WriteAsync(ex.Message);
                    return;
                }
                await next();
            });

            return app;
        }

        public static IServiceCollection AddLogin(this IServiceCollection services)
        {
            // 注入Cookie认证
            services.AddAuthentication((option) =>
            {
                //设置默认项
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
            {
                option.Cookie.Name = "adCookie"; //设置存储用户登录信息（用户Token信息）的Cookie名称
                option.Cookie.HttpOnly = true; //设置存储用户登录信息（用户Token信息）的Cookie，无法通过客户端浏览器脚本(如JavaScript等)访问到
                option.ExpireTimeSpan = TimeSpan.FromDays(3); // 过期时间
                option.SlidingExpiration = true; // 是否在过期时间过半的时候，自动延期
            });

            return services;
        }
    }
}
#endif