using MediumAuthorizeApi.Model.UserModal;

namespace MediumAuthorizeApi.Services.JWT
{
    public interface IJWTService
    {
        public string GenereteJWTToken(User user);
    }
}
