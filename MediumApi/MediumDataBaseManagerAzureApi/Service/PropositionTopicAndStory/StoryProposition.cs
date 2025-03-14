using Azure;
using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.DTO.Story;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MediumDataBaseManagerAzureApi.Service.PropositionTopicAndStory
{
    public class StoryProposition([FromServices] AppDbContext _db) : IStoryProposition
    {
        public async Task<List<StoryForListDTO>> GetListByUser(string UserId)
        {
            List < StoryForListDTO > storyList = new List < StoryForListDTO > ();
            return storyList;
        }
        public async Task<List<StoryForListDTO>> GetListByUserTopic(string UserId)
        {
            List<StoryForListDTO> storyList = new List<StoryForListDTO>();
            return storyList;
        }

        public async Task<UserForStoryForListDTO> SetUserForStory(string UserIdOfHistoryAuthror)
        {
            UserForStoryForListDTO userForHistory = new UserForStoryForListDTO 
            {
                UserId = UserIdOfHistoryAuthror,
                FullName = _db.Users.FirstOrDefault(u => u.Id == UserIdOfHistoryAuthror).UserName,
                Tag = _db.Users.FirstOrDefault(u => u.Id == UserIdOfHistoryAuthror).Tag,
                UsersImage = _db.UserProfiles.FirstOrDefault(u => u.UserWrapperId == UserIdOfHistoryAuthror).LogoUrl,

            };
            return userForHistory;
        }
    }
}
