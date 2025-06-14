using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;

namespace MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.EntityRange
{
    public interface IEntityRangeModelService
    {
        public Task CreateEntityRangeModel(EntityRangeDTO EntityRange, int BlockId);
        public Task DeleteEntityRangeModel(int EntityRangeModelId);

        public Task DeleteEntityRangeModelListOfBlock(int BlockId);

        public Task UpdateEntityRangeModel(EntityRangeDTO EntityRange);
        public Task<EntityRangeDTO> GetEntityRangeModel(int EntityRangeId);
        public Task<List<EntityRangeDTO>> GetEntityRangeModelListByBlock(int BlockId);
        public Task CreateEntityRangeModelListForBlockModel(List<EntityRangeDTO> EntityRangeList, int BlockId);
        public Task UpSetEntityRangeModelListForBlockModel(List<EntityRangeDTO> EntityRangeList, int BlockId);

    }
}
