namespace MediumApi.DTO.StoryDTO.ResponceDTO
{
    public class ResponceDTO
    {
        public int ResponceID { get; set; }
        public string UserId { get; set; }
        public string TextOfResponce { get; set; }
        public int ReplyTo { get; set; }
        public int ClapsCount { get; set; }


    }
}
