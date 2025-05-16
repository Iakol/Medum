using MediumApi.DTO.StoryDTO.StoryCredDTO;
using MediumApi.RabbitMQCover;
using MediumApi.Service.ConccurentDictonryForReplyTask;
using RabbitMQ.Client;
using System.Text.Json;

namespace MediumApi.Service.Story.StoryCred
{
    public class StoryCredService(RabitMqGlobalDataClass _rabbitClient, IConccurentDictonryForReplyTask _ReplyTaskDictonary) : IStoryCredService
    {

        public async Task<StoryForListDTO> GetStoryCredByStoryID(string storyId)
        {
            StoryForListDTO Story = new StoryForListDTO();

            Story.Story = await GetStoryCredForStoryList(storyId);

            //
            return Story;
        }

        public async Task<StoryCredForStoryForListDTO> GetStoryCredForStoryList(string storyId)
        {
            BasicProperties properties = new BasicProperties();
            properties.ReplyTo = QueueConstantForRabbitComunication.StoryCredQueue;
            properties.CorrelationId = Guid.NewGuid().ToString();
            TaskCompletionSource<string> task = new TaskCompletionSource<string>();
            await _ReplyTaskDictonary.Register(task, properties.CorrelationId);

            await _rabbitClient.SendMessageWrapper(storyId,
                QueueConstantForRabbitComunication.StoryCred,
                properties,
                QueueConstantForRabbitComunication.RequestDBExechange);

            string JsonResult = await task.Task;

            StoryCredForStoryForListDTO Story = JsonSerializer.Deserialize<StoryCredForStoryForListDTO>(JsonResult);

            return Story;
        }

        public async Task<List<StoryForListDTO>> GetStoryListByStoryListID(List<string> storyIds)
        {
            List<Task<StoryForListDTO>> Tasks = storyIds.Select(i => GetStoryCredByStoryID(i)).ToList();

            var res =  await Task.WhenAll(Tasks);
            List<StoryForListDTO> StoryCreds = res.ToList();
            return StoryCreds;
        }

        public async Task<List<StoryForListDTO>> GetStoryRecomendationListByUser(string userId)
        {
            //throw new NotImplementedException();// Give Some Recomendation By user Id

            // Fool Eplamentation 

            //Get top 20 story id`s Ala recomendation
            // retrive this story
            BasicProperties properties = new BasicProperties();
            properties.ReplyTo = QueueConstantForRabbitComunication.StoryCredQueue;
            properties.CorrelationId = Guid.NewGuid().ToString();
            TaskCompletionSource<string> task = new TaskCompletionSource<string>();
            await _ReplyTaskDictonary.Register(task, properties.CorrelationId);

            await _rabbitClient.SendMessageWrapper(userId,
                QueueConstantForRabbitComunication.GetStoryRecomendation,
                properties,
                QueueConstantForRabbitComunication.RequestDBExechange);

            string JsonResult = await task.Task;

            List<string> StoryIdsList = JsonSerializer.Deserialize<List<string>>(JsonResult);

            return await GetStoryListByStoryListID(StoryIdsList);



        }

        public Task<StoryForListDTO> GetStoryRecomendationListByUserAndTopic(string userID, int TopicId)
        {
            throw new NotImplementedException(); // Give List By Topic
        }

        public async Task<UserForStoryForListDTO> GetUserCredForStoryListByStoryId(string storyId)
        {
            BasicProperties properties = new BasicProperties();
            properties.ReplyTo = QueueConstantForRabbitComunication.StoryCredQueue;
            properties.CorrelationId = Guid.NewGuid().ToString();
            TaskCompletionSource<string> task = new TaskCompletionSource<string>();
            await _ReplyTaskDictonary.Register(task, properties.CorrelationId);

            await _rabbitClient.SendMessageWrapper(storyId,
                QueueConstantForRabbitComunication.UserCred,
                properties,
                QueueConstantForRabbitComunication.RequestDBExechange);

            string JsonResult = await task.Task;

            UserForStoryForListDTO User = JsonSerializer.Deserialize<UserForStoryForListDTO>(JsonResult);

            return User;
        }
    }
}
