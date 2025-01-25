using Newtonsoft.Json;

namespace MediumWriteStoreApi.DTO.LinkDTO
{
    public class PhotoAzureBlobResponseDTO
    {
        [JsonProperty("url")]
        public string url { get; set; } = "";
        [JsonProperty("HTTPCode")]
        public string HTTPCode { get; set; } = "";
        [JsonProperty("error")]
        public string error { get; set; } = "";
    }
}
