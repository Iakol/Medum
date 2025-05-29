using Azure;
using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.DTO.Story;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                FullName = (await _db.Users.FirstOrDefaultAsync(u => u.UserWrapperId == UserIdOfHistoryAuthror)).UserName,
                Tag = (await _db.UserWrappers.FirstOrDefaultAsync(u => u.UserId == UserIdOfHistoryAuthror)).Tag,
                UsersImage = (await _db.UserProfiles.FirstOrDefaultAsync(u => u.UserWrapperId == UserIdOfHistoryAuthror)).LogoUrl,

            };
            return userForHistory;
        }
    }
}
