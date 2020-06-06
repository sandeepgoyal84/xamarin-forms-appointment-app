using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFTest.Infrastructure.Contracts;
using XFTest.Infrastructure.Helpers;
using XFTest.Models;

namespace XFTest.Infrastructure.Repository.JsonRepository
{
    public class CleaningListService : ICleanerListService
    {
        async public Task<ServiceResponse<IEnumerable<CleaningList>>> GetDailyTasks(DateTime cleanListDate)
        {
            var jsonDataHandler = new JsonDataHandler();
            var result = await jsonDataHandler.RetrieveData<IEnumerable<CleaningList>>(cleanListDate);
            return result;
        }
    }
}