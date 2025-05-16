using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.FollowClass;

namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserWrapper 
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public List<FollowModel> Relationships { get; set; }
        public UserProfile Profile { get; set; }
        public ContentStateAboutUserWrapperModel AboutContent { get; set; }

        public List<ContentStateStoryWrapperModel> UserStories { get; set; }

        public List<UserReadingList> ReadingLists { get; set; }

        public UserMemberShipModel UserMemberShip { get; set; }
        public string Tag { get; set; } // nedd migrate





    }
}
