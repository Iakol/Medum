
using System.Collections.Concurrent;

namespace MediumApi.Service.ConccurentDictonryForReplyTask
{
    public class ConccurentDictonryForReplyTask : IConccurentDictonryForReplyTask
    {
        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> _taskDictonary = new ConcurrentDictionary<string, TaskCompletionSource<string>>();
        public async Task Register(TaskCompletionSource<string> task, string correlationId)
        {
            _taskDictonary[correlationId] = task;
        }

        public async Task SetResult(string correlationId, string result)
        {
            if (_taskDictonary.TryRemove(correlationId,out TaskCompletionSource<string> task)) 
            {
                task.SetResult(result);

            }
        }

        public async Task UnRegister(string correlationId)
        {
            _taskDictonary.TryRemove(correlationId, out _);
         }
    }
}
