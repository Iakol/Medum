using MediumApi.DTO.ReadingListDTO;

namespace MediumApi.Service.ReadingList
{
    public interface IReadingListService
    {
        public Task<bool> AddStoryToReadingListByUser(string userId, string storyId, string readingListId);



        public Task<bool> DeleteReadingList(string readingListId, string UserId);
        public Task<bool> DeleteStoryFromReadingList(string storyId, string readingListId, string userId);

        public Task<bool> CreateReadingListByUser( CreateReadingListDTO readingListToCreate);
        public Task<bool> UpdateReadingListByUser( CreateReadingListDTO readingListToChangeCred);


        public Task<List<string>> GetUserReadingLists(string userId);
        public Task<List<string>> GetUserSavedReadingLists(string userId);
        public Task<List<string>> GetAuthorRedingList(string authorId);

        public Task<bool> UpdateNoteToStoryInReadingList(string storyid, string readingListId, string TextOfNote, string UserId);
        
        public Task<ReadingListDTO> GetReadingListById(string id);
        public Task<bool> DeleteSaveReadingList(string readingListId, string UserId);
        public Task<bool> SaveAuthorReadingList(string readingListId, string UserId);
        public Task<bool> UnSaveAuthorReadingList(string readingListId, string UserId);


        public Task<List<ReadingListDTO>> GetReadingListByIdList(List<string> readingListIdList, string UserId);

    }
}
