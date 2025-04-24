using MediumDataBaseManagerAzureApi.Enum;

namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserMemberShipModel
    {
        public string UserWrapperId { get; set; }
        public UserWrapper UserWrapper { get; set; }

        public bool isActive { get; set; } = false;
        public UserMemberShipTypeEnum Type { get; set; } 
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
    }
}
