using MediumApi.DTO.AuthorDTO;

namespace MediumApi.DTO.StoryDTO.StoryCredDTO
{
    public class StoryForListDTO
    {
        public StoryCredForStoryForListDTO Story { get; set; }
        public AuthorHeaderDTO User { get; set; }

    }
}
