using MediumMapperApi.DTO.ContentStateDTO;
using MediumMapperApi.Models.ContentState;
using MediumMapperApi.Models.ContentState.ContentStatePart;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediumMapperApi.Service.ContentState
{
    public class ContentState : IContentState
    {
        public ContentStateDTO ContentBazeToStateDto(ContentStateModel baseModel)
        {
            ContentStateDTO parseRes = new ContentStateDTO();
            parseRes.id = baseModel.Id;
            parseRes.blocks = BlockFromBazeToBlockDTO(baseModel.blocks);
            parseRes.entityMap = EntityMapBaseToEntityMapDTO(baseModel.entityMap);
            return parseRes;
        }


        public Dictionary<string, EntityMapDTO> EntityMapBaseToEntityMapDTO(List<EntityMapModel> entityMap) 
        {
            Dictionary<string, EntityMapDTO> dictonary = new Dictionary<string, EntityMapDTO>();

            foreach (var item in entityMap) 
            {
                dictonary[item.DictonaryKey] = new EntityMapDTO
                {
                    type = item.type,
                    mutability = item.mutability,
                    data = item.data

                };
            }
            return dictonary;


        }

        public List<BlockDTO> BlockFromBazeToBlockDTO(List<BlockModel> BazeBlocks) 
        {
            List< BlockDTO > blocks = new List< BlockDTO >();

            foreach (var item in BazeBlocks) 
            {
                blocks.Add(new BlockDTO
                {
                    key = item.key,
                    text = item.text,
                    type = item.type,
                    depth = item.depth,
                    inlineStyleRanges = InlineStylesFromBlockBaseToInlineStylesRangeDTO(item.inlineStyleRanges),
                    entityRanges = EntityRangeFromBaseBlockToEntityRangeDTO(item.entityRanges),
                    data = DataFromBaseBlockToDictionary(item.data)
                });
            }

            return blocks;
        }

        public Dictionary<string, string> DataFromBaseBlockToDictionary(List<DictonaryDataInBlockModel> dataDataInBlockModel) 
        {
            Dictionary<string, string> dictonary = new Dictionary<string, string>();

            foreach (var item in dataDataInBlockModel) 
            {
                dictonary[item.DictonaryKey] = item.obj;            
            }

            return dictonary;
        }


        public List<InlineStylesRangeDTO> InlineStylesFromBlockBaseToInlineStylesRangeDTO(List<InlineStylesRangeModel> inlineStyleRangeModelList) 
        {
            List<InlineStylesRangeDTO> inlineStylesRangeDTOs = new List< InlineStylesRangeDTO>();

            foreach (var item in inlineStyleRangeModelList) 
            {
                inlineStylesRangeDTOs.Add(new InlineStylesRangeDTO
                {
                    offset = item.offset,
                    length = item.length,
                    style = item.style,
                });
            }

            return inlineStylesRangeDTOs;
        }

        public List<EntityRangeDTO> EntityRangeFromBaseBlockToEntityRangeDTO(List<EntityRangeModel> entityRangeModels) 
        {
            List<EntityRangeDTO> EntityRangeDTOs = new List<EntityRangeDTO>();

            foreach (var item in entityRangeModels)
            {
                EntityRangeDTOs.Add(new EntityRangeDTO
                {
                    offset = item.offset,
                    length = item.length,
                    key = item.key,
                });
            }

            return EntityRangeDTOs;
        }

        public ContentStateModel ContentStateDtoToBaze(ContentStateDTO dTO)
        {
            ContentStateModel parseRes = new ContentStateModel();

            return parseRes;
        }
    }
}
