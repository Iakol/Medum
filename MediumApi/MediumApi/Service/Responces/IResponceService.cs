using MediumApi.DTO.StoryDTO.ResponceDTO;

namespace MediumApi.Service.Responces
{
    public interface IResponceService
    {
        public Task<bool> AddResponceByUser(string UserID, string readId, string TextOfResponce, int? ResponseId, int readType);


        public Task<List<ResponceDTO>> GetResponce(string readId, int readType);


        public Task<int> GetResponceCount(string readId, int readType);


        public Task<bool> DeleteResponceByResponceid(int responceId);



    }
}
