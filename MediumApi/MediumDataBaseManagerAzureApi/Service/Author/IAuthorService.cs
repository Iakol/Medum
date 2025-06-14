using System.Text.Json;

namespace MediumDataBaseManagerAzureApi.Service.Author
{
    public interface IAuthorService
    {
        public Task<string> GetAuthorFollowingAuthors(string Params); // par: string userId ret List<string>

        public Task<string> GetRecomendationAuthorForUser(string Params); //string userId ret List<string> //Template

        public Task<string> MuteAuthorByAuthorId(string Params); // par userID Author Id // return bool
        public Task<string> BlockAuthorByAuthorId(string Params); // par userID Author Id // return bool
        public Task<string> FollowAuthorByAuthorId(string Params); // par userID Author Id // return bool
        public Task<string> UnMuteAuthorByAuthorId(string Params); // par: string authorId, string userId // return bool
        public Task<string> UnBlockAuthorByAuthorId(string Params); // par: string authorId, string userId // return bool
        public Task<string> UnFollowAuthorByAuthorId(string Params); // par: string authorId, string userId// return bool

        public Task<string> GetMuteAuthorList(string Params); // par: string userId // return List<string> UserIds that mute by user
        public Task<string> GetBlockAuthorList(string Params); // par: string userId // return List<string> UserIds that block by user

        public Task<string> GetStoryIdsListByAuthor(string Params); // par: string authorId // return List<string> storyIds that drawed by author

        public Task<string> GetReadingIdsListByAuthor(string Params); // par: string authorId // return List<string> readingListIds that drawed by author
        public Task<string> GetUserHeaderStoryId(string Params); // par: string StoryId // return UserHeaderDTO
        public Task<string> GetUserHeader(string Params);// par: string AuthorId // return UserHeaderDTO
        public Task<string> GetUserCred(string Params);
    }
}
