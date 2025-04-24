using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using Microsoft.EntityFrameworkCore;

namespace MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.InlineStylesRange
{
    public class InlineStylesRangeModelService(AppDbContext _db) : IInlineStylesRangeModelService
    {
        public async Task CreateInlineStylesRangeListForBlockModel(List<InlineStylesRangeDTO> InlineStylesRangeList, int BlockId)
        {
            foreach (var item in InlineStylesRangeList) 
            {
                 await CreateInlineStylesRangeModel(item, BlockId);
            }
            _db.SaveChanges();
        }

        public async Task CreateInlineStylesRangeModel(InlineStylesRangeDTO InlineStylesRange, int BlockId)
        {
            await _db.InlineStylesRanges.AddAsync(new InlineStylesRangeModel {
                BlockId = BlockId,
                offset = InlineStylesRange.offset,
                length = InlineStylesRange.length,
                style = InlineStylesRange.style,
            });
        }

        public async Task DeleteInlineStylesRangeModel(int InlineStylesRangeId)
        {
            try 
            {
                _db.InlineStylesRanges.Remove(await _db.InlineStylesRanges.FindAsync(InlineStylesRangeId));
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);// change tp logs
             }
        }

        public async Task DeleteInlineStylesRangeModelListOfBlock(int BlockId)
        {
            _db.InlineStylesRanges.RemoveRange(_db.InlineStylesRanges.Where(i => i.BlockId == BlockId));
        }

        public async Task<InlineStylesRangeDTO> GetInlineStylesRangeModel(int InlineStylesRangeModelId)
        {
            InlineStylesRangeModel item = await _db.InlineStylesRanges.FirstOrDefaultAsync(i => i.Id == InlineStylesRangeModelId);
            return new InlineStylesRangeDTO 
            {
                offset = item.offset,
                length = item.length,
                style = item.style,
            };
        }

        public async Task<List<InlineStylesRangeDTO>> GetInlineStylesRangeModelByBlock(int BlockId)
        {
            return _db.InlineStylesRanges.Where(i => i.BlockId == BlockId).Select(i => new InlineStylesRangeDTO
            {
                offset = i.offset,
                length = i.length,
                style = i.style,
            }).ToList();
        }

        public async Task UpdateInlineStylesRangeModelInBlock(List<InlineStylesRangeDTO> InlineStylesRange,int BlockId)
        {
            await DeleteInlineStylesRangeModelListOfBlock(BlockId);
            await CreateInlineStylesRangeListForBlockModel(InlineStylesRange, BlockId);
        }
    }
}
