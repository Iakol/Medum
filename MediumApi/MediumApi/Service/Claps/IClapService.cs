namespace MediumApi.Service.Claps
{
    public interface IClapService
    {
        public Task<int> GetClapsByStory(string StoryId);
        public Task<int> GetClapsByReadingList(string ReadingListId);

        public Task AddClapsToStoryByUser(string UserID, string StoryId);
        public Task AddClapsToReadingListByUser(string UserID, string ReadingListId);

        public Task AddClapsToResponceByUser(string UserID, string responceId);


    }
}
