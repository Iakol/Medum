using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState;

namespace MediumDataBaseManagerAzureApi.Service.ContentState
{
    public interface IContentStateService
    {
        public Task<ContentStateDTO> GetContentStateById(string id);
        public Task SaveContentStateById(ContentStateDTO contentState);

        public void SaveContentStateByIdInRedis();
        public Task SaveContentStateByIdInDataBase(ContentStateDTO content);



        public void GetContentStateByIdFromRedis(string id);
        public void GetContentStateByIdFromDataBase(string id);

    }
}
