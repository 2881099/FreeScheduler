using System;
using System.Collections.Generic;
using System.Text;

namespace FreeScheduler
{
	public class TaskLog
	{
		/// <summary>
		/// 任务编号
		/// </summary>
		public string TaskId { get; set; }
		/// <summary>
		/// 第几轮
		/// </summary>
		public int Round { get; set; }
		/// <summary>
		/// 耗时（毫秒）
		/// </summary>
		public long ElapsedMilliseconds { get; set; }
		/// <summary>
		/// 是否成功
		/// </summary>
		public bool Success { get; set; }
		/// <summary>
		/// 异常信息
		/// </summary>
		public string Exception { get; set; }
		/// <summary>
		/// 自定义备注
		/// </summary>
		public string Remark { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime { get; set; }
	}
}
