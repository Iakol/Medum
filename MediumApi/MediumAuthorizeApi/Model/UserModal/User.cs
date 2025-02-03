using Microsoft.AspNetCore.Identity;
using System.Buffers.Text;

namespace MediumAuthorizeApi.Model.UserModal
{
    public class User : IdentityUser
    {
        public User() : base() {

            UserWrapperId = base.Id;

        }
        public string UserWrapperId { get; set; } 
    }
}
