using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.EntityRange
{
    public class EntityRangeModelService(AppDbContext _db) : IEntityRangeModelService
    {
        public async Task CreateEntityRangeModel(EntityRangeDTO EntityRange, int BlockId)
        {
            await _db.AddAsync(new EntityRangeModel 
            {
                BlockId = BlockId,
                offset = EntityRange.offset,
                length = EntityRange.length,
                key = EntityRange.key
            });
        }

        public async Task CreateEntityRangeModelListForBlockModel(List<EntityRangeDTO> EntityRangeList, int BlockId)
        {
            foreach (var item in EntityRangeList) 
            {
                await CreateEntityRangeModel(item, BlockId);
            }

            _db.SaveChanges();
        }

        public async Task DeleteEntityRangeModel(int EntityRangeModelId)
        {
            EntityRangeModel EntityToDelete = await _db.EntityRanges.FindAsync(EntityRangeModelId)!;
            _db.EntityRanges.Remove(EntityToDelete);
        }

        public async Task DeleteEntityRangeModelListOfBlock(int BlockId)
        {
            List<EntityRangeModel> listTodelete = _db.EntityRanges.Where(er => er.BlockId == BlockId).ToList();

            foreach (EntityRangeModel item in listTodelete)
            {
                await DeleteEntityRangeModel(item.Id);
            }

            await _db.SaveChangesAsync();
        }

        public async Task<EntityRangeDTO> GetEntityRangeModel(int EntityRangeId)
        {
            EntityRangeModel entityRange = await _db.EntityRanges.FindAsync(EntityRangeId);

            return new EntityRangeDTO
            {
                offset = entityRange.offset,
                length = entityRange.length,
                key = entityRange.key,
            };
        }

        public async Task<List<EntityRangeDTO>> GetEntityRangeModelListByBlock(int BlockId)
        {
            return _db.EntityRanges
                .Where(e => e.BlockId == BlockId)
                .Select(e => new EntityRangeDTO 
                {
                    offset = e.offset,
                    length = e.length,
                    key = e.key,
                }).ToList();

        }

        public async Task UpdateEntityRangeModel(EntityRangeDTO EntityRange)
        {
            EntityRangeModel entityRange = await _db.EntityRanges.FirstOrDefaultAsync(e => e.key == EntityRange.key);

            entityRange.offset = EntityRange.offset;
            entityRange.length = EntityRange.length;

            _db.EntityRanges.Update(entityRange);

        }

        public async Task UpSetEntityRangeModelListForBlockModel(List<EntityRangeDTO> EntityRangeList, int BlockId)
        {
            List<EntityRangeModel> listToUpdate = _db.EntityRanges.Where(er => er.BlockId == BlockId).ToList();

            List<EntityRangeModel> listToDelete = listToUpdate.Where(e => !EntityRangeList.Select(eDto => eDto.key).Contains(e.key)).ToList();

            foreach (var item in listToDelete) 
            {
                await DeleteEntityRangeModel(item.Id);
            }

            foreach (EntityRangeDTO item in EntityRangeList)
            {
                if (!listToUpdate.Select(e => e.key).Contains(item.key))
                {
                    await CreateEntityRangeModel(item, BlockId);
                }
                else if (listToUpdate.Select(e => e.key).Contains(item.key))
                {
                    await UpdateEntityRangeModel(item);
                }

            }
            await _db.SaveChangesAsync();
        }
    }
}
