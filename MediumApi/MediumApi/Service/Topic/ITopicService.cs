using MediumApi.DTO.TopicDTO;

namespace MediumApi.Service.Topic
{
    public interface ITopicService
    {
        public Task<List<TopicDTO>> GetRecomendationTopicsForUser(string UserId);
        public Task<List<TopicDTO>> GetFollowTopicsForUser(string UserId);

        public Task CreateTopic(string TopicName);



    }
}
