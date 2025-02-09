using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Service.Indentity
{
    public class IndentityService : IIndentityService
    {
        private readonly AppDbContext _db;

        public IndentityService(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateUserAsync(User user)
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


        }

        public Task CreateUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
