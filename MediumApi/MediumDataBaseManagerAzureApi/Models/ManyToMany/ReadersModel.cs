using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class ReadersModel
    {
        public string StoryId { get; set; }
        public string UserId { get; set; }
        public ContentStateStoryWrapperModel Story { get; set; }

        public UserWrapper User { get; set; }

        public int Claps { get; set; }

        public List<ResponceListToReaderList> responsesOfUser { get; set; }


    }
}
