using MediumAuthorizeApi.Model.UserModal;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Text;

namespace MediumDataBaseManagerAzureApi.Infrastructure.IndentetyStore
{
    public class AccsesToRemoteUserStore : IUserStore<User>, IUserPasswordStore<User>, IUserEmailStore<User>
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7238";


        public AccsesToRemoteUserStore(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        // Create User IN bd
        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(user);
            string json = JsonSerializer.Serialize(user); // Преобразуем объект в JSON
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync(BaseUrl + "CreateUser", content);
            IdentityResult IndentityRes = JsonSerializer.Deserialize<IdentityResult>(await res.Content.ReadAsStringAsync());
            return IdentityResult.Success;
        }

        // need for Create Asyck SetPasswordHash
        public async Task SetPasswordHashAsync(User user, string? passwordHash, CancellationToken cancellationToken)
        {
            if (passwordHash != null)
            {
                user.PasswordHash = passwordHash;
            }
        }

        public async Task<User?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var content = new StringContent(userId, Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync(BaseUrl + "CreateUser", content);
            return JsonSerializer.Deserialize<User>(await res.Content.ReadAsStringAsync());
        }

        public async Task<User?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var content = new StringContent(normalizedEmail, Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync(BaseUrl + "FindByEmailAsync", content);
            return JsonSerializer.Deserialize<User>(await res.Content.ReadAsStringAsync());

        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }



        public Task<User?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string? normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        

        public Task SetUserNameAsync(User user, string? userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(User user, string? email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    

        public Task<string?> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(User user, string? normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
