
using Azure.Storage.Blobs;
using MediumWriteStoreApi.DTO.LinkDTO;
using System;
using System.Collections;

namespace MediumWriteStoreApi.Service.AzureService
{
    public class AzureService : IAzureService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName ;

        public AzureService(IConfiguration configuration) 
        {
            _blobServiceClient = new BlobServiceClient(configuration["AzureBlobStorage:ConnectionString"]);
            _containerName = configuration["AzureBlobStorage:ContainerName"]!;
        }


        public Task<string> GetPhoto(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteAzurePhotoResponse> DeletePhoto(string BlobName) 
        {
            DeleteAzurePhotoResponse response = new DeleteAzurePhotoResponse();

            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blob = containerClient.GetBlobClient(BlobName);

            Azure.Response result = null;

            try
            {
                result = await blob.DeleteAsync();
            }
            catch (Exception e) 
            {
                response.error = e.Message;
            }


            if (result != null && result.Status >= 200 && result.Status <= 204)
            {
                response.HTTPCode = "200";
            }
            else 
            {
                response.HTTPCode = result != null? result.Status.ToString(): "404";

            }
            return response;
        }

        public async Task<PhotoAzureBlobResponseDTO> UploadPhoto(IFormFile photo)
        {
            PhotoAzureBlobResponseDTO response = new PhotoAzureBlobResponseDTO();
            if (photo != null && photo.Length != 0)
            {
                string FileName = Path.GetFileNameWithoutExtension(photo.FileName) + Guid.NewGuid() + Path.GetExtension(photo.FileName);
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                await containerClient.CreateIfNotExistsAsync();

                using (var stream = photo.OpenReadStream()) 
                {
                    var blob = containerClient.GetBlobClient(FileName);

                    await blob.UploadAsync(stream,overwrite:true);

                    response.url = blob.Uri.ToString();
                    response.HTTPCode = "200";


                    return response;

                }
            }
            else 
            {
                response.url = string.Empty;
                response.HTTPCode = "501";
                response.error = "Bad Photo";
                return response;
            }
        }

        public async Task<PhotoAzureBlobResponseDTO> UploadPhotoByteArray(byte[] photo,string Name)
        {
            PhotoAzureBlobResponseDTO response = new PhotoAzureBlobResponseDTO();
            if (photo != null && photo.Length != 0)
            {
                string FileName = Path.GetFileNameWithoutExtension(Name) + Guid.NewGuid() + Path.GetExtension(Name);
                var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                await containerClient.CreateIfNotExistsAsync();

                using (Stream stream = new MemoryStream(photo))
                {
                    var blob = containerClient.GetBlobClient(FileName);

                    await blob.UploadAsync(stream, overwrite: true);

                    response.url = blob.Uri.ToString();
                    response.HTTPCode = "200";
                    return response;

                }
            }
            else
            {
                response.url = string.Empty;
                response.HTTPCode = "501";
                response.error = "Bad Photo";
                return response;
            }
        }
    }
}
