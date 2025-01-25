using Newtonsoft.Json;

namespace MediumWriteStoreApi.DTO.Response
{
    public class ResponseDTO
    {
        [JsonProperty("url")]
        public string url { get; set; } = "";
        [JsonProperty("Result")]
        public dynamic result { get; set; }
        [JsonProperty("HTTPCode")]
        public string HTTPCode { get; set; } = "";
        [JsonProperty("error")]
        public string error { get; set; } = "";
    }
}
