using System;

namespace FreeScheduler
{
	/// <summary>
	/// 持久化任务运行时状态。
	/// </summary>
	public class PersistentTaskRuntimeState
	{
		/// <summary>
		/// 当前调度模式。
		/// </summary>
		public PersistentTaskMode Mode { get; set; }

		/// <summary>
		/// 当前已加载的持久化任务数量。
		/// </summary>
		public int LoadedTaskCount { get; set; }

		/// <summary>
		/// 当前正在执行中的持久化任务数量。
		/// </summary>
		public int RunningTaskCount { get; set; }

		/// <summary>
		/// 是否仍会接收新的持久化任务触发。
		/// </summary>
		public bool AcceptingNewTriggers { get; set; }

		/// <summary>
		/// 是否已经排空。
		/// </summary>
		public bool IsDrained => AcceptingNewTriggers == false && RunningTaskCount == 0;
	}
}