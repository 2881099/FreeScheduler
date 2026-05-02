using System;

namespace FreeScheduler
{
	/// <summary>
	/// 持久化任务调度模式。
	/// </summary>
	public enum PersistentTaskMode
	{
		/// <summary>
		/// 待命，不加载也不触发新的持久化任务。
		/// </summary>
		Standby,

		/// <summary>
		/// 激活，正常加载和触发持久化任务。
		/// </summary>
		Active,

		/// <summary>
		/// 排空，不再接收新的持久化任务触发，但允许已经开始执行的任务自然结束。
		/// </summary>
		Draining
	}
}