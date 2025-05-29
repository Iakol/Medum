using MediumApi.DTO.AuthorDTO;
using MediumApi.DTO.StoryDTO.StoryCredDTO;
using MediumApi.RabbitMQCover;
using MediumApi.Service.Authors;
using MediumApi.Service.ConccurentDictonryForReplyTask;
using RabbitMQ.Client;
using System.Text.Json;

namespace MediumApi.Service.Story
{
    public class StoryCredService(RabitMqGlobalDataClass _rabbitClient, IAuthorService _AuthorService) : IStoryCredService
    {

        public async Task<StoryForListDTO> GetStoryCredByStoryID(string storyId)
        {
            StoryForListDTO Story = new StoryForListDTO
            {
                Story = await GetStoryCredForStoryList(storyId),
                User = await _AuthorService.GetUserHeaderStoryId(storyId),
            };


            //
            return Story;
        }

        public async Task<StoryCredForStoryForListDTO> GetStoryCredForStoryList(string storyId)
        {

            string JsonResult = await _rabbitClient.DataBaseCommonRequest(
                storyId,
                QueueConstantForRabbitComunication.StoryCredQueue,
                QueueConstantForRabbitComunication.StoryCred);


            StoryCredForStoryForListDTO Story = JsonSerializer.Deserialize<StoryCredForStoryForListDTO>(JsonResult);

            return Story;
        }

        public async Task<List<StoryForListDTO>> GetStoryListByStoryListID(List<string> storyIds)
        {
            List<Task<StoryForListDTO>> Tasks = storyIds.Select(i => GetStoryCredByStoryID(i)).ToList();

            var res = await Task.WhenAll(Tasks);
            List<StoryForListDTO> StoryCreds = res.ToList();
            return StoryCreds;
        }

        public async Task<List<StoryForListDTO>> GetStoryRecomendationListByUser(string userId)
        {
            //throw new NotImplementedException();// Give Some Recomendation By user Id

            // Fool Eplamentation 

            //Get top 20 story id`s Ala recomendation
            // retrive this story
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(
                userId,
                QueueConstantForRabbitComunication.StoryCredQueue,
                QueueConstantForRabbitComunication.GetStoryRecomendation);

            List<string> StoryIdsList = JsonSerializer.Deserialize<List<string>>(JsonResult);

            return await GetStoryListByStoryListID(StoryIdsList);



        }

        public async Task<List<StoryForListDTO>> GetStoryRecomendationListByUserAndTopic(string userID, int TopicId)
        {
            //throw new NotImplementedException();// Give Some Recomendation By user Id And Topic

            // Fool Eplamentation 

            //Get top 20 story id`s Ala recomendation
            // retrive this story
            string JsonResult = await _rabbitClient.DataBaseCommonRequest(
                JsonSerializer.Serialize(new { User = userID, Topic = TopicId }),
                QueueConstantForRabbitComunication.StoryCredQueue,
                QueueConstantForRabbitComunication.GetStoryRecomendation);

            List<string> StoryIdsList = JsonSerializer.Deserialize<List<string>>(JsonResult);

            return await GetStoryListByStoryListID(StoryIdsList);
        }

        public async Task MuteStoryByStoryId(string storyId)
        {

            string JsonResult = await _rabbitClient.DataBaseCommonRequest(
                storyId,
                QueueConstantForRabbitComunication.StoryCredQueue,
                QueueConstantForRabbitComunication.MuteStory);

            JsonElement result = JsonSerializer.Deserialize<JsonElement>(JsonResult);

            if (!result.GetProperty("Statis").Equals("Ok"))
            {
                await MuteStoryByStoryId(storyId);
            }

        }


    }
}
