using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using Microsoft.EntityFrameworkCore;

namespace MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState
{
    public class ContentStateService(AppDbContext _db) : IContentStateService
    {

        public async Task<ContentStateModel> GetContentStateById(string id)
        {
            ContentStateModel ContentState = await _db.ContentStates.FirstOrDefaultAsync(c => c.Id.Equals(id));

            ContentState.blocks = new blo();
            ContentState.blocks = new blocks();





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



        public Task SaveContentStateByIdInDataBase(ContentStateDTO content)
        {
            throw new NotImplementedException();
        }

        public void SaveContentStateByIdInRedis()
        {
            throw new NotImplementedException();
        }
    }
}
