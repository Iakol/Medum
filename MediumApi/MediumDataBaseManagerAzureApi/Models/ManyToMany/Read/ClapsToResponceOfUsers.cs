using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany.Read
{
    public class ClapsToResponceOfUsers
    {
        public int ResponceId { get; set; }
        public string UserId { get; set; }

        public int ClapsCount { get; set; }

        public Responce Responce { get; set; }
        public UserWrapper User { get; set; }

    }
}
