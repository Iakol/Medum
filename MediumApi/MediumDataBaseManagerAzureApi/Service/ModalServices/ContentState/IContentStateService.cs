using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState;

namespace MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState
{
    public interface IContentStateService
    {
        public Task<ContentStateModel> GetContentStateById(string id);
        public void SaveContentStateById();

        public void SaveContentStateByIdInRedis();
        public Task SaveContentStateByIdInDataBase(ContentStateDTO content);



        public void GetContentStateByIdFromRedis(string id);
        public void GetContentStateByIdFromDataBase(string id);

    }
}
