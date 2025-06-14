using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using System.Text.Json;

namespace MediumDataBaseManagerAzureApi.Service.ContentState.ContentStateParts.DictonaryDataInBlock
{
    public class DictonaryDataInBlockModelService(AppDbContext _db) : IDictonaryDataInBlockModelService
    {
        public async Task CreateDictonaryDataInBlockModel(KeyValuePair<string, string> data, int blockId)
        {
            DictonaryDataInBlockModel DictonaryDataInBlockModelToCreate = new DictonaryDataInBlockModel
            {
                Id = 0,
                BlockId = blockId,
                DictonaryKey = data.Key,
                obj = JsonSerializer.Serialize(data.Value)
            };
            await _db.AddAsync(DictonaryDataInBlockModelToCreate);
        }

        public async Task SaveDictonaryDataInBlockModel(Dictionary<string, string> DictonaryDataInBlockModel, int BlockId)
        {
            foreach (var item in DictonaryDataInBlockModel)
            {
                await CreateDictonaryDataInBlockModel(item, BlockId);
            }
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDictonaryDataListInBlockByBlockIdModel(int blockId)
        {
            _db.RemoveRange(_db.DictonaryDataInBlocks.Where(d => d.BlockId == blockId));
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDictonaryDataRecordInBlockByRecordKey(string key)
        {
            _db.Remove(_db.DictonaryDataInBlocks.FirstOrDefault(d => d.DictonaryKey.Equals(key)));

        }

        public async Task<Dictionary<string, string>> GetDictonaryDataInBlockModel(int BlockId)
        {
            List<DictonaryDataInBlockModel> dictonaryList = _db.DictonaryDataInBlocks.Where(d => d.BlockId == BlockId).ToList();

            Dictionary<string, string> blockDataDictonary = new Dictionary<string, string>();

            foreach (var item in dictonaryList)
            {
                blockDataDictonary.Add(item.DictonaryKey, item.obj);
            }

            return blockDataDictonary;

        }

        public async Task<List<DictonaryDataInBlockModel>> GetDictonaryListDataInBlockModel(int BlockId)
        {
            return _db.DictonaryDataInBlocks.Where(d => d.BlockId == BlockId).ToList();
        }



        public async Task UpdateDictonaryDataInBlockModel(KeyValuePair<string, string> data, int blockId)
        {
            DictonaryDataInBlockModel dictonaryData = _db.DictonaryDataInBlocks.FirstOrDefault(o => o.DictonaryKey == data.Key);
            dictonaryData.obj = data.Value;

            _db.DictonaryDataInBlocks.Update(dictonaryData);
            _db.SaveChanges();
        }

        public async Task UpdateDictonaryInBlockModel(Dictionary<string, string> dictonary, int blockId)
        {
            List<DictonaryDataInBlockModel> dictonaryList = _db.DictonaryDataInBlocks.Where(d => d.BlockId == blockId).ToList();


            foreach (var item in dictonaryList)
            {
                if (!dictonary.ContainsKey(item.DictonaryKey))
                {
                    await DeleteDictonaryDataRecordInBlockByRecordKey(item.DictonaryKey);
                }
                else if (dictonary.ContainsKey(item.DictonaryKey))
                {
                    await UpdateDictonaryDataInBlockModel(dictonary.FirstOrDefault(dp => dp.Key == item.DictonaryKey), blockId);
                }

            }

            foreach (var item in dictonary)
            {
                if (dictonaryList.Select(dl => dl.DictonaryKey).Contains(item.Key))
                {
                    await CreateDictonaryDataInBlockModel(item, blockId);
                }
            }
        }
    }
}
