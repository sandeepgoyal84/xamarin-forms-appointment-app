using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFTest.Services.Helpers;
using XFTest.Models;

namespace XFTest.Services.Contracts
{
    public interface ICleanerListService
    {
        Task<ServiceResponse<IEnumerable<CleaningList>>> GetDailyTasks(DateTime cleanListDate);
    }
}