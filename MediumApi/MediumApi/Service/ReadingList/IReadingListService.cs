using MediumApi.DTO.ReadingListDTO;

namespace MediumApi.Service.ReadingList
{
    public interface IReadingListService
    {
        public Task<bool> AddStoryToReadingListByUser(string userId, string storyId, string readingListId);

        public Task<bool> DeleteReadingList(string readingListId, string UserId);
        public Task<bool> DeleteStoryFromReadingList(string storyId, string readingListId, string userId);

        public Task<bool> CreateReadingListByUser(string userId, CreateReadingListDTO readingListToCreate);
        public Task<bool> UpdateReadingListByUser(string userId,string readingListId, CreateReadingListDTO readingListToChangeCred);


        public Task<List<string>> GetUserReadingLists(string userId);
        public Task<List<string>> GetUserSavedReadingLists(string userId);
        public Task<List<string>> GetAuthorRedingList(string authorId);

        public Task<bool> UpdateNoteToStoryInReadingList(string storyid, string readingListId, string TextOfNote, string UserId);
                
        
    }
}
