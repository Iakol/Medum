using MediumDataBaseManagerAzureApi.DTO.Story;

namespace MediumDataBaseManagerAzureApi.DTO.ReadingList
{
    public class StoryListOfUserReadingListDTO
    {
        public string Note { get; set; }
        public StoryForListDTO Story { get; set; }
    }
}
