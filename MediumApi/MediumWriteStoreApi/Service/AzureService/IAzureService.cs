using MediumWriteStoreApi.DTO.LinkDTO;

namespace MediumWriteStoreApi.Service.AzureService
{
    public interface IAzureService
    {
        public Task<PhotoAzureBlobResponseDTO> UploadPhoto(IFormFile photo);
        public Task<string> GetPhoto(string url);
        public Task<DeleteAzurePhotoResponse> DeletePhoto(string BlobName);
        public Task<PhotoAzureBlobResponseDTO> UploadPhotoByteArray(byte[] photo, string Name);

    }
}
