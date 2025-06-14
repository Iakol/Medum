using MediumApi.DTO.AuthorDTO;

namespace MediumApi.Service.Authors
{
    public interface IAuthorService
    {
        public Task<List<string>> GetAuthorFollowingAuthors(string userId);

        public Task<List<string>> GetRecomendationAuthorForUser(string userId);

        public Task MuteAuthorByAuthorId(string authorId, string userId);
        public Task BlockAuthorByAuthorId(string authorId, string userId);
        public Task FollowAuthorByAuthorId(string authorId, string userId);

        public Task UnMuteAuthorByAuthorId(string authorId, string userId);
        public Task UnBlockAuthorByAuthorId(string authorId, string userId);
        public Task UnFollowAuthorByAuthorId(string authorId, string userId);

        public Task<List<string>> GetMuteAuthorList(string userId);
        public Task<List<string>> GetBlockAuthorList(string userId);

        public Task<List<string>> GetStoryIdsListByAuthor(string authorId);

        public Task<List<int>> GetReadingIdsListByAuthor(string authorId);
        public Task<AuthorHeaderDTO> GetUserHeaderStoryId(string storyId);
        public Task<AuthorHeaderDTO> GetUserHeader(string authorId);
        public Task<AuthorCredDTO> GetUserCred(string authorId);








    }
}
