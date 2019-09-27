using System;
using System.Linq;
using JobDashBoard.DAL;
using JobDashBoard.IBLL;
using JobDashBoard.IDAL;
using JobDashBoard.Models;

namespace JobDashBoard.BLL
{
    /// <summary>
    /// TimeSheet service
    /// </summary>
    public class TimeSheetService : BaseService<TimeSheet>, ITimeSheetService
    {
      
        public TimeSheetService() : base(RepositoryFactory.TimeSheetRespository)
        {
            
        }

        public TimeSheetService(ITimeSheetRespository timesheetRespository) : base(timesheetRespository)
        {
            CurrentRespository = timesheetRespository;
        }

    
        /// <summary>
        /// Get Timesheet list result based on begin date and end date
        /// </summary>
        /// <param name="beginDate">begin date</param>
        /// <param name="endDate">end date</param>
        /// <returns></returns>
        public IQueryable<TimeSheet> FindList(DateTime beginDate, DateTime endDate)
        {
            return CurrentRespository.FindList(t => t.HandleDate >= beginDate && t.HandleDate <= endDate);
        }



    }
}
