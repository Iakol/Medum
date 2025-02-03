namespace MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart
{
    public class InlineStylesRangeModel
    {
        public int Id { get; set; } // DB id 
        public int BlockId { get; set; } // forent to block id
        public BlockModel Block { get; set; } // Referens

        public int offset { get; set; }
        public int length { get; set; }
        public string style { get; set; } 
    }
}
