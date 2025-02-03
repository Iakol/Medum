namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class StoryToAuthorsConectorModel
    {
        public int Id { get; set; }
        public string UserWrapperId { get; set; }
        public string ContentStateWrapperId { get; set; }
    }
}
