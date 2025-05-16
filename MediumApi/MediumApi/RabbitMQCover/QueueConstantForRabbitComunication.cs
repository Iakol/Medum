namespace MediumApi.RabbitMQCover
{
    public static class QueueConstantForRabbitComunication
    {
        public static readonly string ServiceRabitID = Guid.NewGuid().ToString();
        //Reply To Queue

        public const string StoryCredQueue = "q.ReplyStoryListQueue.WorkerID=";

        public const string UpdateClapsAndResponseQueue = "q.UpdateClapsAndResponseQueue.WorkerID=";

        // Exange For DB

        public const string RequestDBExechange = "e.RequestDBExechange";


        // Exange RouteKey

        public const string StoryCred = "StoryCred";
        public const string UserCred = "UserCred";

        public const string GetStoryRecomendation = "GetStoryRecomendation";





    }
}
