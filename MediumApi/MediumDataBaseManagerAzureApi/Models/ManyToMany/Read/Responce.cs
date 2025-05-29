using MediumDataBaseManagerAzureApi.Enum;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany.Read
{
    public class Responce
    {
        public int ResponceId { get; set; }
        public string ReadId { get; set; } // Story or ReaderList
        public string UserId { get; set; }

        public ReaderTypeEnum ReaderTypeEnum { get; set; } // Story or ReaderList

        public UserWrapper User { get; set; }

        public string TextOfReply { get; set; }

        public Responce? ReplyTo { get; set; } // If null it response to Story or Reading another variant reply to message

        public List<ClapsToResponceOfUsers> UserClaps { get; set; }


    }
}
