using MediumDataBaseManagerAzureApi.Enum;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.FollowClass
{
    public  class FollowModel
    {

        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public UserWrapper User { get; set; }
        public string UserID { get; set; }
        public FollowTypeEnum Type { get; set; }
        public string IdToFollow{ get; set; }
    }
}
