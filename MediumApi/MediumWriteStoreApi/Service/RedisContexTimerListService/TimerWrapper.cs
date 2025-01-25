using System.Data;

namespace MediumWriteStoreApi.Service.RedisContexTimerListService
{
    public class TimerWrapper
    {
        private readonly string ContextStateId;
        private readonly Timer _timer;
        private readonly Action _task;
        private readonly DateTime _ExpiredTime;


        public TimerWrapper(string contextStateId, Action task, DateTime expiredTime)
        {
            ContextStateId = contextStateId;
            _timer = new Timer(ExecuteTimer, null, 0, TimeSpan.FromSeconds(1).Seconds);
            _task = task;
            _ExpiredTime = expiredTime; ;
        }

        public bool isExpired => DateTime.UtcNow > _ExpiredTime;
        public Action Task => _task;

        public string GetContextStateId => ContextStateId;

        public void ExecuteTimer(object state)
        {
            if (isExpired)
            {
                DoTask();
            }
        }

        public void DoTask()
        {
            this.Task.Invoke();
            _timer.Dispose();
        }

        public void CancelTimer() {
            _timer.Dispose();

        }

    }
}
