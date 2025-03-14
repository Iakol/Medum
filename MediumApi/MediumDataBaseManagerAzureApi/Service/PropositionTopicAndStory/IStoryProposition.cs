using MediumDataBaseManagerAzureApi.DTO.Story;

namespace MediumDataBaseManagerAzureApi.Service.PropositionTopicAndStory
{
    public interface IStoryProposition
    {
        public Task<List<StoryForListDTO>> GetListByUser(string UserId);

        public Task<UserForStoryForListDTO> SetUserForStory(string UserId);

    }
}
