using MediumApi.DTO.AuthorDTO;

namespace MediumApi.Service.Authors
{
    public interface IAuthorService
    {
        public Task<List<string>> GetAuthorFollowingAuthors(string userId);

        public Task<List<string>> GetRecomendationAuthorForUser(string userId);

        public Task<string> MuteAuthorByAuthorId(string authorId, string userId);
        public Task<string> BlockAuthorByAuthorId(string authorId, string userId);
        public Task<string> FollowAuthorByAuthorId(string authorId, string userId);

        public Task<string> UnMuteAuthorByAuthorId(string authorId, string userId);
        public Task<string> UnBlockAuthorByAuthorId(string authorId, string userId);
        public Task<string> UnFollowAuthorByAuthorId(string authorId, string userId);

        public Task<List<string>> GetMuteAuthorList(string userId);
        public Task<List<string>> GetBlockAuthorList(string userId);

        public Task<List<string>> GetStoryIdsListByAuthor(string authorId);

        public Task<List<int>> GetReadingIdsListByAuthor(string authorId);
        public Task<AuthorHeaderDTO> GetUserHeaderStoryId(string storyId);
        public Task<AuthorHeaderDTO> GetUserHeader(string authorId);
        public Task<AuthorCredDTO> GetUserCred(string authorId);








    }
}
