using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class ResponceListToReaderList
    {
        public int ResponceId { get; set; }
        public string StoryId { get; set; }
        public string UserId { get; set; }
        public ContentStateStoryWrapperModel Story { get; set; }

        public UserWrapper User { get; set; }

        public string TextOfReply { get; set; }

        public ResponceListToReaderList? ReplyTo { get; set; } // If null it response to Story another variant reply to message

        public List<ClapsToResponceOfUsers> UserClaps { get; set; }


    }
}
