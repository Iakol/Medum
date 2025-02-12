using MediumMapperApi.DTO.ContentStateDTO;
using MediumMapperApi.Models.ContentState;

namespace MediumMapperApi.Service.ContentState
{
    public interface IContentState
    {
        public ContentStateModel ContentStateDtoToBaze(ContentStateDTO dTO);
    }
}
