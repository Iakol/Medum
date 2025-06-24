using MediumDataBaseManagerAzureApi.Data;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.ManyToMany;
using MediumDataBaseManagerAzureApi.Models.User;
using MediumDataBaseManagerAzureApi.Service.ReadingList.ParamsDTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;

namespace MediumDataBaseManagerAzureApi.Service.ReadingList
{
    public class ReadingListService(AppDbContext _db) : IReadingListService
    {
        public async Task<string> AddStoryToReadingListByUser(UserStoryReadingListParamDTO Params) //string userId, string storyId, string readingListId // return bool
        {
            UserReadingList readingListToStoryAdd = await _db.UsersReadingLists.FirstOrDefaultAsync(r => r.Id.Equals(Params.readingListId));
            if (readingListToStoryAdd != null)
            {
                if (readingListToStoryAdd.UserId.Equals(Params.userId))
                {
                    if (await _db.ContentStateStoryWrappers.AnyAsync(s => s.Id.Equals(Params.userId)))
                    {
                        if (!await _db.ReadingList_UserWrapperToStoryIds.AnyAsync(
                            s => s.SaveStoryInList.Equals(Params.storyId) &&
                                s.UserReadingListId.Equals(readingListToStoryAdd.Id)))
                        {
                            ReadingList_UserWrapperToStoryId newSavedStory = new ReadingList_UserWrapperToStoryId
                            {
                                UserReadingListId = readingListToStoryAdd.Id,
                                SaveStoryInListId = Params.storyId,

                            };
                            await _db.ReadingList_UserWrapperToStoryIds.AddAsync(newSavedStory);
                            await _db.SaveChangesAsync();
                            return "OK" ;
                        }
                    }
                }
                else
                {
                    return  "User not have Permition";

                }
            }
            return "Wrong data";
        }

        public async Task<string> DeleteReadingList(UserStoryReadingListParamDTO Params)// string readingListId, string UserId// return bool
        {

            UserReadingList readingListToStoryAdd = await _db.UsersReadingLists.FirstOrDefaultAsync(r => r.Id.Equals(Params.readingListId));
            if (readingListToStoryAdd != null)
            {
                if (readingListToStoryAdd.UserId.Equals(Params.userId))
                {
                    _db.ReadingList_UserWrapperToStoryIds.RemoveRange(_db.ReadingList_UserWrapperToStoryIds.Where(s => s.UserReadingListId.Equals(readingListToStoryAdd.Id)));
                    _db.UsersReadingLists.Remove(readingListToStoryAdd);
                    await _db.SaveChangesAsync();
                    return  "OK";
                }
                else
                {
                    return "User not have Permition" ;

                }
            }
            return "Wrong Data" ;
        }

        public async Task<string> DeleteStoryFromReadingList(UserStoryReadingListParamDTO Params) //string storyId, string readingListId, string userId // return bool
        {

            UserReadingList readingListToStoryAdd = await _db.UsersReadingLists.FirstOrDefaultAsync(r => r.Id.Equals(Params.readingListId));
            if (readingListToStoryAdd != null)
            {
                if (readingListToStoryAdd.UserId.Equals(Params.userId))
                {
                    if (await _db.ContentStateStoryWrappers.AnyAsync(s => s.Id.Equals(Params.userId)))
                    {
                        if (await _db.ReadingList_UserWrapperToStoryIds.AnyAsync(
                            s => s.SaveStoryInList.Equals(Params.storyId) &&
                                s.UserReadingListId.Equals(readingListToStoryAdd.Id)))
                        {
                            ReadingList_UserWrapperToStoryId deleteSavedStory = await _db
                                .ReadingList_UserWrapperToStoryIds
                                .FirstOrDefaultAsync(r => r.SaveStoryInListId.Equals(Params.storyId));

                            _db.ReadingList_UserWrapperToStoryIds.Remove(deleteSavedStory);
                            await _db.SaveChangesAsync();
                            return "OK" ;
                        }
                    }
                }
                else
                {
                    return  "User not have Permition";

                }
            }
            return  "Wrong data" ;
        }

        public async Task<string> CreateReadingListByUser(CreateReadingListDTO Params) // CreateReadingListDTO readingListToCreate // return 
        {


            UserReadingList RadingListToCreate = new UserReadingList
            {
                Name = Params.Name,
                Description = Params.Description,
                UserId = Params.userId,
                Immortal = false,
                Private = Params.isPrivate,
                isOpenResponce = Params.isPrivate
            };

            await _db.UsersReadingLists.AddAsync(RadingListToCreate);
            await _db.SaveChangesAsync();
            return "OK";


        }

        public async Task<string> UpdateReadingListByUser(string Params)//string userId, string readingListId, CreateReadingListDTO readingListToChangeCred // return bool
        {
            var json = JsonSerializer.Deserialize<JsonElement>(Params);
            string userId = json.GetProperty("User").ToString();
            string ReaddngListId = json.GetProperty("readingList").ToString();
            JsonElement ReadingList = json.GetProperty("readingListToChangeCred");

            UserReadingList readingList = await _db.UsersReadingLists.FirstOrDefaultAsync(r => r.Id.Equals(ReaddngListId));

            if (readingList != null)
            {
                if (readingList.UserId.Equals(userId))
                {
                    readingList.Description = ReadingList.GetProperty("Description").ToString();
                    readingList.Name = ReadingList.GetProperty("Name").ToString();
                    readingList.Private = ReadingList.GetProperty("isPrivate").GetBoolean();
                    _db.UsersReadingLists.Update(readingList);
                    await _db.SaveChangesAsync();
                    return JsonSerializer.Serialize(new { Status = "OK" });


                }
                else
                {
                    return "User not have Permition" ;
                }

            }
            return  "Bad data" ;
        }

        public async Task<string> GetUserReadingLists(string Params) // string userId // return List<string> readinglistids
        {
            return JsonSerializer.Serialize(await _db.UsersReadingLists.Where(l => l.UserId.Equals(Params)).ToListAsync());
        }

        public async Task<string> GetUserSavedReadingLists(string Params) // string userId // return List<string> ReadingListIds
        {
            return JsonSerializer.Serialize(await _db.SavedUsersReadingLists.Where(l => l.UserId.Equals(Params)).ToListAsync());
        }
        public async Task<string> GetAuthorRedingList(string Params)//string authorId // return List<string> ReadingListIds
        {
            return JsonSerializer.Serialize(await _db.UsersReadingLists.Where(l => l.UserId.Equals(Params)).ToListAsync());

        }

        public async Task<string> UpdateNoteToStoryInReadingList(string Params)//string storyid, string readingListId, string TextOfNote, string UserId// return bool 
        {
            JsonElement json = JsonSerializer.Deserialize<JsonElement>(Params);
            if (await _db.UsersReadingLists.AnyAsync(r => r.Id.Equals(json.GetProperty("readingList").GetString())))
            {
                if (await _db.UsersReadingLists.AnyAsync(r => r.UserId.Equals(json.GetProperty("User").GetString())))
                {
                    if (await _db.ReadingList_UserWrapperToStoryIds.AnyAsync(r => r.SaveStoryInList.Equals(json.GetProperty("story").GetString())))
                    {
                        ReadingList_UserWrapperToStoryId savestory = await _db.ReadingList_UserWrapperToStoryIds.FirstOrDefaultAsync(r => r.SaveStoryInList.Equals(json.GetProperty("story").GetString()));
                        savestory.UserNoteForSaveStory = json.GetProperty("TextOfNote").GetString();
                        _db.ReadingList_UserWrapperToStoryIds.Update(savestory);
                        await _db.SaveChangesAsync();
                    }
                }
                else
                {
                    return "User not have Permition" ;
                }
            }
            return "Bad data" ;
        }

        public async Task<string> GetReadingListById(string Params)  // string ReadingListId // returnt ReadingListDTO
        {
            UserReadingList readList = await _db.UsersReadingLists.FirstOrDefaultAsync(r => r.Id.Equals(Params));
            if (readList != null)
            {
                var savedStory = await _db.ReadingList_UserWrapperToStoryIds.Where(s => s.UserReadingListId.Equals(Params)).Select(s => new {
                    s.SaveStoryInListId, 
                    s.UserNoteForSaveStory
                
                }).ToListAsync();
                string result = JsonSerializer.Serialize(new
                {
                    Id = readList.Id,
                    userId = readList.UserId,
                    storyCount = savedStory.Count,
                    Name = readList.Name,
                    Description = readList.Description,
                    IsPrivate = readList.Description,
                    ReadingListItems = savedStory

                });

                return result;
            }
            return null;
        }




    }
}
