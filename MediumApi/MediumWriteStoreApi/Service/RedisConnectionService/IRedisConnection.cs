using MediumWriteStoreApi.DTO.ContentStateDTO;
using MediumWriteStoreApi.DTO.WebSocetDTO;

namespace MediumWriteStoreApi.Service.RedisConnectionService
{
    public interface IRedisConnection
    {
        public Task<ContentStateDTO?> getContent(string id);
        public void AddContentAfterWebSoketDisconect(SessionData data);
        public Task<ContentStateDTO?> GetContentAfterReconect(string ContentId);
        public Task SaveContentInRedis(ContentStateDTO ContentState);



    }
}
