using System;
using System.Collections.Generic;
using System.Text;

namespace FreeScheduler
{
	public enum TaskInterval
	{
		/// <summary>
		/// 按秒触发
		/// </summary>
		SEC = 1,

		/// <summary>
		/// 每天 什么时间 触发<para></para>
		/// 如：15:55:59<para></para>
		/// 每天15点55分59秒
		/// </summary>
		RunOnDay = 11,
		/// <summary>
		/// 每星期几 什么时间 触发<para></para>
		/// 如：2:15:55:59<para></para>
		/// 每星期二15点55分59秒
		/// </summary>
		RunOnWeek = 12,
        /// <summary>
        /// 每月第几天 什么时间 触发<para></para>
        /// 如：5:15:55:59<para></para>
        /// 每月第5天15点55分59秒<para></para>
        /// 如：-1:15:55:59<para></para>
        /// 每月倒数第1天15点55分59秒
        /// </summary>
        RunOnMonth = 13,

        /// <summary>
        /// 自定义触发，要求设置 UseCustomInterval
        /// </summary>
        Custom = 21
    }

	public interface ITaskIntervalCustomHandler
    {
		/// <summary>
		/// 获取下一次定时间隔，返回 null 时结束
		/// </summary>
		/// <param name="task">持久化任务对象</param>
		/// <returns></returns>
		TimeSpan? NextDelay(TaskInfo task);
    }
}
