using FreeRedis;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace FreeScheduler
{
    class ClusterContext
    {
        public string Name { get; private set; } = Guid.NewGuid().ToString("n");
        Scheduler _scheduler { get; set; }
        RedisClient _redis { get; }

        public ClusterContext(RedisClient redis)
        {
            _redis = redis;
        }
        internal void Init(Scheduler scheduler)
        {
            _scheduler = scheduler;
            _scheduler.AddTempTask(TimeSpan.FromSeconds(5), RefershAndOffline, false);
            _redis.SubscribeList($"freescheduler_cluster_{Name}", msg =>
            {
                if (string.IsNullOrWhiteSpace(msg)) return;
                var args = msg.Split('|');
                switch (args[0])
                {
                    case nameof(Scheduler.RemoveTempTask):
                        {
                            var result = _scheduler.RemoveTempTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.ExistsTempTask):
                        {
                            var result = _scheduler.ExistsTempTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.RemoveTask):
                        {
                            var result = _scheduler.RemoveTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.ExistsTask):
                        {
                            var result = _scheduler.ExistsTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.PauseTask):
                        {
                            var result = _scheduler.PauseTask(args[1]) ? 1 : 0;
                            _redis.LPush($"freescheduler_cluster_{args[2]}", $"response|{args[3]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.RunNowTask):
                        {
                            var result = _scheduler.RunNowTask(args[1]) ? 1 : 0;
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

        void RefershAndOffline()
        {
            var timestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            object timeoutResult = null;
            try
            {
                timeoutResult = _redis.Eval(@"if(redis.call('hexists','freescheduler_cluster_offline',ARGV[2])==1) then return '-1' end
redis.call('zadd','freescheduler_cluster',ARGV[1],ARGV[2])
local a=redis.call('zrangebyscore','freescheduler_cluster',0,ARGV[1]-30,'limit',0,1)
if(a and a[1]) then return {a[1],redis.call('hsetnx','freescheduler_cluster_offline',a[1],ARGV[1])} end
return nil", null, timestamp, Name);
            }
            finally
            {
                _scheduler.AddTempTask(TimeSpan.FromSeconds(5), RefershAndOffline, false);
            }
            if (timeoutResult == null) return;
            if (timeoutResult as string == "-1") //被其他进程判定离线
            {
                _scheduler.CancelAllTask();
                if (timestamp - _redis.HGet<int>("freescheduler_cluster_offline", Name) > 60 * 5)
                    this.Name = Guid.NewGuid().ToString("n") + "_renew"; //离线超过5分钟，取消本进程任务，重新生成 Name
                return;
            }
            var trobjs = timeoutResult as object[];
            if (trobjs.Length != 2 && trobjs[1]?.ToString() != "1") return; //只有一个进程获得 ReloadTask 权
            var timeoutName = trobjs[0]?.ToString();
            if (string.IsNullOrWhiteSpace(timeoutName)) return;
            _redis.ZRem("freescheduler_cluster", timeoutName);
            ReloadTask(timeoutName);
        }
        void ReloadTask(string name)
        {
            var regkey = $"freescheduler_cluster_register_{name}";
            try
            {
                foreach (var scan in _redis.ZScan(regkey, "*", 100))
                {
                    var taskIds = scan.Where(sr => sr.member.StartsWith("AddTask_")).Select(sr => sr.member.Substring(8)).ToArray(); //忽略内存任务 AddTempTask_
                    foreach (var taskId in taskIds)
                    {
                        var task = _scheduler._taskHandler.Load(taskId);
                        if (task == null) continue;
                        if (task.Status != TaskStatus.Running) continue;
                        if (task.Round != -1 && task.CurrentRound >= task.Round) continue;
                        if (task.Interval == TaskInterval.Custom && _scheduler._taskIntervalCustomHandler == null) continue;
                        _scheduler.AddTaskPriv(task, false);
                    }
                    using (var pipe = _redis.StartPipe())
                    {
                        pipe.Del(scan.Select(sr => $"freescheduler_cluster_{sr.member}").ToArray()); //sr.member = $"{targetKey}_{id}"
                        pipe.ZRem(regkey, scan.Select(sr => sr.member).ToArray());
                        pipe.EndPipe();
                    }
                    break; //数量较多时，延迟处理
                }
                if (_redis.ZCard(regkey) > 0)
                    _scheduler.AddTempTask(TimeSpan.FromMilliseconds(1_000), () => ReloadTask(name), false);
            }
            catch
            {
                _scheduler.AddTempTask(TimeSpan.FromMilliseconds(30_000), () => ReloadTask(name), false);
            }
        }

        public bool IsOffline()
        {
            var offline = _redis.HExists("freescheduler_cluster_offline", Name);
            return offline;
        }
        public bool Register(string id, string targetKey, int timeoutSeconds)
        {
            var timestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            var keys = new[] { $"freescheduler_cluster_{targetKey}_{id}", $"freescheduler_cluster_register_{Name}" };
            var result = timeoutSeconds > 0 ?
                _redis.Eval(@"if(redis.call('setnx',KEYS[1],ARGV[1]))then
redis.call('expire',KEYS[1],ARGV[4]) redis.call('zadd',KEYS[2],ARGV[2],ARGV[3]) return 1 else return 0 end", keys,
                    Name, timestamp, $"{targetKey}_{id}", timeoutSeconds)?.ToString() :

                _redis.Eval(@"if(redis.call('setnx',KEYS[1],ARGV[1]))then
redis.call('zadd',KEYS[2],ARGV[2],ARGV[3]) return 1 else return 0 end", keys,
                    Name, timestamp, $"{targetKey}_{id}")?.ToString();

            return result == "1";
        }
        public void Remove(string id, string targetKey)
        {
            var keys = new[] { $"freescheduler_cluster_{targetKey}_{id}" };
            _redis.Eval(@"local a=redis.call('get',KEYS[1]) if(a and a==ARGV[1])then
redis.call('del',KEYS[1],'freescheduler_cluster_register_'..a) end return 1", keys, Name);
        }
    }
}
