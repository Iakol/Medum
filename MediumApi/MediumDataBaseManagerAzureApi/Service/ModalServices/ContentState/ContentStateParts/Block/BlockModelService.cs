using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.Block;
using MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.DictonaryDataInBlock;
using MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.EntityRange;
using MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.InlineStylesRange;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Net.Mime.MediaTypeNames;

namespace MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.Block
{
    public class BlockModelService(AppDbContext _db,
        IInlineStylesRangeModelService _inlineStylesRangeService,
        IEntityRangeModelService _entityRangeModelService,
        IDictonaryDataInBlockModelService _dictonaryDataInBlockModelService) : IBlockModelService
    {


        public async Task CreateBlockModel(BlockDTO block, string ContentStateId)
        {

            BlockModel newblock = new BlockModel
            {
                ContentStateId = ContentStateId,
                key = block.key,
                text = block.text,
                type = block.type,
                depth = block.depth,
                inlineStyleRanges = new List<InlineStylesRangeModel>(),
                entityRanges = new List<EntityRangeModel>(),
                data = new List<DictonaryDataInBlockModel>()
            };
            await _db.Blocks.AddAsync(newblock);

            _db.SaveChanges();

            await _inlineStylesRangeService.CreateInlineStylesRangeListForBlockModel(block.inlineStyleRanges, newblock.Id);
            await _entityRangeModelService.CreateEntityRangeModelListForBlockModel(block.entityRanges, newblock.Id);
            await _dictonaryDataInBlockModelService.SaveDictonaryDataInBlockModel(block.data, newblock.Id);

        }

        public async Task DeleteBlockModel(int BlockId)
        {
            try
            {
                await _inlineStylesRangeService.DeleteInlineStylesRangeModelListOfBlock(BlockId);
                await _entityRangeModelService.DeleteEntityRangeModelListOfBlock(BlockId);
                await _dictonaryDataInBlockModelService.DeleteDictonaryDataListInBlockByBlockIdModel(BlockId);
                _db.Blocks.Remove(await _db.Blocks.FindAsync(BlockId));
                await _db.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString()); // create Custom Exeption add logs
            }
            

        }

        public Task<BlockDTO> GetBlock(string ContentStateId)
        {
            
        }

        public Task<List<BlockModel>> GetBlockListByStory(string ContentStateId, int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBlockModel(BlockDTO block)
        {
            throw new NotImplementedException();
        }
    }
}
