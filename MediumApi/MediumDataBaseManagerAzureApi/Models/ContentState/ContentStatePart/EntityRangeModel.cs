namespace MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart
{
    public class EntityRangeModel
    {
        public int Id { get; set; } // DB id 
        public int BlockId { get; set; } // forent to block id
        public BlockModel Block { get; set; } // Referens

        public int offset { get; set; }

        public int length { get; set; }

        public int key { get; set; }
    }
}
