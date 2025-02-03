namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserProfile
    {
        public string UserId { get; set; }
        public UserWrapper User { get; set; }

        public string LogoUrl { get; set; }
        public string About { get; set; }

    }
}
