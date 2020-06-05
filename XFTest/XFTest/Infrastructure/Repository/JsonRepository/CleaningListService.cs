using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFTest.Infrastructure.Contracts;
using XFTest.Infrastructure.Helpers;
using XFTest.Models;

namespace XFTest.Infrastructure.Repository.JsonRepository
{
    public class CleaningListService : ICleanerListService
    {
        async public Task<ServiceResponse<IEnumerable<CleaningList>>> GetDailyTasks() {

            var result = await JsonDataHandler.RetrieveData<IEnumerable<CleaningList>>();
            return result;
        }
    }
}
