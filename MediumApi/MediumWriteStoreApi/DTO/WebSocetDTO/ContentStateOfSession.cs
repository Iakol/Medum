namespace MediumWriteStoreApi.DTO.WebSocetDTO
{
    public class ContentStateOfSession
    {
        public ContentStateDTO.ContentStateDTO ContentState { get; set; } = new ();
        public bool isSaved { get; set; } = false;
        public bool isChangedAfterSave {get;set;} = false;
    }
}
