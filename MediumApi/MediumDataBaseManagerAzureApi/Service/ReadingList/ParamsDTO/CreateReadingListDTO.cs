namespace MediumDataBaseManagerAzureApi.Service.ReadingList.ParamsDTO
{
    public class CreateReadingListDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool isPrivate { get; set; }
        public string userId { get; set; }

    }
}
