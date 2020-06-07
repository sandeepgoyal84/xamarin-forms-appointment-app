using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFTest.Services.Contracts;
using XFTest.Services.Helpers;
using XFTest.Models;

namespace XFTest.Services.Repository.JsonRepository
{
    public class CleaningListService : ICleanerListService
    {
        async public Task<ServiceResponse<IEnumerable<CleaningList>>> GetDailyTasks(DateTime cleanListDate)
        {
            //var jsonDataHandler = new JsonDataHandler();
            var result = await JsonDataHandler.RetrieveData<IEnumerable<CleaningList>>(cleanListDate);
            return result;
        }
    }
}