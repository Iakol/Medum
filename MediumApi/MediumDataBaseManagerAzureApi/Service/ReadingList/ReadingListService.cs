using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.User;
using System.Text.Json;

namespace MediumDataBaseManagerAzureApi.Service.ReadingList
{
    public class ReadingListService(AppDbContext _db) : IReadingListService
    {
        public async Task<string> AddStoryToReadingListByUser(string Params) //string userId, string storyId, string readingListId // return bool
        {
            var json = JsonSerializer.Deserialize<JsonElement>(Params);

            UserReadingList readingListToStoryAdd = _db.UsersReadingLists.FirstOrDefault(r => r.Id.Equals(json.GetProperty("readingList").ToString()));
            if (readingListToStoryAdd != null) 
            {
                if (readingListToStoryAdd.UserId.Equals(json.GetProperty("user"))) 
                {
                    ContentStateStoryWrapperModel 
                }
            }
        }
    }
}
