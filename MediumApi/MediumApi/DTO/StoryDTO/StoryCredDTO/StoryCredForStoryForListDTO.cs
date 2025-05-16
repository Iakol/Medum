namespace MediumApi.DTO.StoryDTO.StoryCredDTO
{
    public class StoryCredForStoryForListDTO
    {
        public string StoryId { get; set; } 
        public string StoryTittle { get; set; }
        public string StoryDescription { get; set; }
        public string? StoryPreviewImage { get; set; }
        public DateTime publicAt { get; set; }
        public int? CountOfClaps { get; set; }
        public int? CountOfResponce { get; set; }

        public string CreatorId { get; set; }

        public string CreatorName { get; set; }
        public string CreatorLogo { get; set; }
        public string CreatorTag { get; set; }




    }
}
