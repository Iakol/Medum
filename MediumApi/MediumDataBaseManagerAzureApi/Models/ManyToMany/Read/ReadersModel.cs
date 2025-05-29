using MediumDataBaseManagerAzureApi.Enum;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.ReadingListManyToMany;
using MediumDataBaseManagerAzureApi.Models.User;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany.Read
{
    public class ReadersModel
    {
        public string ReadId { get; set; }// Story or ReaderList
        public string UserId { get; set; }

        public ReaderTypeEnum ReaderTypeEnum { get; set; } // Story or ReaderList
        public UserWrapper User { get; set; }

        public int Claps { get; set; } // claps to story


    }
}
