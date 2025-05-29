namespace MediumApi.RabbitMQCover
{
    public static class QueueConstantForRabbitComunication
    {
        public static readonly string ServiceRabitID = Guid.NewGuid().ToString();
        //Reply To Queue

        public const string StoryCredQueue = "q.StoryListQueue.WorkerID=";

        public const string UpdateClapsAndResponseQueue = "q.UpdateClapsAndResponseQueue.WorkerID=";

        public const string AuthorCredQueue = "q.AuthorCredQueue.WorkerID=";

        public const string TopicQueue = "q.TopicQueue.WorkerID=";

        public const string ReadingListQueue = "q.ReadingListQueue.WorkerID=";



        // Exange For DB

        public const string RequestDBExechange = "e.RequestDBExechange";


        // Exange RouteKey

            //Story
        public const string StoryCred = "StoryCred";
        public const string UserCred = "UserCred";
        public const string MuteStory = "MuteStory";


            //Responce
        public const string AddResponce = "AddResponce";
        public const string GetResponce = "GetResponce";
        public const string DeleteResponce = "DeleteResponce";
        public const string GetResponceCount = "GetResponceCount";

        //Claps
        public const string AddClapsToResponce = "AddClapsToResponce";
        public const string AddClapsToStory = "AddClapsToStory";
        public const string AddClapsToReadingList = "AddClapsToReadingList";
        public const string GetClapsByStory = "GetClapsByStory";
        public const string GetClapsByReadingList = "GetClapsByReadingList";

        

        //Author
        public const string BlockAuthor = "BlockAuthor";
        public const string FollowAuthor = "FollowAuthor";
        public const string GetAuthorFollowingAuthors = "GetAuthorFollowingAuthors";
        public const string GetReadingListsByAuthor = "GetReadingListsByAuthor";
        public const string GetRecomendationAuthorForUser = "GetRecomendationAuthorForUser";
        public const string GetStoryListByAuthor = "GetStoryListByAuthor";
        public const string MuteAuthor = "MuteAuthor";
        public const string GetUserHeaderStory = "GetUserHeaderStory";
        public const string GetUserHeader = "GetUserHeader";
        public const string GetUserCred = "GetUserCred";

        //Topic
        public const string GetRecomendationTopicsForUser = "GetRecomendationTopicsForUser";
        public const string GetFollowTopicsForUser = "GetFollowTopicsForUser";
        public const string CreateTopic = "CreateTopic";

















        public const string GetStoryRecomendation = "GetStoryRecomendation";





    }
}
