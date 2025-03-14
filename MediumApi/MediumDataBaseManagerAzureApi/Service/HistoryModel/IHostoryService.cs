using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Service.HistoryModel
{
    public interface IHostoryService
    {
        public Task AddHistoryForUser(string UserId, string StoryId);
        public Task<List<History>> GetLastHundredHistoryByUser(string UserId, string StoryId);

    }
}
