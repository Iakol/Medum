using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.FollowClass;
using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Text.Json;

namespace MediumDataBaseManagerAzureApi.Service.Author
{
    public class AuthorService(AppDbContext _db) : IAuthorService
    {
        public async Task<string> GetAuthorFollowingAuthors(string Params) // par: string userId ret List<string>
        {
            return JsonSerializer.Serialize(await _db.Follows.Where(f => f.UserID == Params && f.Type == Enum.FollowTypeEnum.Author).Select(f => f.IdToFollow).ToListAsync());
        }

        public async Task<string> GetRecomendationAuthorForUser(string Params) //string userId ret List<string> //Template
        {
            return JsonSerializer.Serialize(await _db.UserWrappers.Select(a => a.UserId).ToListAsync()); // template
        }

        public async Task<string> MuteAuthorByAuthorId(string Params) // par userID Author Id // return bool
        {

            JsonElement par = JsonSerializer.Deserialize<JsonElement>(Params);

            if (await _db.UserMutes.AnyAsync(m =>
            m.UserId.Equals(par.GetProperty("userId").ToString()) &&
            m.MuteAuthorByUser.Equals(par.GetProperty("authorId").ToString())
            ))
            {
                return JsonSerializer.Serialize(new { Status = "AlreadyMuted" });
            }

            if (await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(par.GetProperty("authorId").ToString())) &&
                await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(par.GetProperty("userId").ToString()))
                )
            {
                UserMuteModel Mute = new UserMuteModel
                {
                    UserId = par.GetProperty("userId").ToString(),
                    MuteAuthorByUser = par.GetProperty("authorId").ToString(),
                };

                await _db.UserMutes.AddAsync(Mute);
                await _db.SaveChangesAsync();
                return JsonSerializer.Serialize(new { Status = "OK" });
            }
            else
            {
                return JsonSerializer.Serialize(new { Status = "UsersNotFound" });

            }
        }

        public async Task<string> BlockAuthorByAuthorId(string Params)
        {
            JsonElement par = JsonSerializer.Deserialize<JsonElement>(Params);

            if (await _db.UserBlocks.AnyAsync(m =>
            m.UserId.Equals(par.GetProperty("userId").ToString()) &&
            m.BlockedAuthorByUser.Equals(par.GetProperty("authorId").ToString())
            ))
            {
                return JsonSerializer.Serialize(new { Status = "AlreadyBlocked" });
            }

            if (await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(par.GetProperty("authorId").ToString())) &&
                await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(par.GetProperty("userId").ToString()))
                )
            {
                UserBlockModel Block = new UserBlockModel
                {
                    UserId = par.GetProperty("userId").ToString(),
                    BlockedAuthorByUser = par.GetProperty("authorId").ToString(),
                };

                await _db.UserBlocks.AddAsync(Block);
                await _db.SaveChangesAsync();
                return JsonSerializer.Serialize(new { Status = "OK" });
            }
            else
            {
                return JsonSerializer.Serialize(new { Status = "UsersNotFound" });

            }
        }

        public async Task<string> FollowAuthorByAuthorId(string Params) // par userID Author Id // return bool
        {
            JsonElement par = JsonSerializer.Deserialize<JsonElement>(Params);

            if (await _db.Follows.AnyAsync(m =>
            m.Type == Enum.FollowTypeEnum.Author &&
            m.UserID.Equals(par.GetProperty("userId").ToString()) &&
            m.IdToFollow.Equals(par.GetProperty("authorId").ToString())
            ))
            {
                return JsonSerializer.Serialize(new { Status = "AlreadyFollowed" });
            }

            if (await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(par.GetProperty("authorId").ToString())) &&
                await _db.UserWrappers.AnyAsync(u => u.UserId.Equals(par.GetProperty("userId").ToString()))
                )
            {
                FollowModel followObj = new FollowModel
                {
                    UserID = par.GetProperty("userId").ToString(),
                    IdToFollow = par.GetProperty("authorId").ToString(),
                    Type = Enum.FollowTypeEnum.Author,

                };

                await _db.Follows.AddAsync(followObj);
                await _db.SaveChangesAsync();
                return JsonSerializer.Serialize(new { Status = "OK" });
            }
            else
            {
                return JsonSerializer.Serialize(new { Status = "UsersNotFound" });

            }
        }

        public async Task<string> UnMuteAuthorByAuthorId(string Params) // par userID Author Id // return bool
        {

            JsonElement par = JsonSerializer.Deserialize<JsonElement>(Params);

            if (await _db.UserMutes.AnyAsync(m =>
            m.UserId.Equals(par.GetProperty("userId").ToString()) &&
            m.MuteAuthorByUser.Equals(par.GetProperty("authorId").ToString())
            ))
            {
                UserMuteModel Mute = await _db.UserMutes.FirstOrDefaultAsync(m =>
                    m.UserId.Equals(par.GetProperty("userId").ToString()) &&
                    m.MuteAuthorByUser.Equals(par.GetProperty("authorId").ToString()));

                _db.UserMutes.Remove(Mute!);
                await _db.SaveChangesAsync();
                return JsonSerializer.Serialize(new { Status = "OK" });

            }
            else
            {
                return JsonSerializer.Serialize(new { Status = "FollowNotExist" });

            }
        }

        public async Task<string> UnBlockAuthorByAuthorId(string Params)
        {
            JsonElement par = JsonSerializer.Deserialize<JsonElement>(Params);

            if (await _db.UserBlocks.AnyAsync(m =>
            m.UserId.Equals(par.GetProperty("userId").ToString()) &&
            m.BlockedAuthorByUser.Equals(par.GetProperty("authorId").ToString())
            ))
            {
                UserBlockModel Block = await _db.UserBlocks.FirstOrDefaultAsync(m =>
                                    m.UserId.Equals(par.GetProperty("userId").ToString()) &&
                                    m.BlockedAuthorByUser.Equals(par.GetProperty("authorId").ToString()));

                _db.UserBlocks.Remove(Block!);
                await _db.SaveChangesAsync();
                return JsonSerializer.Serialize(new { Status = "OK" });
            }
            else
            {
                return JsonSerializer.Serialize(new { Status = "Blocked not Exist" });

            }
        }

        public async Task<string> UnFollowAuthorByAuthorId(string Params) // par userID Author Id // return bool
        {
            JsonElement par = JsonSerializer.Deserialize<JsonElement>(Params);

            if (await _db.Follows.AnyAsync(m =>
            m.Type == Enum.FollowTypeEnum.Author &&
            m.UserID.Equals(par.GetProperty("userId").ToString()) &&
            m.IdToFollow.Equals(par.GetProperty("authorId").ToString())
            ))
            {
                FollowModel Follow = await _db.Follows.FirstOrDefaultAsync(m =>
                    m.Type == Enum.FollowTypeEnum.Author &&
                    m.UserID.Equals(par.GetProperty("userId").ToString()) &&
                    m.IdToFollow.Equals(par.GetProperty("authorId").ToString()));

                _db.Follows.Remove(Follow!);
                await _db.SaveChangesAsync();
                return JsonSerializer.Serialize(new { Status = "OK" });
            }
            else
            {
                return JsonSerializer.Serialize(new { Status = "Follow not Exist" });

            }
        }

        public async Task<string> GetMuteAuthorList(string Params) // par: string userId // return List<string> UserIds that mute by user
        {
            return JsonSerializer.Serialize(await _db.UserMutes.Where(m => m.UserId == Params).Select(f => f.MuteAuthorByUser).ToListAsync());
        }

        public async Task<string> GetBlockAuthorList(string Params) // par: string userId // return List<string> UserIds that block by user
        {
            return JsonSerializer.Serialize(await _db.UserBlocks.Where(m => m.UserId == Params).Select(f => f.BlockedAuthorByUser).ToListAsync());
        }

        public async Task<string> GetStoryIdsListByAuthor(string Params) // par: string authorId // return List<string> storyIds that drawed by author and public
        {
            return JsonSerializer.Serialize(await _db.ContentStateStoryWrappers.Where(s => s.StoryCreatorId == Params && s.Status == Enum.StoryStatusEnum.Public).Select(s => s.Id).ToListAsync());
        }

        public async Task<string> GetReadingIdsListByAuthor(string Params) // par: string authorId // return List<string> readingListIds that drawed by author and public
        {
            return JsonSerializer.Serialize(await _db.UsersReadingLists.Where(r => r.UserId == Params && r.Private == false).Select(r => r.Id).ToListAsync());
        }

        public async Task<string> GetUserHeaderStoryId(string Params) // par: string authorId // return UserHeaderDTO by Story
        {
            try
            {
                string author = (await _db.ContentStateStoryWrappers.FindAsync(Params)).StoryCreatorId;
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
                    return JsonSerializer.Serialize(new { Status = "User not Found" });

                }
            }
            catch (DbException ex) 
            {
                return JsonSerializer.Serialize(new { Status = "Story not Found" });
            }
            
        }

        public async Task<string> GetUserHeader(string Params)// par: string AuthorId // return UserHeaderDTO
        {
            UserWrapper User = await _db.UserWrappers.Include(u => u.Profile).Include(u => u.User).FirstOrDefaultAsync(u => u.UserId == Params)!;
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
                return JsonSerializer.Serialize(new { Status = "User not Found" });

            }
        }

        public async Task<string> GetUserCred(string Params)// par: string AuthorId // return UserCredDTO
        {
            UserWrapper User = await _db.UserWrappers.Include(u => u.Profile).Include(u => u.User).FirstOrDefaultAsync(u => u.UserId == Params)!;
            
            if (User != null)
            {
                int FollowedCount = _db.Follows.Where(f => f.IdToFollow == Params).Count();
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
                return JsonSerializer.Serialize(new { Status = "User not Found" });

            }
        }



    }
}
