using MediumMapperApi.Service.RabitMqGlobalData;
using Microsoft.AspNetCore.Mvc;

namespace MediumMapperApi.Service.RabitMqConsumerService
{
    public class RabitMqMapperConsumers
    {
        private readonly RabitMqGlobalDataClass _rabitWrapper;

        private string retriveQueue = "ContentStateQueueForMapping";

        public RabitMqMapperConsumers(RabitMqGlobalDataClass rabitWrapper)
        {
            _rabitWrapper = rabitWrapper;
        }

        //Retrive ContentState From DataBase
        public async Task StartContentStateFromDataBaseHeandleMessage()
        {
            await _rabitWrapper.CreateConsumerForChanelToQueue(await _rabitWrapper.GetRetriveChannelChannelToRabit(), retriveQueue);
        }
        //Retrive ContentStateFrom Api and Send To DB
        public async Task StartFromApiContentStateToDataBaseForSaveHeandleMessage()
        {
            await _rabitWrapper.CreateConsumerForChanelToQueue(await _rabitWrapper.GetRetriveChannelChannelToRabit(), retriveQueue);
        }

        //Get Topic From DataBase
        public async Task StartGetTopicFromDataBaseHeandleMessage()
        {
            await _rabitWrapper.CreateConsumerForChanelToQueue(await _rabitWrapper.GetRetriveChannelChannelToRabit(), retriveQueue);
        }

        // Get Topic List For User
        public async Task StartGetTopicListForUserFromDataBaseHeandleMessage()
        {
            await _rabitWrapper.CreateConsumerForChanelToQueue(await _rabitWrapper.GetRetriveChannelChannelToRabit(), retriveQueue);
        }

        // Get Story List For User
        public async Task StartGetStoryListForUserFromDataBaseHeandleMessage()
        {
            await _rabitWrapper.CreateConsumerForChanelToQueue(await _rabitWrapper.GetRetriveChannelChannelToRabit(), retriveQueue);
        }


    }
}
