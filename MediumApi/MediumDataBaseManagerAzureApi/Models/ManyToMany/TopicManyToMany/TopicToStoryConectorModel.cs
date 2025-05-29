using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.Topic;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany.TopicManyToMany
{
    public class TopicToStoryConectorModel
    {
        public int Id { get; set; }
        public TopicModel Topic { get; set; }
        public int TopicId { get; set; }
        public ContentStateStoryWrapperModel ContentStateWrapper { get; set; }
        public string ContentStateWrapperId { get; set; }
    }
}
