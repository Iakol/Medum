namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class History
    {
        public string UserId { get; set; }

        public string StoryId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

    }
}
