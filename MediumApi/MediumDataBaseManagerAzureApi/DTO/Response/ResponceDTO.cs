using MediumDataBaseManagerAzureApi.Models.ManyToMany;

namespace MediumDataBaseManagerAzureApi.DTO.Response
{
    public class ResponceDTO
    {
        public int ResponceId { get; set; }
        public string StoryId { get; set; }
        public string UserId { get; set; }
        public string TextOfReply { get; set; }
        public int? ReplyTo { get; set; } // If null it response to Story another variant reply to message
        
        public int Claps { get; set; }
    }
}
