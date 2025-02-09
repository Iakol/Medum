using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediumDataBaseManagerAzureApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndentityController : ControllerBase
    {
        public async Task CreateUser([FromBody]User userCred) 
        {
        
        
        }

        public async Task FindByEmailAsync(String email)
        {
        }
    }
}
