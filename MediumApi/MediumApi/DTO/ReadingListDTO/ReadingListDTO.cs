namespace MediumApi.DTO.ReadingListDTO
{
    public class ReadingListDTO
    {
        public string Id { get; set; }

        public string userId { get; set; }

        public int storyCount { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<int> ReadingListItems { get; set; }


    }
}
