using MediumDataBaseManagerAzureApi.Service.Author.ParamsDTO;
using System.Text.Json;

namespace MediumDataBaseManagerAzureApi.Service.Author
{
    public interface IAuthorService
    {
        public Task<List<string>> GetAuthorFollowingAuthors(string userId); // par: string userId ret List<string>

        public Task<List<string>> GetRecomendationAuthorForUser(string userId); //string userId ret List<string> //Template

        public Task<string> MuteAuthorByAuthorId(AuthorToUserDTO Params); // par userID Author Id // return bool
        public Task<string> BlockAuthorByAuthorId(AuthorToUserDTO Params); // par userID Author Id // return bool
        public Task<string> FollowAuthorByAuthorId(AuthorToUserDTO Params); // par userID Author Id // return bool
        public Task<string> UnMuteAuthorByAuthorId(AuthorToUserDTO Params); // par: string authorId, string userId // return bool
        public Task<string> UnBlockAuthorByAuthorId(AuthorToUserDTO Params); // par: string authorId, string userId // return bool
        public Task<string> UnFollowAuthorByAuthorId(AuthorToUserDTO Params); // par: string authorId, string userId// return bool

        public Task<List<string>> GetMuteAuthorList(string userId); // par: string userId // return List<string> UserIds that mute by user
        public Task<List<string>> GetBlockAuthorList(string userId); // par: string userId // return List<string> UserIds that block by user

        public Task<List<string>> GetStoryIdsListByAuthor(string authorId); // par: string authorId // return List<string> storyIds that drawed by author

        public Task<List<string>> GetReadingIdsListByAuthor(string authorId); // par: string authorId // return List<string> readingListIds that drawed by author
        public Task<string> GetUserHeaderStoryId(string stroryId); // par: string StoryId // return UserHeaderDTO
        public Task<string> GetUserHeader(string AuthorId);// par: string AuthorId // return UserHeaderDTO
        public Task<string> GetUserCred(string AuthorId); // par: string AuthorId // return UserHeaderDTO
    }
}
