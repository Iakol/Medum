using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace MediumDataBaseManagerAzureApi.Service.UserModalService
{
    public class UserService([FromServices] AppDbContext _db) : IUserService
    {
        public Task<UserWrapper> GetUserById(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
