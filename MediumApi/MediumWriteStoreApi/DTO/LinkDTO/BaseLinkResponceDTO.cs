using Newtonsoft.Json;

namespace MediumWriteStoreApi.DTO.LinkDTO
{
    public class BaseLinkResponceDTO
    {

        [JsonProperty("url")]
        public string url { get; set; } = "";
        [JsonProperty("HTTPCode")]
        public string HTTPCode { get; set; } = "";
        [JsonProperty("error")]
        public string error { get; set; } = "";
    }
}
