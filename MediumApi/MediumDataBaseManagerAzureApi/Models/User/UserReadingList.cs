using MediumDataBaseManagerAzureApi.Models.ManyToMany;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.Read;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.ReadingListManyToMany;

namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserReadingList
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public UserWrapper User { get; set; }
        public string UserId { get; set; }
        public List<ReadingList_UserWrapperToStoryId> SaveStoryInList { get; set; }
        public bool Immortal { get; set; }
        public bool Private { get; set; }
        public bool isOpenResponce { get; set; }
        public List<ReadersModel> ReaderOfReadingList { get; set; }
        public List<Responce> ResponceOfReadingList { get; set; }

    }
}
