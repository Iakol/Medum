using Newtonsoft.Json;

namespace MediumWriteStoreApi.DTO.LinkDTO
{
    public class DeleteAzurePhotoResponse
    {
        [JsonProperty("HTTPCode")]
        public string HTTPCode { get; set; } = "";
        [JsonProperty("error")]
        public string error { get; set; } = "";
    }
}
