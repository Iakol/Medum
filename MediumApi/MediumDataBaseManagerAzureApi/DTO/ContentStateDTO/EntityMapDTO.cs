namespace MediumDataBaseManagerAzureApi.DTO.ContentStateDTO
{
    public class EntityMapDTO
    {
        public string type { get; set; } = String.Empty;
        public string mutability { get; set; } = String.Empty;
        public object data { get; set; }
        
    }
}
