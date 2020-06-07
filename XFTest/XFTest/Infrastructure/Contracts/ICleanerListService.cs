using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFTest.Infrastructure.Helpers;
using XFTest.Models;

namespace XFTest.Infrastructure.Contracts
{
    public interface ICleanerListService
    {
        Task<ServiceResponse<IEnumerable<CleaningList>>> GetDailyTasks(DateTime cleanListDate);
    }
}