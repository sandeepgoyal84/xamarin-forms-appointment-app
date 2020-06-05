using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFTest.Infrastructure.Helpers;
using XFTest.Infrastructure.Repository.JsonRepository;

namespace XFTest.Infrastructure.Contracts
{
    public class ICleanerListService
    {

        Task<ServiceResponse<CleanerListService>> GetDailyTasks();
    }

}
