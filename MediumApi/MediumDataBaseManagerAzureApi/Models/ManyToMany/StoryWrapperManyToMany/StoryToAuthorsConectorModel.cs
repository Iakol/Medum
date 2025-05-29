using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany.StoryWrapperManyToMany
{
    public class StoryToAuthorsConectorModel
    {
        public int Id { get; set; }
        public string UserWrapperId { get; set; }
        public UserWrapper UserWrapper { get; set; }
        public string ContentStateWrapperId { get; set; }
        public ContentStateStoryWrapperModel ContentStateWrapper { get; set; }

    }
}
