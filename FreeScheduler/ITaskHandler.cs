using System;
using System.Collections.Generic;
using System.Text;

namespace FreeScheduler
{
	public interface ITaskHandler
	{
		/// <summary>
		/// 加载正在运行中的任务（从持久化中加载）
		/// </summary>
		/// <returns></returns>
		IEnumerable<TaskInfo> LoadAll(int pageNumber = 1, int pageSize = 100);
		/// <summary>
		/// 加载单个任务（从持久化中加载）
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		TaskInfo Load(string id);

		/// <summary>
		/// 添加任务的时候触发（持久化）
		/// </summary>
		/// <param name="task"></param>
		void OnAdd(TaskInfo task);
		/// <summary>
		/// 删除任务的时候触发（持久化）
		/// </summary>
		/// <param name="task"></param>
		void OnRemove(TaskInfo task);

		/// <summary>
		/// 执行任务完成的时候触发（持久化）
		/// </summary>
		/// <param name="scheduler"></param>
		/// <param name="task"></param>
		/// <param name="result"></param>
		void OnExecuted(Scheduler scheduler, TaskInfo task, TaskLog result);
		/// <summary>
		/// 执行任务的时候触发
		/// </summary>
		/// <param name="scheduler"></param>
		/// <param name="task"></param>
		void OnExecuting(Scheduler scheduler, TaskInfo task);
	}
}
