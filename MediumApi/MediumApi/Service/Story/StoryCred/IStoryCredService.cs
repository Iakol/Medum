using MediumApi.DTO.StoryDTO.StoryCredDTO;

namespace MediumApi.Service.Story.StoryCred
{
    public interface IStoryCredService
    {
        public Task<List<StoryForListDTO>> GetStoryRecomendationListByUser(string userId);

        public Task<StoryForListDTO> GetStoryRecomendationListByUserAndTopic(string userID, int TopicId);

        public Task<List<StoryForListDTO>> GetStoryListByStoryListID(List<string> storyIds);

        public Task<StoryForListDTO> GetStoryCredByStoryID(string storyId);

        public Task<UserForStoryForListDTO> GetUserCredForStoryListByStoryId(string storyId);

        public Task<StoryCredForStoryForListDTO> GetStoryCredForStoryList(string storyId);



    }
}
