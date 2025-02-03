namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class TopicToStoryConectorModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string ContentStateWrapperId { get; set; }
    }
}
