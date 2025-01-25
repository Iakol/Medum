using MediumWriteStoreApi.DTO.LinkDTO;
using MediumWriteStoreApi.Service.LinkService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MediumWriteStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService _linkService;
        public LinkController(ILinkService linkService ) 
        {
            _linkService = linkService;
        }

        [Route("CheckYoutubeLink")]
        [HttpGet]
        public async Task< ActionResult<BaseLinkResponceDTO>> CheckYoutubeLink(string Link) 
        {
            BaseLinkResponceDTO response = await _linkService.GetYoutubeURl(Link);
            return Ok(response);
        }

        [Route("GetEmbededInformationFromLink")]
        [HttpGet]
        public async Task<ActionResult<EmbededInfoResponseDTO>> GetEmbededInformationFromLink(string Link)
        {
            EmbededInfoResponseDTO response = await _linkService.GetEmbededInfoFromLink(Link);
            return Ok(response);
        }
    }
}
