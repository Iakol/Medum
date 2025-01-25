using MediumWriteStoreApi.DTO.LinkDTO;
using MediumWriteStoreApi.Service.AzureService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediumWriteStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetPhotoController : Controller
    {
        private readonly IAzureService _azureService;

        public SetPhotoController(IAzureService azureService)
        {
            _azureService = azureService;
        }

        [Route("/UploadPhoto")]
        [HttpPost]
        public async Task<ActionResult<PhotoAzureBlobResponseDTO>> UploadPhoto(IFormFile photo)
        {
            PhotoAzureBlobResponseDTO response = await _azureService.UploadPhoto(photo);
            return Ok(response);
        }

        [Route("/DeletePhoto")]
        [HttpGet]
        public async  Task<ActionResult<DeleteAzurePhotoResponse>> DeletePhoto( string BlobName)
        {
            DeleteAzurePhotoResponse response = await _azureService.DeletePhoto(BlobName);
            return Ok(response);
        }

        [Route("/GetPhoto")]
        [HttpPost]
        public async Task<ActionResult<PhotoAzureBlobResponseDTO>> GetPhoto(IFormFile photo)
        {
            PhotoAzureBlobResponseDTO response = await _azureService.UploadPhoto(photo);
            return Ok(response);
        }

    }
}
