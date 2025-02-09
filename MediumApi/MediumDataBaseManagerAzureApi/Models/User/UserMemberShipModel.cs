namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserMemberShipModel
    {
        public string UserWrapperId { get; set; }
        public UserWrapper UserWrapper { get; set; }

        public bool isActive { get; set; } = false;
        public string Type { get; set; } = "Base";
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
    }
}
