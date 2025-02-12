using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MediumDataBaseManagerAzureApi.Service.Indentity
{
    public class IndentityService : IIndentityService
    {
        private readonly AppDbContext _db;

        public IndentityService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IdentityResult> CreateUserAsync(User user)
        {

            UserMemberShipModel MemberShip = new UserMemberShipModel 
            {
                UserWrapperId = user.Id,
            };
            UserProfile userProfile = new UserProfile {
                UserWrapperId = user.Id
            };
            UserWrapper userWrapper = new UserWrapper 
            {
                UserId = user.Id,
            };

            await _db.Users.AddAsync(user);
            await _db.UserMemberShips.AddAsync(MemberShip);
            await _db.UserProfiles.AddAsync(userProfile);
            await _db.UserWrappers.AddAsync(userWrapper);

            await _db.SaveChangesAsync();
            var res = new IdentityResult();
            return res;
        }

        public Task CreateUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindByEmailAsync(string Email)
        {
            return _db.Users.FirstOrDefaultAsync(u => u.Email.Equals(Email));
        }

        public async Task<User?> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
