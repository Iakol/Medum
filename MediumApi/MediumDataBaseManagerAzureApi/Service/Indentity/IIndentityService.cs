using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.AspNetCore.Identity;

namespace MediumDataBaseManagerAzureApi.Service.Indentity
{
    public interface IIndentityService
    {
        public Task<IdentityResult> CreateUserAsync(User user);
        public Task DeleteUserAsync();
        public Task<User?> FindByIdAsync(string userId);
        public Task<User?> FindByEmailAsync(string Email);

    }
}
