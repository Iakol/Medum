using MediumApi.DTO.AuthorDTO;

namespace MediumApi.Service.ReadingHistory
{
    public interface IReadingHistory
    {
        public Task<AuthorCredDTO> GetUserReadingHistory(string userId);
        public Task ClearUserReadingHistory(string userId);

    }
}
