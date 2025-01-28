namespace MediumDataBaseManagerAzureApi.Service.ContentState
{
    public interface IContentState
    {
        public void GetContentStateById(string id);
        public void SaveContentStateById();

        public void SaveContentStateByIdInRedis();
        public void SaveContentStateByIdInDataBase();



        public void GetContentStateByIdFromRedis(string id);
        public void GetContentStateByIdFromDataBase(string id);

    }
}
