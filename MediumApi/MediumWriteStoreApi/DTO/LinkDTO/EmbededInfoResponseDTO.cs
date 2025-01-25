namespace MediumWriteStoreApi.DTO.LinkDTO
{
    public class EmbededInfoResponseDTO
    {
        public string HTTPCode { get; set; }
        public EmbededInfoLinkResponseDTO? Result { get; set; }
        public string error { get; set; }
    }

    public class EmbededInfoLinkResponseDTO 
    {
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public List<string> Images { get; set; }
    }
}
