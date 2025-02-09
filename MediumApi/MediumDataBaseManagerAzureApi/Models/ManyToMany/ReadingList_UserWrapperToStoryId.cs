namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class ReadingList_UserWrapperToStoryId
    {
        public int Id { get; set; }
        public string StoryId { get; set; }
        public string UserId { get; set; }
    }
}
