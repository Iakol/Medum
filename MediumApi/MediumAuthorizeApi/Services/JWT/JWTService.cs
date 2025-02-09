using MediumAuthorizeApi.Model.UserModal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace MediumAuthorizeApi.Services.JWT
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        public string GenereteJWTToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JWTSettings");
            var cred = new SigningCredentials( new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]!)), SecurityAlgorithms.HmacSha256);

            //Information What i put to token
            List<Claim> claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id ),
                new Claim(ClaimTypes.Role,"User" ), // change to getRoleByUserId
                //Add Another Claim if will needed
            };

            JwtSecurityToken token = new JwtSecurityToken(jwtSettings["Authority"], jwtSettings["Audiences"], claims, null, null, cred);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
