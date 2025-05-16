namespace MediumDataBaseManagerAzureApi.DTO.ReadingList
{
    public class ReadingListsAddStoryOfUsersDTO
    {
        public int readingListId { get; set; }
        public List<ReadingListsAddStoryOfUsersDTO> StoryList { get; set; }
    }
}
