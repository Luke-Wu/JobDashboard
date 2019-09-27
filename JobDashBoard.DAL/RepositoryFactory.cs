using JobDashBoard.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobDashBoard.DAL
{
    /// <summary>
    /// Repository factory
    /// </summary>
    public static class RepositoryFactory
    {
        public static IStaffRespository StaffRespository { get { return new StaffRespository(); } }

        public static ITaskRespository TaskRespository { get { return new TaskRespository(); } }

        public static ITimeSheetRespository TimeSheetRespository { get { return new TimeSheetRespository(); } }
        
    }
}
