using MediumDataBaseManagerAzureApi.Models.User;
using MediumDataBaseManagerAzureApi.Service.Indentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MediumDataBaseManagerAzureApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndentityController : ControllerBase
    {
        private readonly IIndentityService _indentity;

        public IndentityController(IIndentityService indentity) 
        {
            _indentity = indentity;
        }

        [HttpPost]
        public async Task<ActionResult<IdentityResult>> CreateUser([FromBody]User userCred) 
        {

            var res = await _indentity.CreateUserAsync(userCred);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<User>> FindByEmailAsync([FromBody] String email)
        {
            var res = await _indentity.FindByEmailAsync(email);
            return Ok(res);
        }
    }
}
