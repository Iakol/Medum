using MediumWriteStoreApi.BackgroundServices.RedisContextService;
using MediumWriteStoreApi.DTO.ContentStateDTO;
using MediumWriteStoreApi.DTO.WebSocetDTO;
using MediumWriteStoreApi.Service.RedisContexTimerListService;
using StackExchange.Redis;
using System.Text.Json;

namespace MediumWriteStoreApi.Service.RedisConnectionService
{
    public class RedisConnection : IRedisConnection
    {
        private readonly RedisContexTimerList _redisTimerList;
        private readonly IDatabase _redis;

        public async Task AddMessageToRedis(string key, string value)
        {
            await _redis.StringSetAsync(key, value);
        }

        public async Task<string?> GetMessageFromRedis(string key)
        {
            var res = await _redis.StringGetAsync(key);
            if (res.IsNullOrEmpty)
            {
                return null;

            }
            else 
            {
                return res.ToString();
            }

        }


        public void AddContentAfterWebSoketDisconect(SessionData data)
        {
            SaveContentInRedis(data.ContentState.ContentState);
            _redisTimerList.AddTimer(data.ContentState.ContentState.id);
        }

        public async Task<ContentStateDTO?> GetContentAfterReconect(string ContentId) 
        {
            ContentStateDTO? content = await getContent(ContentId);
            _redisTimerList.CancelTimerByContextId(ContentId);
            return content;
        }

        public void GetSessionByContentId(string id) 
        {
            throw new NotImplementedException();

        }

        public async Task<ContentStateDTO?> getContent(string id)
        {
            string? content = await GetMessageFromRedis(id);
            if (content != null)
            {
                return null;
            }
            else 
            {
                return JsonSerializer.Deserialize<ContentStateDTO>(content!);
            }
        }
        public async Task SaveContentInRedis(ContentStateDTO ContentState) 
        {
            string json = JsonSerializer.Serialize(ContentState);
            await AddMessageToRedis(ContentState.id, json);
        }

    }
}
