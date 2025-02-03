namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserMemberShipModel
    {
        public string UserWrapperId { get; set; }
        public UserWrapper UserWrapper { get; set; }

        public bool isActive { get; set; }
        public string Type { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
    }
}
