using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Service.UserModalService
{
    public interface IUserService
    {
        public Task<UserWrapper> GetUserById(string userId);
    }
}
