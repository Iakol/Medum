using MediumDataBaseManagerAzureApi.Models.ManyToMany;

namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserReadingList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserWrapper User { get; set; }
        public string UserId { get; set; }
        public List<ReadingList_UserWrapperToStoryId> SaveStoryInList { get; set; }
    }
}
