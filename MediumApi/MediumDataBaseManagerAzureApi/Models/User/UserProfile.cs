namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class UserProfile
    {
        public string UserWrapperId { get; set; }
        public UserWrapper User { get; set; }

        public string LogoUrl { get; set; }
        public string About { get; set; }

    }
}
