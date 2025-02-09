using MediumAuthorizeApi.Controllers;
using MediumAuthorizeApi.DTO.HttpContetnt;
using MediumAuthorizeApi.DTO.User;
using MediumAuthorizeApi.Model.UserModal;
using MediumAuthorizeApi.Services.JWT;
using Microsoft.AspNetCore.Identity;

namespace MediumAuthorizeApi.Services.Indentity
{
    public class IndentityService : IIndentityService
    {
        private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _singManager;

        private readonly IJWTService _jwtService;

        public IndentityService(UserManager<User> userManager , IJWTService jWTService, SignInManager<User> signInManager )
        {
            _userManager = userManager;
            _jwtService = jWTService;
            //_singManager = signInManager;
        }

        public async Task<string> LoginAndReturnJWT(AuthorizeCredDTO cred)
        {
            User userToLogin =  await _userManager.FindByEmailAsync(cred.Email);
            if (userToLogin != null)
            {
                bool res = await _userManager.CheckPasswordAsync(userToLogin, cred.Password);
                if (res)
                {
                    string jwt = _jwtService.GenereteJWTToken(userToLogin);
                    return jwt;
                }
                else {
                    return String.Empty;
                }
            }
            else 
            {
                
                return String.Empty;
            }
        }


        public Task<string> RegsterUser(RegisterCredDTO cred)
        {
            throw new NotImplementedException();
        }
    }
}
