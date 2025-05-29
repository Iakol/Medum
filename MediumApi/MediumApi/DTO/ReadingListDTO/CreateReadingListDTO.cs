namespace MediumApi.DTO.ReadingListDTO
{
    public class CreateReadingListDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool isPrivate { get; set; }
    }
}
