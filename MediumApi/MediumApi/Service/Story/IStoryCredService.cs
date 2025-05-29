using MediumApi.DTO.AuthorDTO;
using MediumApi.DTO.StoryDTO.StoryCredDTO;

namespace MediumApi.Service.Story
{
    public interface IStoryCredService
    {
        public Task<List<StoryForListDTO>> GetStoryRecomendationListByUser(string userId);

        public Task<List<StoryForListDTO>> GetStoryRecomendationListByUserAndTopic(string userID, int TopicId);

        public Task<List<StoryForListDTO>> GetStoryListByStoryListID(List<string> storyIds);

        public Task<StoryForListDTO> GetStoryCredByStoryID(string storyId);

        public Task<StoryCredForStoryForListDTO> GetStoryCredForStoryList(string storyId);

        public Task MuteStoryByStoryId(string storyId);






    }
}
