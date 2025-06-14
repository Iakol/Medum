namespace MediumDataBaseManagerAzureApi.Service.ReadingList
{
    public interface IReadingListService
    {
        public Task<string> AddStoryToReadingListByUser(string Params); //string userId, string storyId, string readingListId // return bool

        public Task<string> DeleteReadingList(string Params);// string readingListId, string UserId// return bool
        public Task<string> DeleteStoryFromReadingList(string Params); //string storyId, string readingListId, string userId // return bool

        public Task<string> CreateReadingListByUser(string Params); // string userId, CreateReadingListDTO readingListToCreate // return 
        public Task<string> UpdateReadingListByUser(string Params);//string userId, string readingListId, CreateReadingListDTO readingListToChangeCred // return bool


        public Task<string> GetUserReadingLists(string Params); // string userId // return List<string> readinglistids
        public Task<string> GetUserSavedReadingLists(string Params); // string userId // return List<string> ReadingListIds
        public Task<string> GetAuthorRedingList(string Params);//string authorId // return List<string> ReadingListIds

        public Task<string> UpdateNoteToStoryInReadingList(string Params);//string storyid, string readingListId, string TextOfNote, string UserId// return bool 


    }
}
