namespace MediumAuthorizeApi.DTO.HttpContetnt
{
    public class MessageDTO
    {
        public string HttpCode { get; set; } = "200";
        public string? Value { get; set; }
        public string Type { get; set; }
        public string? Errors { get; set; }


    }
}
