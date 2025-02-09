using MediumDataBaseManagerAzureApi.Models.ContentState;

namespace MediumDataBaseManagerAzureApi.Service.ContentState
{
    public class ContentStateService : IContentStateService
    {
        public async Task<ContentStateModel> GetContentStateById(string id)
        {
            return new ContentStateModel();
        }

        public void SaveContentStateById()
        {
            throw new NotImplementedException();
        }


        public void GetContentStateByIdFromDataBase(string id)
        {
            throw new NotImplementedException();
        }

        public void GetContentStateByIdFromRedis(string id)
        {
            throw new NotImplementedException();
        }

        

        public void SaveContentStateByIdInDataBase()
        {
            throw new NotImplementedException();
        }

        public void SaveContentStateByIdInRedis()
        {
            throw new NotImplementedException();
        }
    }
}
