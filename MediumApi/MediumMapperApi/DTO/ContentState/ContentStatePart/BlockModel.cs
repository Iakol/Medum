namespace MediumMapperApi.Models.ContentState.ContentStatePart
{
    public class BlockModel
    {
        public int Id { get; set; } // BD id Of block
        public string ContentStateId { get; set; } // foren key to ContentState Model
        public ContentStateModel ContentState { get; set; } // referens
        public string key { get; set; } 
        public string text { get; set; }
        public string type { get; set; }
        public int depth { get; set; }
        public List<InlineStylesRangeModel> inlineStyleRanges { get; set; } 
        public List<EntityRangeModel> entityRanges { get; set; }
        public List<DictonaryDataInBlockModel> data { get; set; } 
    }
}
