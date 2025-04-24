namespace MediumDataBaseManagerAzureApi.DTO.ContentStateDTO
{
    public class BlockDTO
    {
        public string key { get; set; } = String.Empty;
        public string text { get; set; } = String.Empty;
        public string type { get; set; } = String.Empty;
        public int depth { get; set; }
        public List<InlineStylesRangeDTO> inlineStyleRanges { get; set; } = new List<InlineStylesRangeDTO>();
        public List<EntityRangeDTO> entityRanges { get; set; } = new List<EntityRangeDTO>();
        public Dictionary<string, string> data { get; set; } = new Dictionary<string, string>();
    }
}
