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
            RefershAndOffline();
            _redis.SubscribeList("freescheduler_cluster_alloc", msg =>
            {
                if (string.IsNullOrWhiteSpace(msg)) return;
                var args = msg.Split('|');
                var timestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                int.TryParse(args[0], out var time);
                if (timestamp - time > 60 * 5) return; //过滤超过5分钟之前的分配
                switch (args[1])
                {
                    case nameof(ReloadTask):
                        {
                            var taskId = args[2];
                            if (_scheduler._tasks.ContainsKey(taskId)) return;
                            var task = _scheduler._taskHandler.Load(taskId);
                            if (task == null) return;
                            if (task.Status != TaskStatus.Running) return;
                            if (task.Round != -1 && task.CurrentRound >= task.Round) return;
                            if (task.Interval == TaskInterval.Custom && _scheduler._taskIntervalCustomHandler == null) return;
                            _scheduler.AddTaskPriv(task, false);
                            break;
                        }
                }
            });
            _redis.Subscribe($"freescheduler_cluster_{Name}", (chan, data) =>
            {
                var msg = data as string;
                if (string.IsNullOrWhiteSpace(msg)) return;
                var args = msg.Split('|');
                var timestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                int.TryParse(args[0], out var time);
                if (timestamp - time > 60*5) return; //过滤超过5分钟之前的命令
                switch (args[1])
                {
                    case nameof(Scheduler.RemoveTempTask):
                        {
                            var result = _scheduler.RemoveTempTask(args[2]) ? 1 : 0;
                            _redis.Publish($"freescheduler_cluster_{args[3]}", $"{timestamp}|response|{args[4]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.ExistsTempTask):
                        {
                            var result = _scheduler.ExistsTempTask(args[2]) ? 1 : 0;
                            _redis.Publish($"freescheduler_cluster_{args[3]}", $"{timestamp}|response|{args[4]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.RemoveTask):
                        {
                            var result = _scheduler.RemoveTask(args[2]) ? 1 : 0;
                            _redis.Publish($"freescheduler_cluster_{args[3]}", $"{timestamp}|response|{args[4]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.ExistsTask):
                        {
                            var result = _scheduler.ExistsTask(args[2]) ? 1 : 0;
                            _redis.Publish($"freescheduler_cluster_{args[3]}", $"{timestamp}|response|{args[4]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.PauseTask):
                        {
                            var result = _scheduler.PauseTask(args[2]) ? 1 : 0;
                            _redis.Publish($"freescheduler_cluster_{args[3]}", $"{timestamp}|response|{args[4]}|{result}");
                            break;
                        }
                    case nameof(Scheduler.RunNowTask):
                        {
                            var result = _scheduler.RunNowTask(args[2]) ? 1 : 0;
                            _redis.Publish($"freescheduler_cluster_{args[3]}", $"{timestamp}|response|{args[4]}|{result}");
                            break;
                        }
                    case "response":
                        if (_responseWait.TryGetValue(args[2], out var wait))
                        {
                            wait.Result = args[3];
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
                            var timestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                            _redis.Publish($"freescheduler_cluster_{targetClusterName}", $"{timestamp}|{method}|{id}|{Name}|{waitId}");
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
                    if (scan.Any() == false) continue;
                    _redis.Eval($"for a=1,#ARGV do redis.call('zrem','freescheduler_cluster_register_'..KEYS[1],ARGV[a]) if(redis.call('get','freescheduler_cluster_'..ARGV[a])==KEYS[1])then redis.call('del',KEYS[1]) end end return nil", new[] { name } , scan.Select(a => a.member).ToArray());
                    var timestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                    var taskIds = scan.Where(sr => sr.member.StartsWith("AddTask_")).Select(sr => sr.member.Substring(8)) //忽略内存任务 AddTempTask_
                        .Where(taskId => _scheduler._tasks.ContainsKey(taskId) == false)
                        .Select(taskId => $"{timestamp}|{nameof(ReloadTask)}|{taskId}").ToArray();
                    _redis.LPush("freescheduler_cluster_alloc", taskIds);
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
        public bool Register(string id, string targetKey)
        {
            var timestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            var keys = new[] { $"freescheduler_cluster_{targetKey}_{id}", $"freescheduler_cluster_register_{Name}" };
            var result = _redis.Eval(@"if(redis.call('setnx',KEYS[1],ARGV[1])==1)then redis.call('zadd',KEYS[2],ARGV[2],ARGV[3]) return 1 end
if(redis.call('hexists','freescheduler_cluster_offline',redis.call('get',KEYS[1]))==1)then redis.call('set',KEYS[1],ARGV[1]) redis.call('zadd',KEYS[2],ARGV[2],ARGV[3]) return 1 end return 0", 
                keys, Name, timestamp, $"{targetKey}_{id}")?.ToString();

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
