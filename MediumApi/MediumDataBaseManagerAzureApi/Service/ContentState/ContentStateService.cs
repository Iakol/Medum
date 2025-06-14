using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.Block;
using MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.EntityMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace MediumDataBaseManagerAzureApi.Service.ContentState
{
    public class ContentStateService(AppDbContext _db, IBlockModelService _blockService, IEntityMapModelService _entityMapService) : IContentStateService
    {

        public async Task<ContentStateDTO> GetContentStateById(string id)
        {
            if (_db.ContentStates.Any(c => c.Id.Equals(id)))
            {
                ContentStateDTO ContentState = new ContentStateDTO
                {
                    id = id,
                    changeCommitTime = DateTime.UtcNow,
                    blocks = await _blockService.GetBlockListByStory(id),
                    entityMap = await _entityMapService.GetEntityMapFullDictonaryForContentState(id),

                };
                return ContentState;
            }
            throw new NotImplementedException();
        }

        public async Task SaveContentStateById(ContentStateDTO contentState)
        {

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
