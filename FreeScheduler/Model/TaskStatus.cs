using System;
using System.Collections.Generic;
using System.Text;

namespace FreeScheduler
{
	public enum TaskStatus
	{
		/// <summary>
		/// 正在运行，可使用 PauseTask 方法暂停任务
		/// </summary>
		Running,

		/// <summary>
		/// 暂停，可使用 ResumeTask 方法恢复为 Running
		/// </summary>
		Paused,

		/// <summary>
		/// 完成
		/// </summary>
		Completed
	}
}
