namespace MediumApi.Service.ConccurentDictonryForReplyTask
{
    public interface IConccurentDictonryForReplyTask
    {
        public Task Register(TaskCompletionSource<string> task,string correlationId);
        public Task UnRegister(string correlationId);

        public Task SetResult(string correlationId,string result);


    }
}
