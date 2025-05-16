using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class ReadingList_UserWrapperToStoryId
    {
        public int Id { get; set; }
        public string SaveStoryInListId { get; set; }
        public int UserReadingListId { get; set; }
        public UserReadingList userReadingList { get; set; }
        public string UserNoteForSaveStory { get; set; }
    }
}
