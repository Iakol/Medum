using MediumWriteStoreApi.DTO.ContentStateDTO;
using System.Net.WebSockets;

namespace MediumWriteStoreApi.Service.ContentState
{
    public interface IContentStateService
    {
        public ContentStateDTO SetChanges(ContentStateDTO content);
        public Task SetContentById(WebSocket socet, string id);
        public void DeleteContent(string id);

    }
}
