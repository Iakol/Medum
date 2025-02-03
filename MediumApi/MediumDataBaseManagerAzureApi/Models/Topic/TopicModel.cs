using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.FollowClass;

namespace MediumDataBaseManagerAzureApi.Models.Topic
{
    public class TopicModel 
    {
        public string TopicId { get; set; }
        public string Name { get; set; }
        public List<string> Users { get; set; }

        public List<ContentStateStoryWrapperModel> Stories { get; set; }

    }
}
