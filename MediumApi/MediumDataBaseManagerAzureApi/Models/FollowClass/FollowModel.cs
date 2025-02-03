using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.FollowClass
{
    public  class FollowModel
    {

        public string Id { get; set; } 
        public UserWrapper User { get; set; }
        public string UserID { get; set; }
        public string Type { get; set; }
        public string IdToFollow{ get; set; }
    }
}
