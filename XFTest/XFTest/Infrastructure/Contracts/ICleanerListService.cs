using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFTest.Infrastructure.Helpers;
using XFTest.Infrastructure.Repository.JsonRepository;
using XFTest.Models;

namespace XFTest.Infrastructure.Contracts
{
    public interface ICleanerListService
    {

        Task<ServiceResponse<IEnumerable<CleaningList>>> GetDailyTasks(DateTime cleanListDate);
    }

}
