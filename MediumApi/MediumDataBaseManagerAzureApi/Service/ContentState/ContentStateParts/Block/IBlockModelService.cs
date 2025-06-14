using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;

namespace MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.Block
{
    public interface IBlockModelService
    {
        public Task CreateBlockModel(BlockDTO block, string ContentStateId);
        public Task DeleteBlockModel(int BlockId);
        public Task UpdateBlockModel(BlockDTO block, string ContentStateId);
        public Task<BlockDTO> GetBlock(string BlockKey, string ContentStateId);
        public Task<List<BlockDTO>> GetBlockListByStory(string ContentStateId);


    }
}
