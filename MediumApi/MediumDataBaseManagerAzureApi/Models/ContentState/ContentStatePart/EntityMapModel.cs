namespace MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart
{
    public class EntityMapModel
    {
        public int id { get; set; }
        public ContentStateModel ContentState { get; set; } // referens
        public string ContentStateKey { get; set; } // String Key
        public string DictonaryKey { get; set; }
        public string type { get; set; } 
        public string mutability { get; set; }
        public string data { get; set; }
    }
}
