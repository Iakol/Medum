using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.DictonaryDataInBlock;
using MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.EntityRange;
using MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.InlineStylesRange;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.Block
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

        public async Task<BlockDTO> GetBlock(string BlockKey, string ContentStateId)
        {
            BlockModel block = await _db.Blocks.FirstOrDefaultAsync(b => b.key.Equals(BlockKey) && b.ContentStateId.Equals(ContentStateId));

            return new BlockDTO
            {
                key = block.key,
                text = block.text,
                type = block.type,
                depth = block.depth,
                inlineStyleRanges = await _inlineStylesRangeService.GetInlineStylesRangeModelByBlock(block.Id),
                entityRanges = await _entityRangeModelService.GetEntityRangeModelListByBlock(block.Id),
                data = await _dictonaryDataInBlockModelService.GetDictonaryDataInBlockModel(block.Id)
            };
        }

        public async Task<List<BlockDTO>> GetBlockListByStory(string ContentStateId)
        {
            var blocs = await _db.Blocks.Where(b => b.ContentStateId.Equals(ContentStateId)).ToListAsync();
            var blocksDtoTasks = blocs.Select(async b =>
            {
                var inlinetRangesList = await _inlineStylesRangeService.GetInlineStylesRangeModelByBlock(b.Id);
                var entityRanges = await _entityRangeModelService.GetEntityRangeModelListByBlock(b.Id);
                var data = await _dictonaryDataInBlockModelService.GetDictonaryDataInBlockModel(b.Id);
                return new BlockDTO
                {
                    key = b.key,
                    text = b.text,
                    type = b.type,
                    depth = b.depth,
                    inlineStyleRanges = inlinetRangesList,
                    entityRanges = entityRanges,
                    data = data
                };

            });

            var blockDtos = await Task.WhenAll(blocksDtoTasks);

            return blockDtos.ToList();
        }

        public async Task UpdateBlockModel(BlockDTO block, string ContentStateId)
        {
            BlockModel blockToUpdate = await _db.Blocks.FirstOrDefaultAsync(b => b.key.Equals(block.key) && b.ContentStateId.Equals(ContentStateId));

            blockToUpdate.text = block.text;
            blockToUpdate.type = block.type;
            blockToUpdate.depth = block.depth;
            await _inlineStylesRangeService.UpdateInlineStylesRangeModelInBlock(block.inlineStyleRanges, blockToUpdate.Id);
            await _entityRangeModelService.UpSetEntityRangeModelListForBlockModel(block.entityRanges, blockToUpdate.Id);
            await _dictonaryDataInBlockModelService.UpdateDictonaryInBlockModel(block.data, blockToUpdate.Id);

        }




    }
}
