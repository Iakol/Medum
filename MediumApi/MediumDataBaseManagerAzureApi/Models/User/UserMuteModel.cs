namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserMuteModel
    {
        public string UserId { get; set; }
        public string MuteAuthorByUser { get; set; }  
        public UserWrapper User { get; set; }
        public DateTime MutedAt { get; set; } = DateTime.Now;
    }
}
