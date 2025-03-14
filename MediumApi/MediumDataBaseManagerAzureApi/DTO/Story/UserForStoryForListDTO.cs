namespace MediumDataBaseManagerAzureApi.DTO.Story
{
    public class UserForStoryForListDTO
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Tag { get; set; }
        public string? UsersImage { get; set; }
        public int FollowersCounts  { get; set; }
        public string AboutUser { get; set; }


    }
}
