using MediumDataBaseManagerAzureApi.Models.FollowClass;
using Microsoft.AspNetCore.Identity;

namespace MediumDataBaseManagerAzureApi.Models.User
{
    public class User : IdentityUser 
    {        
        public string UserWrapperId { get; set; }
        public UserWrapper UserWrapper { get; set; }


    }
}
