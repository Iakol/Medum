namespace MediumApi.DTO.StoryDTO.ContentStateDTO
{
    public class ContentStateDTO
    {
        public string id { get; set; } = string.Empty + DateTime.Now.ToString("ss:m:ss") + Guid.NewGuid();

        public DateTime changeCommitTime { get; set; }
        public List<BlockDTO> blocks { get; set; } = new List<BlockDTO>();
        public Dictionary<string, EntityMapDTO> entityMap { get; set; } = new Dictionary<string, EntityMapDTO>();

    }
}
