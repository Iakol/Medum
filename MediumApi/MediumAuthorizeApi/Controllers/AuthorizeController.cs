using MediumAuthorizeApi.DTO.HttpContetnt;
using MediumAuthorizeApi.DTO.User;
using MediumAuthorizeApi.Services.Indentity;
using Microsoft.AspNetCore.Mvc;

namespace MediumAuthorizeApi.Controllers
{
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IIndentityService _indentityService;
        public AuthorizeController(IIndentityService indentityService ) 
        {

            _indentityService = indentityService;
        }

        [HttpPost]
        public ActionResult<MessageDTO> Login([FromBody] AuthorizeCredDTO auth)
        {
            MessageDTO res = new MessageDTO();
            return Ok(res);
        }

        public ActionResult Register([FromBody] RegisterCredDTO regcred)
        {
            MessageDTO res = new MessageDTO();
            return Ok(res);
        }
    }
}
