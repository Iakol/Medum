namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class ReadingList_UserWrapperToStoryId
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public string UserId { get; set; }
    }
}
