using MediumDataBaseManagerAzureApi.Models.Topic;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ContentState
{
    /*
     * Модель для контент Стейта для Статті
     */
    public class ContentStateStoryWrapperModel
    {
        public string Id { get; set; }
        public ContentStateModel ContentState { get; set; }

        public UserWrapper StoryCreator { get; set; } //Model Usera
        public string StoryCreatorId { get; set; } //Model Usera

        public List<UserWrapper> Authors{ get; set; } // Model Users

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime SaveLastUpdateTime { get; set; }

        public string Status { get; set; } // Private Public Draft Created

        public List<TopicModel> topics { get; set; }
        

    }
}
