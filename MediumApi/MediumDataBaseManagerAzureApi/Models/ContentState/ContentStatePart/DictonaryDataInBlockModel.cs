namespace MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart
{
    public class DictonaryDataInBlockModel
    {
        public int Id { get; set; } // DB id 
        public BlockModel Block { get; set; } // Referens
        public int BlockId { get; set; } // foren to block id
        public string DictonaryKey { get; set; }
        public string obj { get; set; } 
    }
}
