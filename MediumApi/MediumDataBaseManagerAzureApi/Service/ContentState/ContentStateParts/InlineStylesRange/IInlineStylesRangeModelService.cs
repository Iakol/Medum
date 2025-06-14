using MediumDataBaseManagerAzureApi.DTO.ContentStateDTO;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;

namespace MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.InlineStylesRange
{
    public interface IInlineStylesRangeModelService
    {
        public Task CreateInlineStylesRangeModel(InlineStylesRangeDTO InlineStylesRange, int BlockId);
        public Task DeleteInlineStylesRangeModel(int InlineStylesRangeId);
        public Task DeleteInlineStylesRangeModelListOfBlock(int BlockId);

        public Task UpdateInlineStylesRangeModelInBlock(List<InlineStylesRangeDTO> InlineStylesRange, int BlockId);
        public Task<InlineStylesRangeDTO> GetInlineStylesRangeModel(int InlineStylesRangeModelId);
        public Task<List<InlineStylesRangeDTO>> GetInlineStylesRangeModelByBlock(int BlockId);
        public Task CreateInlineStylesRangeListForBlockModel(List<InlineStylesRangeDTO> InlineStylesRangeList, int BlockId);

    }
}
