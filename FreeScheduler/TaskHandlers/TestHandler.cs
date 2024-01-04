using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace FreeScheduler.TaskHandlers
{
    public class TestHandler : ITaskHandler
    {
        internal ConcurrentDictionary<string, TaskInfo> _memoryTasks = new ConcurrentDictionary<string, TaskInfo>();

        public IEnumerable<TaskInfo> LoadAll(int pageNumber, int pageSize) => _memoryTasks.Values
            .Where(a => a.Status == TaskStatus.Running && (a.Round < 0 || a.CurrentRound < a.Round))
            .OrderBy(a => a.Id)
            .Skip(Math.Max(0, pageNumber - 1) * pageSize)
            .Take(pageSize).ToList();
        public TaskInfo Load(string id) => _memoryTasks.TryGetValue(id, out var task) ? task : null;
        public void OnAdd(TaskInfo task)
        {
            _memoryTasks.TryAdd(task.Id, task);
        }
        public void OnRemove(TaskInfo task)
        {
            _memoryTasks.TryRemove(task.Id, out var _);
        }

		public virtual void OnExecutedExt(TaskInfo task, TaskLog result) { }
        public virtual void OnExecuted(Scheduler scheduler, TaskInfo task, TaskLog result)
        {
            if (task.Status == TaskStatus.Completed) OnRemove(task);
            try
            {
                OnExecutedExt(task, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {task.Topic} TestHandler.OnExecuted 错误：{ex.Message}");
            }
        }

        public virtual void OnExecuting(Scheduler scheduler, TaskInfo task)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {task.Topic} 被执行，还剩 {scheduler.QuantityTask} 个循环任务");
        }
    }
}
