using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany.ReadingListManyToMany
{
    public class SavedUsersReadingList_UserWraperToUserReadingList
    {
        public string UserId { get; set; }
        public int ReadingListId { get; set; }
        public UserWrapper User { get; set; }
        public UserReadingList UserReadingListToSave { get; set; }
    }
}
