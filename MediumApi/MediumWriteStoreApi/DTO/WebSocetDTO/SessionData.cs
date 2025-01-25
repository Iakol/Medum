using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediumWriteStoreApi.DTO.WebSocetDTO
{
    public class SessionData
    {
        public string SessionId { get; set; } = string.Empty + Guid.NewGuid() + DateTime.UtcNow;
        public bool isConneced { get; set; } = false;
        public string UserName { get; set; } = string.Empty;
        public DateTime ConnectionTime { get; set; } = DateTime.Now;
        public string Meta { get; set; } = string.Empty;
        public ContentStateOfSession ContentState { get; set; } = new ContentStateOfSession();
}
}
