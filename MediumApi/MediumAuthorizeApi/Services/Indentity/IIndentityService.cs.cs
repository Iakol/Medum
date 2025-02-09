using MediumAuthorizeApi.Controllers;
using MediumAuthorizeApi.DTO.User;

namespace MediumAuthorizeApi.Services.Indentity
{
    public interface IIndentityService
    {
        public Task<string> LoginAndReturnJWT(AuthorizeCredDTO cred);
        public Task<string> RegsterUser(RegisterCredDTO cred);

    }
}
