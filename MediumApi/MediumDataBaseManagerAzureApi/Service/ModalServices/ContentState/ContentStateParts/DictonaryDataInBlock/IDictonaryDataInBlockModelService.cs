using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;

namespace MediumDataBaseManagerAzureApi.Service.ModalServices.ContentState.ContentStateParts.DictonaryDataInBlock
{
    public interface IDictonaryDataInBlockModelService
    {
        public Task CreateDictonaryDataInBlockModel(KeyValuePair<string, string> data , int blockId);
        public Task DeleteDictonaryDataListInBlockByBlockIdModel(int blockId);

        public Task DeleteDictonaryDataRecordInBlockByRecordKey(string key);


        public Task<List<DictonaryDataInBlockModel>> GetDictonaryListDataInBlockModel(int BlockId);

        public Task UpdateDictonaryDataInBlockModel(KeyValuePair<string, string> data, int blockId);
        public Task UpdateDictonaryInBlockModel(Dictionary<string, string> dictonary, int blockId);


        public Task SaveDictonaryDataInBlockModel(Dictionary<string, string> DictonaryDataInBlockModel, int BlockId);

        public Task<Dictionary<string, string>> GetDictonaryDataInBlockModel(int BlockId);
    }
}
