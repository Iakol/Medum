using MediumApi.DTO.ReadingListDTO;

namespace MediumApi.Service.ReadingList
{
    public class ReadingListService : IReadingListService
    {
        public Task<bool> AddStoryToReadingListByUser(string userId, string storyId, string readingListId)
        {
            var Message = new { user = userId, story = storyId, readingList = readingListId };
        }

        public Task<bool> CreateReadingListByUser(string userId, CreateReadingListDTO readingListToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReadingList(string readingListId, string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStoryFromReadingList(string storyId, string readingListId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetAuthorRedingList(string authorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetReadingHistoryListOfUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetUserReadingLists(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetUserSavedReadingLists(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNoteToStoryInReadingList(string storyid, string readingListId, string TextOfNote)
        {
            throw new NotImplementedException();
        }
    }
}
