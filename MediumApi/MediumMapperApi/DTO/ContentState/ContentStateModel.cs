using MediumMapperApi.Models.ContentState.ContentStatePart;

namespace MediumMapperApi.Models.ContentState
{

    /*
     * Модель для контент Стейта
     */
    public class ContentStateModel
    {
        public string Id { get; set; }
        public List<BlockModel> blocks { get; set; }
        public List<EntityMapModel> entityMap { get; set; } 

    }
}
