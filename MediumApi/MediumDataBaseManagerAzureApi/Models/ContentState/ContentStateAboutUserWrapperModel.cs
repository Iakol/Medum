using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ContentState
{

    /*
     * Модель для силки на контент Стейта для Відображення про автора
     */
    public class ContentStateAboutUserWrapperModel
    {
        public string Id { get; set; }
        public ContentStateModel ContentStateModelAboutUser { get; set; }
        public string ContentStateModelAboutUserId { get; set; }
        public UserWrapper User { get; set; }
        public string UserId { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime SaveLastUpdateTime { get; set; }
    }
}
