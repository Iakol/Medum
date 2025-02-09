using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Service.Indentity
{
    public interface IIndentityService
    {
        public Task CreateUserAsync();
        public Task DeleteUserAsync();
        public Task<User?> FindByIdAsync(string userId);

    }
}
