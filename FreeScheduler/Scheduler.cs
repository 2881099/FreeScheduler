using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace FreeScheduler
{
	/// <summary>
	/// 调度管理临时任务(一次性)、循环任务(存储落地)
	/// </summary>
	public class Scheduler : IDisposable
	{
		IdleBus _ib;
		int _quantityTempTask;
		int _quantityTask;
		internal int _quantityTaskRunning;
        /// <summary>
        /// 临时任务数量
        /// </summary>
        public int QuantityTempTask => _quantityTempTask;
		/// <summary>
		/// 循环任务数量
		/// </summary>
		public int QuantityTask => _quantityTask;
		/// <summary>
		/// 扫描线程间隔（默认值：200毫秒）
		/// </summary>
		public TimeSpan ScanInterval { get => _ib.ScanOptions.Interval; set => _ib.ScanOptions.Interval = value; }

		internal WorkQueue _wq;
        internal ITaskHandler _taskHandler;
        internal ITaskIntervalCustomHandler _taskIntervalCustomHandler;
        internal ConcurrentDictionary<string, TaskInfo> _tasks = new ConcurrentDictionary<string, TaskInfo>();
		internal ClusterContext _clusterContext;
		public string ClusterId => _clusterContext?.ClusterId;
		public ClusterOptions ClusterOptions => _clusterContext?.Options;
		/// <summary>
		/// 时区
		/// </summary>
		public TimeSpan TimeOffset { get; }
		internal DateTime GetDateTime() => DateTime.UtcNow.Add(TimeOffset);
		internal static int GetJsTime() => (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		internal Func<TaskInfo, bool> _ifLog = null;

        #region Dispose
        ~Scheduler() => Dispose();
		bool isdisposed = false;
		object isdisposedLock = new object();
		public void Dispose()
		{
			if (isdisposed) return;
			lock (isdisposedLock)
			{
				if (isdisposed) return;
				isdisposed = true;
			}
			_ib?.Dispose();
			_wq?.Dispose();
			_tasks?.Clear();
			Interlocked.Exchange(ref _quantityTempTask, 0);
			Interlocked.Exchange(ref _quantityTask, 0);
			(_taskHandler as IDisposable)?.Dispose();
		}
		#endregion

		[Obsolete("请使用最新的 var scheduler = new FreeSchedulerBuilder().OnExecuting(..).Build() 方式创建")]
		public Scheduler(ITaskHandler taskHandler) : this(taskHandler, null, null, TimeSpan.Zero, true, null) { }
		[Obsolete("请使用最新的 var scheduler = new FreeSchedulerBuilder().OnExecuting(..).UseCustomInterval(..).Build() 方式创建")]
		public Scheduler(ITaskHandler taskHandler, ITaskIntervalCustomHandler taskIntervalCustomHandler) : this(taskHandler, taskIntervalCustomHandler, null, TimeSpan.Zero, true, null) { }
		internal Scheduler(ITaskHandler taskHandler, ITaskIntervalCustomHandler taskIntervalCustomHandler, ClusterContext culsterContext, TimeSpan timeOffset, bool autoLoad, Func<TaskInfo, bool> ifLog)
		{
			if (taskHandler == null) throw new ArgumentNullException("taskHandler 参数不能为 null");
			_taskHandler = taskHandler;
			_taskIntervalCustomHandler = taskIntervalCustomHandler;
			_clusterContext = culsterContext;
			TimeOffset = timeOffset;

            _ib = new IdleBus();
			_ib.ScanOptions.Interval = TimeSpan.FromMilliseconds(200);
			_ib.ScanOptions.BatchQuantity = 100000;
			_ib.ScanOptions.BatchQuantityWait = TimeSpan.FromMilliseconds(100);
			_ib.ScanOptions.QuitWaitSeconds = 20;
			_ib.Notice += new EventHandler<IdleBus<IDisposable>.NoticeEventArgs>((s, e) =>
			{
			});
			_wq = new WorkQueue(30);
			_ifLog = ifLog;

			if (_clusterContext != null)
			{
                _wq.Enqueue(() =>
                {
                    _clusterContext.Init(this);
                    if (autoLoad) LocalLoadTask(1);
                });
			}
			else
            {
                if (autoLoad) LocalLoadTask(1);
            }

			void LocalLoadTask(int pageNumber)
			{
				if (!autoLoad) return;
                var tasks = _taskHandler.LoadAll(pageNumber, 100);
				var tasksCount = tasks.Count();
                foreach (var task in tasks)
                {
                    if (task.Interval == TaskInterval.Custom && taskIntervalCustomHandler == null) continue;
                    AddTaskPriv(task, false);
                }
                if (tasksCount < 100) return;
                AddTempTask(TimeSpan.FromSeconds(1), () => LocalLoadTask(pageNumber + 1), false);
            }
        }

		/// <summary>
		/// 临时任务（程序重启会丢失）
		/// </summary>
		/// <param name="timeout"></param>
		/// <param name="handle"></param>
		/// <returns></returns>
		public string AddTempTask(TimeSpan timeout, Action handle) => AddTempTask(timeout, handle, true);
        internal string AddTempTask(TimeSpan timeout, Action handle, bool cluster)
        {
            var id = Guid.NewGuid().ToString();
			if (!cluster) id = $"system_{id}";
			var bus = new IdleTimeout(() =>
            {
                if (isdisposed) return;
                if (_ib.TryRemove(id) == false) return;
                Interlocked.Decrement(ref _quantityTempTask);
				if (handle != null)
				{
					if (cluster && _clusterContext?.IsOffline() == true) return;
					_wq.Enqueue(handle);
				}
                if (cluster) _clusterContext?.Remove(id, nameof(AddTempTask));
            });
            if (_ib.TryRegister(id, () => bus, timeout))
            {
                _ib.Get(id);
                Interlocked.Increment(ref _quantityTempTask);
            }
            if (cluster) _clusterContext?.Register(id, nameof(AddTempTask));
            return id;
        }
        /// <summary>
        /// 删除临时任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveTempTask(string id)
		{
			if (_tasks.ContainsKey(id) == false && _ib.TryRemove(id))
			{
				Interlocked.Decrement(ref _quantityTempTask);
				_clusterContext?.Remove(id, nameof(AddTempTask));
				return true;
			}
			if (_clusterContext?.RemoteCall(id, nameof(AddTempTask), nameof(RemoveTempTask), out var result) == true) return result;
			return false;
		}
		/// <summary>
		/// 判断临时任务是否存在
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool ExistsTempTask(string id)
		{
			if (_tasks.ContainsKey(id) == false && _ib.Exists(id)) return true;
			if (_clusterContext?.RemoteCall(id, nameof(AddTempTask), nameof(ExistsTempTask), out var result) == true) return result;
			return false;
		}

		/// <summary>
		/// 添加循环执行的任务（秒）
		/// </summary>
		/// <param name="topic">名称</param>
		/// <param name="body">数据</param>
		/// <param name="round">循环次数，-1为永久循环</param>
		/// <param name="seconds">秒数</param>
		/// <returns></returns>
		public string AddTask(string topic, string body, int round, int seconds) => AddTaskPriv(topic, body, round, TaskInterval.SEC, string.Concat(seconds));
		/// <summary>
		/// 添加循环执行的任务（秒）<para></para>
		/// 可设置参数值 10,20,30 分别对每一轮进行设置定时秒数，例如：<para></para>
		/// round = 12<para></para>
		/// seconds = 60,60,60,60,60,120,120,120,120,120,1200,1200<para></para>
		/// Executing 事件可设置 Status 状态，在任意一轮中标记任务【完成】
		/// </summary>
		/// <param name="topic">名称</param>
		/// <param name="body">数据</param>
		/// <param name="seconds">每一轮的定时秒数：10,20,30</param>
		/// <returns></returns>
		public string AddTask(string topic, string body, int[] seconds) => AddTaskPriv(topic, body, seconds.Length, TaskInterval.SEC, string.Join(",", seconds));
		/// <summary>
		/// 添加循环执行的任务（每天的什么时候执行）<para></para>
		/// 每天 expression UTC时间: "20:30:00"
		/// </summary>
		/// <returns></returns>
		public string AddTaskRunOnDay(string topic, string body, int round, string expression) => AddTaskPriv(topic, body, round, TaskInterval.RunOnDay, expression);
		/// <summary>
		/// 添加循环执行的任务（每个星期的什么时候执行）<para></para>
		/// 每周日 expression UTC时间: "0:20:30:00"<para></para>
		/// 每周六 expression UTC时间: "6:20:30:00"
		/// </summary>
		/// <returns></returns>
		public string AddTaskRunOnWeek(string topic, string body, int round, string expression) => AddTaskPriv(topic, body, round, TaskInterval.RunOnWeek, expression);
		/// <summary>
		/// 添加循环执行的任务（每个月的什么时候执行）<para></para>
		/// 每月1号: "1:20:30:00"<para></para>
		/// 每月最后1天："-1:20:30:00"<para></para>
		/// 每月倒数第2天："-2:20:30:00"<para></para>
		/// 注意：expression UTC时间
		/// </summary>
		/// <returns></returns>
		public string AddTaskRunOnMonth(string topic, string body, int round, string expression) => AddTaskPriv(topic, body, round, TaskInterval.RunOnMonth, expression);

		/// <summary>
		/// 添加 Custom 任务，new Scheduler(.., new YourCustomHandler())
		/// </summary>
		/// <returns></returns>
		public string AddTaskCustom(string topic, string body, string expression) => AddTaskPriv(topic, body, -1, TaskInterval.Custom, expression);

		string AddTaskPriv(string topic, string body, int round, TaskInterval interval, string argument)
		{
			var task = new TaskInfo
			{
				Id = $"{GetDateTime().ToString("yyyyMMdd")}.{Snowfake.Default.nextId()}",
				Topic = topic,
				Body = body,
				CreateTime = GetDateTime(),
				Round = round,
				Interval = interval,
				IntervalArgument = argument,
				CurrentRound = 0,
				ErrorTimes = 0,
				LastRunTime = new DateTime(1970, 1, 1),
				Status = TaskStatus.Running
			};
			AddTaskPriv(task, true);
			return task.Id;
		}
		internal void AddTaskPriv(TaskInfo task, bool isSave)
		{
			if (task.Status != TaskStatus.Running) return;
			if (task.Round != -1 && task.CurrentRound >= task.Round) return;
			if (task.Interval == TaskInterval.Custom && _taskIntervalCustomHandler == null) throw new Exception($"{task.Id} Custom 未设置 {nameof(FreeSchedulerBuilder.UseCustomInterval)}");
			if (_clusterContext != null && _clusterContext.Register(task.Id, nameof(AddTask)) == false) return;
			IdleTimeout bus = null;
			bus = new IdleTimeout(() =>
			{
				if (_ib.TryRemove(task.Id) == false && task.InternalFlag == 0) return;
				var currentRound = task.IncrementCurrentRound();
				var round = task.Round;
				if (task.Status != TaskStatus.Running) return;
				if (round != -1 && currentRound >= round)
				{
					if (_tasks.TryRemove(task.Id, out var old))
					{
						Interlocked.Decrement(ref _quantityTask);
						_clusterContext?.Remove(task.Id, nameof(AddTask));
					}
				}
				var remark = task.InternalFlag == 1 ? "[RunNowTask] 立刻运行任务（人工触发）" : "";
				if (_clusterContext?.IsOffline() == true) //被其他进程判定离线
				{
					if (_tasks.TryRemove(task.Id, out var old))
						Interlocked.Decrement(ref _quantityTask);
					return;
				}
				_wq.Enqueue(() =>
				{
					Interlocked.Increment(ref _quantityTaskRunning);
					try
					{
						var result = new TaskLog
						{
							CreateTime = GetDateTime(),
							TaskId = task.Id,
							Round = currentRound,
							Remark = remark,
							Success = true
						};
						var startdt = DateTime.UtcNow;
						var status = task.Status;
						try
						{
							task.RemarkValue = null;
							_taskHandler.OnExecuting(this, task);
						}
						catch (Exception ex)
						{
							task.IncrementErrorTimes();
							result.Exception = ex.InnerException == null ? $"{ex.Message}\r\n{ex.StackTrace}" : $"{ex.Message}\r\n{ex.StackTrace}\r\n\r\nInnerException: {ex.InnerException.Message}\r\n{ex.InnerException.StackTrace}";
							result.Success = false;
						}
						finally
						{
							if (string.IsNullOrWhiteSpace(task.RemarkValue) == false)
							{
								if (task.RemarkValue.StartsWith(", ")) task.RemarkValue = task.RemarkValue.Substring(2);
								result.Remark += string.IsNullOrWhiteSpace(result.Remark) ? task.RemarkValue : $", {task.RemarkValue}";
							}
							task.RemarkValue = null;
							if (status != task.Status) result.Remark = $"{result.Remark}{(string.IsNullOrEmpty(result.Remark) ? "" : ", ")}[Executing] 任务状态 `{status}` 已转为 `{task.Status}`";
							result.ElapsedMilliseconds = (long)DateTime.UtcNow.Subtract(startdt).TotalMilliseconds;
							task.LastRunTime = GetDateTime();
							if (round != -1 && currentRound >= round) task.Status = TaskStatus.Completed;
							_taskHandler.OnExecuted(this, task, result);
						}
						if (task.Status != TaskStatus.Running) return;
						if (_tasks.ContainsKey(task.Id) == false) return;
						if (round == -1 || currentRound < round)
						{
							var nextTimeSpan = LocalGetNextTimeSpan(task.Status, currentRound);
							if (nextTimeSpan != null && _ib.TryRegister(task.Id, () => bus, nextTimeSpan.Value))
								_ib.Get(task.Id);
						}
					}
					finally
					{
						Interlocked.Decrement(ref _quantityTaskRunning);
					}
				});
			});
			if (_tasks.TryAdd(task.Id, task))
			{
				if (isSave)
				{
					try
					{
						_taskHandler.OnAdd(task);
					}
					catch
					{
						_tasks.TryRemove(task.Id, out var old);
						_clusterContext?.Remove(task.Id, nameof(AddTask));
						throw;
					}
				}
				Interlocked.Increment(ref _quantityTask);
				var nextTimeSpan = LocalGetNextTimeSpan(task.Status, task.CurrentRound);
				if (nextTimeSpan != null && _ib.TryRegister(task.Id, () => bus, nextTimeSpan.Value))
					_ib.Get(task.Id);
			}

			TimeSpan? LocalGetNextTimeSpan(TaskStatus status, int curRound)
			{
				TimeSpan? nextTimeSpan = null;
				if (task.Interval == TaskInterval.Custom)
					nextTimeSpan = _taskIntervalCustomHandler.NextDelay(task);
				else
					nextTimeSpan = task.GetInterval(GetDateTime(), curRound);

				if (nextTimeSpan == null)
				{
					if (_tasks.TryRemove(task.Id, out var old))
					{
						Interlocked.Decrement(ref _quantityTask);
						_clusterContext?.Remove(task.Id, nameof(AddTask));
					}
					task.Status = TaskStatus.Completed;
					if (status != task.Status)
					{
						_taskHandler.OnExecuted(this, task, new TaskLog
						{
							CreateTime = GetDateTime(),
							TaskId = task.Id,
							Round = task.CurrentRound,
							Remark = $"[NextInterval] 任务状态 `{status}` 已转为 `{task.Status}`",
                            Success = true,
                        });
					}
					return null;
				}
				return nextTimeSpan;
			}
		}
		/// <summary>
		/// 删除循环任务
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool RemoveTask(string id)
		{
			if (_tasks.TryRemove(id, out var old))
			{
				Interlocked.Decrement(ref _quantityTask);
				_taskHandler.OnRemove(old);
				_clusterContext?.Remove(id, nameof(AddTask));
				return _ib.TryRemove(id, true);
			}
			if (_clusterContext?.RemoteCall(id, nameof(AddTask), nameof(RemoveTask), out var result) == true) return result;
			var task = _taskHandler.Load(id);
			if (task != null)
			{
				_taskHandler.OnRemove(task);
				_clusterContext?.Remove(id, nameof(AddTask));
				return true;
			}
			return _ib.TryRemove(id, true);
		}
		internal void CancelAllTask()
		{
			foreach (var id in _tasks.Keys)
			{
				if (_tasks.TryRemove(id, out var old))
				{
					Interlocked.Decrement(ref _quantityTask);
					_ib.TryRemove(id, true);
				}
			}
			foreach (var id in _ib.GetKeys())
			{
				if (id.StartsWith("system_") == false && _ib.TryRemove(id, true))
                    Interlocked.Decrement(ref _quantityTempTask);
			}
		}
		/// <summary>
		/// 判断循环任务是否存在
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool ExistsTask(string id)
		{
			if (_tasks.ContainsKey(id)) return true;
			if (_clusterContext?.RemoteCall(id, nameof(AddTask), nameof(ExistsTask), out var result) == true) return result;
			return false;
		}

		/// <summary>
		/// 查询正在运行中的循环任务
		/// </summary>
		/// <param name="where"></param>
		/// <returns></returns>
		public TaskInfo[] FindTask(Func<TaskInfo, bool> where) => _tasks.Values.Where(where).ToArray();

        /// <summary>
        /// 恢复已暂停的任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ResumeTask(string id)
		{
			var task = _taskHandler.Load(id);
			if (task == null) return false;
			if (task.Status != TaskStatus.Paused) return false;
			var status = task.Status;
			task.Status = TaskStatus.Running;
			_taskHandler.OnExecuted(this, task, new TaskLog
			{
				CreateTime = GetDateTime(),
				TaskId = task.Id,
				Round = task.CurrentRound,
				Remark = $"[ResumeTask] 任务状态 `{status}` 已转为 `{task.Status}`",
				Success = true,
			});
			AddTaskPriv(task, false);
			return true;
		}
		/// <summary>
		/// 暂停正在运行的任务
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool PauseTask(string id)
		{
			if (_tasks.TryRemove(id, out var task))
			{
				Interlocked.Decrement(ref _quantityTask);
				_clusterContext?.Remove(id, nameof(AddTask));
				var status = task.Status;
				task.Status = TaskStatus.Paused;
				if (status != task.Status)
				{
					_taskHandler.OnExecuted(this, task, new TaskLog
					{
						CreateTime = GetDateTime(),
						TaskId = task.Id,
						Round = task.CurrentRound,
						Remark = $"[PauseTask] 任务状态 `{status}` 已转为 `{task.Status}`",
                        Success = true,
                    });
				}
				return _ib.TryRemove(id, true);
			}
			if (_clusterContext?.RemoteCall(id, nameof(AddTask), nameof(PauseTask), out var result) == true) return result;
			return false;
		}
		/// <summary>
		/// 立刻运行任务（人工触发）
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool RunNowTask(string id)
		{
			if (_tasks.TryGetValue(id, out var task))
            {
				if (_ib.Exists(id) == false) return false; //正在触发
				task.InternalFlag = 1;
				try
				{
					return _ib.TryRemove(id, true); //立即触发
				}
				finally
				{
					task.InternalFlag = 0;
				}
			}
			if (_clusterContext?.RemoteCall(id, nameof(AddTask), nameof(RunNowTask), out var result2) == true) return result2;
			task = _taskHandler.Load(id);
			if (task != null)
			{
				var currentRound = task.IncrementCurrentRound();
				var result = new TaskLog
				{
					CreateTime = GetDateTime(),
					TaskId = task.Id,
					Round = currentRound,
					Remark = $"[RunNowTask] 立刻运行任务（人工触发）",
                    Success = true,
                };
				var startdt = DateTime.UtcNow;
				var status = task.Status;
				try
				{
					task.RemarkValue = null;
					_taskHandler.OnExecuting(this, task);
				}
				catch (Exception ex)
				{
					task.IncrementErrorTimes();
					result.Exception = ex.InnerException == null ? $"{ex.Message}\r\n{ex.StackTrace}" : $"{ex.Message}\r\n{ex.StackTrace}\r\n\r\nInnerException: {ex.InnerException.Message}\r\n{ex.InnerException.StackTrace}";
					result.Success = false;
				}
				finally
				{
                    if (string.IsNullOrWhiteSpace(task.RemarkValue) == false)
                    {
                        if (task.RemarkValue.StartsWith(", ")) task.RemarkValue = task.RemarkValue.Substring(2);
                        result.Remark += string.IsNullOrWhiteSpace(result.Remark) ? task.RemarkValue : $", {task.RemarkValue}";
                    }
                    task.RemarkValue = null;
                    if (status != task.Status) result.Remark = $"{result.Remark}{(string.IsNullOrEmpty(result.Remark) ? "" : ", ")}[Executing] 任务状态 `{status}` 已转为 `{task.Status}`";
					result.ElapsedMilliseconds = (long)DateTime.UtcNow.Subtract(startdt).TotalMilliseconds;
					task.LastRunTime = GetDateTime();
					_taskHandler.OnExecuted(this, task, result);
				}
				return true;
			}
			return false;
		}
	}
}
