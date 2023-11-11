using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FreeScheduler
{
    public class TaskInfo
	{
		/// <summary>
		/// 任务编号
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// 任务标题，可用于查询
		/// </summary>
		public string Topic { get; set; }
		/// <summary>
		/// 任务数据
		/// </summary>
		public string Body { get; set; }
		/// <summary>
		/// 任务执行多少轮，-1为永久循环
		/// </summary>
		public int Round { get; set; }
		/// <summary>
		/// 定时类型
		/// </summary>
		public TaskInterval Interval { get; set; }
		/// <summary>
		/// 定时参数值<para></para>
		/// Interval SEC 可设置参数值 10,20,30 分别对每一轮进行设置定时秒数，例如：<para></para>
		/// Round = 12<para></para>
		/// Interval = SEC<para></para>
		/// Argument = 60,60,60,60,60,120,120,120,120,120,1200,1200<para></para>
		/// Executing 事件可设置 Status 状态，在任意一轮中标记任务【完成】
		/// </summary>
		public string IntervalArgument { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime { get; set; }
		/// <summary>
		/// 最后运行时间
		/// </summary>
		public DateTime LastRunTime { get; set; }

		int _currentRound, _errorTimes;
		/// <summary>
		/// 当前运行到第几轮
		/// </summary>
		public int CurrentRound { get => _currentRound; set => _currentRound = value; }
		/// <summary>
		/// 错次数
		/// </summary>
		public int ErrorTimes { get => _errorTimes; set => _errorTimes = value; }

		/// <summary>
		/// 任务状态
		/// </summary>
		public TaskStatus Status { get; set; }

		internal int IncrementCurrentRound() => Interlocked.Increment(ref _currentRound);
		internal int IncrementErrorTimes() => Interlocked.Increment(ref _errorTimes);

		internal int InternalFlag { get; set; }
		internal string RemarkValue { get; set; }
		public void Remark(string remark) => RemarkValue = $"{RemarkValue}, {remark}";

        public TimeSpan? GetInterval(int curRound)
		{
			if (curRound > Round) curRound = Round;
			if (curRound < 0) curRound = 0;
			DateTime now = DateTime.UtcNow;
			DateTime curt = DateTime.MinValue;
			TimeSpan ts = TimeSpan.Zero;
			uint ww = 0, hh = 0, mm = 0, ss = 0;
			int dd;
			double interval = -1;
			switch (Interval)
			{
				case TaskInterval.SEC:
					var itvargs = IntervalArgument.Split(',').Select(a => a.Trim()).ToArray();
					var itvarg = itvargs[Math.Min(curRound, itvargs.Length - 1)];
					double.TryParse(itvarg, out interval);
					interval *= 1000;
					break;
				case TaskInterval.RunOnDay:
					List<string> hhmmss = new List<string>(string.Concat(IntervalArgument).Split(':'));
					if (hhmmss.Count == 3)
						if (uint.TryParse(hhmmss[0], out hh) && hh < 24 &&
							uint.TryParse(hhmmss[1], out mm) && mm < 60 &&
							uint.TryParse(hhmmss[2], out ss) && ss < 60)
						{
							curt = now.Date.AddHours(hh).AddMinutes(mm).AddSeconds(ss);
							ts = curt.Subtract(now);
							while (!(ts.TotalMilliseconds > 0))
							{
								curt = curt.AddDays(1);
								ts = curt.Subtract(now);
							}
							interval = ts.TotalMilliseconds;
						}
					break;
				case TaskInterval.RunOnWeek:
					string[] wwhhmmss = string.Concat(IntervalArgument).Split(':');
					if (wwhhmmss.Length == 4)
						if (uint.TryParse(wwhhmmss[0], out ww) && ww < 7 &&
							uint.TryParse(wwhhmmss[1], out hh) && hh < 24 &&
							uint.TryParse(wwhhmmss[2], out mm) && mm < 60 &&
							uint.TryParse(wwhhmmss[3], out ss) && ss < 60)
						{
							curt = now.Date.AddHours(hh).AddMinutes(mm).AddSeconds(ss);
							ts = curt.Subtract(now);
							while (!(ts.TotalMilliseconds > 0 && (int)curt.DayOfWeek == ww))
							{
								curt = curt.AddDays(1);
								ts = curt.Subtract(now);
							}
							interval = ts.TotalMilliseconds;
						}
					break;
				case TaskInterval.RunOnMonth:
					string[] ddhhmmss = string.Concat(IntervalArgument).Split(':');
					if (ddhhmmss.Length == 4)
						if (uint.TryParse(ddhhmmss[1], out hh) && hh < 24 &&
							uint.TryParse(ddhhmmss[2], out mm) && mm < 60 &&
							uint.TryParse(ddhhmmss[3], out ss) && ss < 60)
						{
							curt = new DateTime(now.Year, now.Month, 1).AddHours(hh).AddMinutes(mm).AddSeconds(ss);
							if (int.TryParse(ddhhmmss[0], out dd))
							{
								if (dd < 0) curt.AddMonths(1);
								curt.AddDays(dd);
							}
							ts = curt.Subtract(now);
							while (!(ts.TotalMilliseconds > 0))
							{
								curt = curt.AddMonths(1);
								ts = curt.Subtract(now);
							}
							interval = ts.TotalMilliseconds;
						}
					break;
                case TaskInterval.Custom:
					throw new Exception("请使用 Scheduler 对象获取自定义间隔值");
            }
			if (interval == 0) interval = 1000;
			return TimeSpan.FromMilliseconds(interval);
		}
	}
}
