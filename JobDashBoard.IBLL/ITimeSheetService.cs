using JobDashBoard.Models;
using System;
using System.Linq;

namespace JobDashBoard.IBLL
{
    /// <summary>
    /// Timesheet service interface
    /// </summary>
    public interface ITimeSheetService : IBaseService<TimeSheet>
    {
        IQueryable<TimeSheet> FindList(DateTime beginDate, DateTime endDate);
    }
}
