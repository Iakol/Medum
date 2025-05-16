namespace MediumApi.Service.Story.Responces
{
    public interface IResponceService
    {
        public Task AddResponceToStoryByUser(string UserID, string stroryId,string TextOfResponce);
        public Task AddResponceToResponseInStoryByUser(string UserID, string stroryId, string TextOfResponce,int ResponseId);


        public Task GetResponceByStory(string storyID);
        public Task<int> GetResponceCountByStory(string storyID);

        public Task DeleteResponceByResponceid(int responceId);



    }
}
