using MediumWriteStoreApi.DTO.LinkDTO;

namespace MediumWriteStoreApi.Service.LinkService
{
    public interface ILinkService
    {
        public Task<BaseLinkResponceDTO> GetYoutubeURl(string url);
        public Task<EmbededInfoResponseDTO> GetEmbededInfoFromLink(string url);
        public string GetImageFromRedactor(IFormFile image);

        public string GetYoutubeVideoId(string url);
    }
}
