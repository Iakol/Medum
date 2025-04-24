using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;

namespace MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.Block
{
    public interface IBlockModelService
    {
        public Task CreateBlockModel(BlockDTO block, string ContentStateId);
        public Task DeleteBlockModel(int BlockId);
        public Task UpdateBlockModel(BlockDTO block);
        public Task<BlockDTO> GetBlock(string ContentStateId);
        public Task<List<BlockDTO>> GetBlockListByStory(string ContentStateId, int id );


    }
}
