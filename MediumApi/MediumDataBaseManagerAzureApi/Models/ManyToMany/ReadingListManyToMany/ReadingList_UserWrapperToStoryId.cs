using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class ReadingList_UserWrapperToStoryId
    {
        public int Id { get; set; }
        public string SaveStoryInListId { get; set; }
        public string UserReadingListId { get; set; }
        public UserReadingList userReadingList { get; set; }
        public ContentStateStoryWrapperModel SaveStoryInList { get; set; }
        public string UserNoteForSaveStory { get; set; }
    }
}
