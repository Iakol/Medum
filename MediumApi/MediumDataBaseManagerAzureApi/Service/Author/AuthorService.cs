using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.FollowClass;
using MediumDataBaseManagerAzureApi.Models.User;
using MediumDataBaseManagerAzureApi.Service.Author.ParamsDTO;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Text.Json;

namespace MediumDataBaseManagerAzureApi.Service.Author
{
    public class AuthorService(AppDbContext _db) : IAuthorService
    {
        public async Task<List<string>> GetAuthorFollowingAuthors(string userId) // par: string userId ret List<string>
        {
            return await _db.Follows.Where(f => f.UserID == userId && f.Type == Enum.FollowTypeEnum.Author).Select(f => f.IdToFollow).ToListAsync();
        }

        public async Task<List<string>> GetRecomendationAuthorForUser(string userId) //string userId ret List<string> //Template
        {
            return await _db.UserWrappers.Select(a => a.UserId).ToListAsync(); // template
        }

        public async Task<string> MuteAuthorByAuthorId(AuthorToUserDTO Params) // par userID Author Id // return bool
        {



            if (await _db.UserMutes.AnyAsync(m =>
            m.UserId.Equals(Params.userId) &&
            m.MuteAuthorByUser.Equals(Params.authorId)
            ))
            {
                return "AlreadyMuted";
            }

            if (await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(Params.userId)) &&
                await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(Params.authorId))
                )
            {
                UserMuteModel Mute = new UserMuteModel
                {
                    UserId = Params.userId,
                    MuteAuthorByUser = Params.authorId,
                };

                await _db.UserMutes.AddAsync(Mute);
                await _db.SaveChangesAsync();
                return "OK";
            }
            else
            {
                return "UsersNotFound" ;

            }
        }

        public async Task<string> BlockAuthorByAuthorId(AuthorToUserDTO Params)
        {

            if (await _db.UserBlocks.AnyAsync(m =>
            m.UserId.Equals(Params.userId) &&
            m.BlockedAuthorByUser.Equals(Params.authorId)
            ))
            {
                return "AlreadyBlocked";
            }

            if (await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(Params.userId)) &&
                await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(Params.authorId))
                )
            {
                UserBlockModel Block = new UserBlockModel
                {
                    UserId = Params.userId,
                    BlockedAuthorByUser = Params.authorId,
                };

                await _db.UserBlocks.AddAsync(Block);
                await _db.SaveChangesAsync();
                return "OK" ;
            }
            else
            {
                return "UsersNotFound";

            }
        }

        public async Task<string> FollowAuthorByAuthorId(AuthorToUserDTO Params) // par userID Author Id // return bool
        {

            if (await _db.Follows.AnyAsync(m =>
            m.Type == Enum.FollowTypeEnum.Author &&
            m.UserID.Equals(Params.userId) &&
            m.IdToFollow.Equals(Params.authorId)
            ))
            {
                return "AlreadyFollowed" ;
            }

            if (await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(Params.authorId)) &&
                await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(Params.userId))
                )
            {
                FollowModel followObj = new FollowModel
                {
                    UserID = Params.userId,
                    IdToFollow = Params.authorId,
                    Type = Enum.FollowTypeEnum.Author,

                };

                await _db.Follows.AddAsync(followObj);
                await _db.SaveChangesAsync();
                return "OK";
            }
            else
            {
                return "UsersNotFound";

            }
        }

        public async Task<string> UnMuteAuthorByAuthorId(AuthorToUserDTO Params) // par userID Author Id // return bool
        {


            if (await _db.UserMutes.AnyAsync(m =>
            m.UserId.Equals(Params.userId) &&
            m.MuteAuthorByUser.Equals(Params.authorId)
            ))
            {
                UserMuteModel Mute = await _db.UserMutes.FirstOrDefaultAsync(m =>
                    m.UserId.Equals(Params.userId) &&
                    m.MuteAuthorByUser.Equals(Params.authorId));

                _db.UserMutes.Remove(Mute!);
                await _db.SaveChangesAsync();
                return  "OK";

            }
            else
            {
                return "MuteNotExist";

            }
        }

        public async Task<string> UnBlockAuthorByAuthorId(AuthorToUserDTO Params)
        {

            if (await _db.UserBlocks.AnyAsync(m =>
            m.UserId.Equals(Params.userId) &&
            m.BlockedAuthorByUser.Equals(Params.authorId)
            ))
            {
                UserBlockModel Block = await _db.UserBlocks.FirstOrDefaultAsync(m =>
                                    m.UserId.Equals(Params.userId) &&
                                    m.BlockedAuthorByUser.Equals(Params.authorId));

                _db.UserBlocks.Remove(Block!);
                await _db.SaveChangesAsync();
                return "OK";
            }
            else
            {
                return "BlockedNotExist";

            }
        }

        public async Task<string> UnFollowAuthorByAuthorId(AuthorToUserDTO Params) // par userID Author Id // return bool
        {
            if (await _db.Follows.AnyAsync(m =>
            m.Type == Enum.FollowTypeEnum.Author &&
            m.UserID.Equals(Params.userId) &&
            m.IdToFollow.Equals(Params.authorId)
            ))
            {
                FollowModel Follow = await _db.Follows.FirstOrDefaultAsync(m =>
                    m.Type == Enum.FollowTypeEnum.Author &&
                    m.UserID.Equals(Params.userId) &&
                    m.IdToFollow.Equals(Params.authorId));

                _db.Follows.Remove(Follow!);
                await _db.SaveChangesAsync();
                return "OK" ;
            }
            else
            {
                return "FollowNotExist" ;

            }
        }

        public async Task<List<string>> GetMuteAuthorList(string userId) // par: string userId // return List<string> UserIds that mute by user
        {
            return await _db.UserMutes.Where(m => m.UserId == userId).Select(f => f.MuteAuthorByUser).ToListAsync();
        }

        public async Task<List<string>> GetBlockAuthorList(string userId) // par: string userId // return List<string> UserIds that block by user
        {
            return await _db.UserBlocks.Where(m => m.UserId == userId).Select(f => f.BlockedAuthorByUser).ToListAsync();
        }

        public async Task<List<string>> GetStoryIdsListByAuthor(string authorId) // par: string authorId // return List<string> storyIds that drawed by author and public
        {
            return await _db.ContentStateStoryWrappers.Where(s => s.StoryCreatorId == authorId && s.Status == Enum.StoryStatusEnum.Public).Select(s => s.Id).ToListAsync();
        }

        public async Task<List<string>> GetReadingIdsListByAuthor(string authorId) // par: string authorId // return List<string> readingListIds that drawed by author and public
        {
            return await _db.UsersReadingLists.Where(r => r.UserId == authorId && r.Private == false).Select(r => r.Id).ToListAsync();
        }

        public async Task<string> GetUserHeaderStoryId(string stroryId) // par: string stroryId // return UserHeaderDTO by Story
        {
            try
            {
                string author = (await _db.ContentStateStoryWrappers.FindAsync(stroryId)).StoryCreatorId;
                UserWrapper User = await _db.UserWrappers.Include(u => u.Profile).Include(u => u.User).FirstOrDefaultAsync(u => u.UserId == author)!;
                if (User != null)
                {
                    var UserHeader = new
                    {
                        UserId = User.UserId,
                        CreatorName = User.User.UserName,
                        CreatorLogo = User.Profile.LogoUrl,
                        CreatorTag = User.Tag
                    };

                    return JsonSerializer.Serialize(UserHeader);
                }
                else
                {
                    return "UserNotFound" ;

                }
            }
            catch (DbException ex) 
            {
                return "StoryNotFound" ;
            }
            
        }

        public async Task<string> GetUserHeader(string AuthorId)// par: string AuthorId // return UserHeaderDTO
        {
            UserWrapper User = await _db.UserWrappers.Include(u => u.Profile).Include(u => u.User).FirstOrDefaultAsync(u => u.UserId == AuthorId)!;
            if (User != null)
            {
                var UserHeader = new
                {
                    UserId = User.UserId,
                    CreatorName = User.User.UserName,
                    CreatorLogo = User.Profile.LogoUrl,
                    CreatorTag = User.Tag
                };

                return JsonSerializer.Serialize(UserHeader);
            }
            else
            {
                return "UserNotFound" ;

            }
        }

        public async Task<string> GetUserCred(string AuthorId)// par: string AuthorId // return UserCredDTO
        {
            UserWrapper User = await _db.UserWrappers.Include(u => u.Profile).Include(u => u.User).FirstOrDefaultAsync(u => u.UserId == AuthorId)!;
            
            if (User != null)
            {
                int FollowedCount = _db.Follows.Where(f => f.IdToFollow == AuthorId).Count();
                var UserCred = new
                {
                    UserId = User.UserId,
                    FollowersCounts = FollowedCount,
                    AboutUser = User.Profile.About,
                };

                return JsonSerializer.Serialize(UserCred);
            }
            else
            {
                return  "UserNotFound";

            }
        }



    }
}
