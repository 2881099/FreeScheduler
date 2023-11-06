using System;
using System.Collections.Generic;
using System.Text;

namespace FreeScheduler.TaskHandlers
{
    public class TestHandler : ITaskHandler
    {
        public IEnumerable<TaskInfo> LoadAll(int offset, int limit) => new TaskInfo[0];
        public TaskInfo Load(string id) => null;
        public void OnAdd(TaskInfo task) { }
        public void OnRemove(TaskInfo task) { }
        public virtual void OnExecuted(Scheduler scheduler, TaskInfo task, TaskLog result) { }

        public virtual void OnExecuting(Scheduler scheduler, TaskInfo task)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {task.Topic} 被执行，还剩 {scheduler.QuantityTask} 个循环任务");
        }
    }
}
