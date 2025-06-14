namespace MediumDataBaseManagerAzureApi.Rabbit
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

        public const string ReadingHistoryQueue = "q.ReadingHistoryQueue.WorkerID=";




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
        public const string UnBlockAuthor = "UnBlockAuthor";
        public const string FollowAuthor = "FollowAuthor";
        public const string UnFollowAuthor = "UnFollowAuthor";
        public const string GetAuthorFollowingAuthors = "GetAuthorFollowingAuthors";
        public const string GetReadingListsByAuthor = "GetReadingListsByAuthor";
        public const string GetRecomendationAuthorForUser = "GetRecomendationAuthorForUser";
        public const string GetStoryListByAuthor = "GetStoryListByAuthor";
        public const string MuteAuthor = "MuteAuthor";
        public const string UnMuteAuthor = "UnMuteAuthor";
        public const string GetUserHeaderStory = "GetUserHeaderStory";
        public const string GetUserHeader = "GetUserHeader";
        public const string GetUserCred = "GetUserCred";
        public const string GetMuteAuthorList = "GetMuteAuthorList";
        public const string GetBlockAuthorList = "GetBlockAuthorList";

        //Topic
        public const string GetRecomendationTopicsForUser = "GetRecomendationTopicsForUser";
        public const string GetFollowTopicsForUser = "GetFollowTopicsForUser";
        public const string CreateTopic = "CreateTopic";

        //ReadingHistory
        public const string GetReadingHistoryByUser = "GetReadingHistoryByUser";
        public const string ClearReadingHistoryByUser = "ClearReadingHistoryByUser";

        //ReadingList
        public const string AddStoryToReadingListByUser = "AddStoryToReadingListByUser";
        public const string CreateReadingListByUser = "CreateReadingListByUser";
        public const string DeleteReadingList = "DeleteReadingList";
        public const string DeleteStoryFromReadingList = "DeleteStoryFromReadingList";
        public const string GetAuthorRedingList = "GetAuthorRedingList";
        public const string GetUserReadingLists = "GetUserReadingLists";
        public const string GetUserSavedReadingLists = "GetUserSavedReadingLists";
        public const string UpdateNoteToStoryInReadingList = "UpdateNoteToStoryInReadingList";
        public const string UpdateReadingListByUser = "UpdateReadingListByUser";























        public const string GetStoryRecomendation = "GetStoryRecomendation";





    }
}
