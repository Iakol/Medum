using MediumWriteStoreApi.DTO.ContentStateDTO;
using MediumWriteStoreApi.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MediumWriteStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<ResponseDTO> SaveEditor([FromBody] ContentStateDTO content)
        {
            ResponseDTO result = new ResponseDTO();
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateStory([FromBody] ContentStateDTO content)
        {
            ResponseDTO result = new ResponseDTO();
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]

        public ActionResult GetStory([FromBody] int id)
        {
            ResponseDTO result = new ResponseDTO();
            return Ok(result);
        }

    }
}
