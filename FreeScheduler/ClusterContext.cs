using FreeRedis;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace FreeScheduler
{
    class ClusterContext
	{
        public string Name { get; } = Guid.NewGuid().ToString("n");
        Scheduler _scheduler { get; set; }
        RedisClient _redis { get; }

		public ClusterContext(Scheduler scheduler, RedisClient redis)
        {
			_scheduler = scheduler;
            _redis = redis;

            _redis.SubscribeList($"freescheduler_cluster_{Name}", msg =>
            {
                if (string.IsNullOrWhiteSpace(msg)) return;
                var args = msg.Split('|');
                switch (args[0])
                {
                    case nameof(Scheduler.RemoveTempTask):
                        {
                            var result = scheduler.RemoveTempTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.ExistsTempTask):
                        {
                            var result = scheduler.ExistsTempTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.RemoveTask):
                        {
                            var result = scheduler.RemoveTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.ExistsTask):
                        {
                            var result = scheduler.ExistsTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.PauseTask):
                        {
                            var result = scheduler.PauseTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.RunNowTask):
                        {
                            var result = scheduler.RunNowTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case "response":
                        if (_responseWait.TryGetValue(args[1], out var wait))
                        {
                            wait.Result = args[2];
                            wait.Wait.Set();
                        }
                        break;
                }
            });
        }

        public class ClusterResponseWait : IDisposable
        {
            public ManualResetEvent Wait { get; } = new ManualResetEvent(false);
            public string Result { get; set; }

            public void Dispose()
            {
                Wait.Close();
                Wait.Dispose();
            }
        }
        ConcurrentDictionary<string, ClusterResponseWait> _responseWait { get; } = new ConcurrentDictionary<string, ClusterResponseWait>();
        public bool RemoteCall(string id, string targetKey, string method, out bool result)
        {
            if (_redis != null)
            {
                var targetClusterName = _redis.Get($"freescheduler_cluster_{targetKey}_{id}");
                if (!string.IsNullOrWhiteSpace(targetClusterName) && targetClusterName != Name)
                {
                    var waitId = Guid.NewGuid().ToString("n");
                    using (var wait = new ClusterResponseWait())
                    {
                        if (_responseWait.TryAdd(waitId, wait))
                        {
                            _redis.LPush($"freescheduler_cluster_{targetClusterName}", $"{method}|{id}|{Name}|{waitId}");
                            if (!wait.Wait.WaitOne(TimeSpan.FromSeconds(10)))
                            {
                                _responseWait.TryRemove(waitId, out var _);
                                throw new TimeoutException($"Scheduler cluster {method}({id}) timeout");
                            }
                            result = wait.Result == "1";
                            return true;
                        }
                    }
                }
            }
            result = false;
            return false;
        }
		public bool Register(string id, string targetKey, int timeoutSeconds = 0)
		{
			return _redis.SetNx($"freescheduler_cluster_{targetKey}_{id}", Name, timeoutSeconds);
        }
		public void Remove(string id, string targetKey)
		{
            _redis.Del($"freescheduler_cluster_{targetKey}_{id}");
        }
    }
}
