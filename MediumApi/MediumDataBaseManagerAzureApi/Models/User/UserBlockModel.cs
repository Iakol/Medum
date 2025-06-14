namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserBlockModel
    {
        public string UserId { get; set; }
        public string BlockedAuthorByUser { get; set; }
        public UserWrapper User { get; set; }
        public DateTime BlockdAt { get; set; }
    }
}
