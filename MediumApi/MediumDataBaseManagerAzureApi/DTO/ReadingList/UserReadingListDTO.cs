using MediumDataBaseManagerAzureApi.Models.ManyToMany;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.DTO.ReadingList
{
    public class UserReadingListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}
