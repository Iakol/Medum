using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;

namespace MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.EntityMap
{
    public interface IEntityMapModelService
    {
        public Task CreateEntityMap(KeyValuePair<string, EntityMapDTO> EntityMap, string ContentStateId);
        public Task DeleteEntityMap(EntityMapModel mapModel);

        public Task<List<EntityMapModel>> GetEntityMapListForContentState(string ContentStateId);
        public Task<Dictionary<string, EntityMapDTO>> GetEntityMapFullDictonaryForContentState(string ContentStateId);


        public Task UpdateEntityMap(KeyValuePair<string, EntityMapDTO> EntityMap, string ContentStateId);

        public Task SaveEntityMapDictonary(Dictionary<string, EntityMapDTO> EntitiyDictonary, string ContentStateId);



    }
}
