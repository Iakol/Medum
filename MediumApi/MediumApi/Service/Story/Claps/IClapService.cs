namespace MediumApi.Service.Story.Claps
{
    public interface IClapService
    {
        public Task GetClapsByStory(string StoryId);
        public Task AddClapsToStoryByUser(string UserID, string StoryId);

    }
}
