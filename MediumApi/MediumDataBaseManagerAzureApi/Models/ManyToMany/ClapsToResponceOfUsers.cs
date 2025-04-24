using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class ClapsToResponceOfUsers
    {
        public int ResponceId { get; set; }
        public string UserId { get; set; }

        public int ClapsCount { get; set; }

        public ResponceListToReaderList Responce { get; set; }
        public UserWrapper User { get; set; }

     }
}
