using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.EntityMap
{
    public class EntityMapModelService(AppDbContext _db) : IEntityMapModelService
    {
        public async Task CreateEntityMap(KeyValuePair<string, EntityMapDTO> EntityMap, string ContentStateId)
        {
            EntityMapModel entityMapModelToCreate = new EntityMapModel {
                id = 0,
                ContentStateKey = ContentStateId,
                DictonaryKey = EntityMap.Key,
                type = EntityMap.Value.type,
                mutability = EntityMap.Value.mutability,
                data = JsonSerializer.Serialize(EntityMap.Value.data)
            };
            await _db.AddAsync(entityMapModelToCreate);
        }

        public async Task UpdateEntityMap(KeyValuePair<string, EntityMapDTO> EntityMap, string ContentStateId)
        {
            EntityMapModel entityMapToUpdate = await _db.EntityMaps.FirstOrDefaultAsync(e => e.DictonaryKey.Equals(EntityMap.Key) && e.ContentStateKey.Equals(ContentStateId));
            if (entityMapToUpdate != null)
            {
                entityMapToUpdate.data = JsonSerializer.Serialize( EntityMap.Value.data);
                await _db.SaveChangesAsync();
            }
            else 
            {
                throw new Exception();
            }
        }

        public async Task DeleteEntityMap(EntityMapModel mapModel)
        {
            _db.Remove(mapModel);
        }

        public async Task SaveEntityMapDictonary(Dictionary<string, EntityMapDTO> EntityDictonary, string ContentStateId)
        {
            List<EntityMapModel> entityList = _db.EntityMaps.Where(e => e.ContentStateKey.Equals(ContentStateId)).ToList();

            foreach (var Entity in EntityDictonary)
            {

                if (entityList.Any(e => e.DictonaryKey == Entity.Key))
                {
                    UpdateEntityMap(Entity, ContentStateId);


                }
                else {
                    CreateEntityMap(Entity, ContentStateId);

                }
            }


            _db.RemoveRange(entityList.Where(e => !EntityDictonary.ContainsKey(e.DictonaryKey)));

        }

        public Task<List<EntityMapModel>> GetEntityMapListForContentState(string ContentStateId)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<string, EntityMapDTO>> GetEntityMapFullDictonaryForContentState(string ContentStateId)
        {
            List<EntityMapModel> EntityMaps = _db.EntityMaps.Where(e => e.ContentStateKey.Equals(ContentStateId)).ToList();

            Dictionary<string, EntityMapDTO> dictonarToReturn = new Dictionary<string, EntityMapDTO>();

            var EntityMapsTasks = EntityMaps.Select(async e => 
            {

                dictonarToReturn.Add(e.DictonaryKey, new EntityMapDTO 
                {
                    type = e.type,
                    mutability = e.mutability,
                    data = e.data,
                });
            });

            await Task.WhenAll(EntityMapsTasks);

            return dictonarToReturn;

        }
    }
}
