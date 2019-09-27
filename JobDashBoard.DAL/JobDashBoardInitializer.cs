using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using JobDashBoard.Models;

namespace JobDashBoard.DAL
{
    /// <summary>
    /// Initialize database using sample datas
    /// </summary>
    public class JobDashBoardInitializer : DropCreateDatabaseIfModelChanges<JobDashBoardDbContext> 
    {
        protected override void Seed(JobDashBoardDbContext context)
        {
           
            GetStaffs().ForEach(s => context.Staffs.Add(s));
            context.SaveChanges();

         
            GetTasks().ForEach(t => context.Tasks.Add(t));
            context.SaveChanges();

         
            GetTimeSheets().ForEach(t => context.TimeSheets.Add(t));
            context.SaveChanges();

        }


        /// <summary>
        /// Get staff list data
        /// </summary>
        /// <returns></returns>
        public static List<Staff> GetStaffs()
        {
            var staffs = new List<Staff>
            {
               new Staff{StaffNo=1001, FirstName="Kim",LastName="Andrew", BirthDate=DateTime.Parse("1970-01-02")},
               new Staff{StaffNo=1002, FirstName="Hua",LastName="Li", BirthDate=DateTime.Parse("1980-10-02")},
               new Staff{StaffNo=1003, FirstName="Pant",LastName="Vini", BirthDate=DateTime.Parse("1976-09-10")},
               new Staff{StaffNo=1004, FirstName="Ben",LastName="Paose", BirthDate=DateTime.Parse("1987-11-26")},
               new Staff{StaffNo=1005, FirstName="Nino",LastName="Norman", BirthDate=DateTime.Parse("1990-12-05")}
            };

            return staffs;

        }

        /// <summary>
        /// Get task list data
        /// </summary>
        /// <returns></returns>
        public static List<Task> GetTasks()
        {
            var tasks = new List<Task>
            {
                new Task{TaskNo=201,StaffNo=1001,Title="Task 1",Description="description of task 1",CreateDate=DateTime.Parse("2019-09-15")},
                new Task{TaskNo=202,StaffNo=1003,Title="Task 2",Description="description of task 2",CreateDate=DateTime.Parse("2019-09-16")},
                new Task{TaskNo=203,StaffNo=1002,Title="Task 3",Description="description of task 3",CreateDate=DateTime.Parse("2019-09-18")},
                new Task{TaskNo=204,StaffNo=1005,Title="Task 4",Description="description of task 4",CreateDate=DateTime.Parse("2019-09-16")},
                new Task{TaskNo=205,StaffNo=1004,Title="Task 5",Description="description of task 5",CreateDate=DateTime.Parse("2019-09-23")},
                new Task{TaskNo=206,StaffNo=1005,Title="Task 6",Description="description of task 6",CreateDate=DateTime.Parse("2019-09-22")},
                new Task{TaskNo=207,StaffNo=1001,Title="Task 7",Description="description of task 7",CreateDate=DateTime.Parse("2019-09-15")},
                new Task{TaskNo=208,StaffNo=1003,Title="Task 8",Description="description of task 8",CreateDate=DateTime.Parse("2019-09-20")},
                new Task{TaskNo=209,StaffNo=1002,Title="Task 9",Description="description of task 9",CreateDate=DateTime.Parse("2019-09-24")},
                new Task{TaskNo=210,StaffNo=1001,Title="Task 10",Description="description of task 10",CreateDate=DateTime.Parse("2019-09-21")},
                new Task{TaskNo=211,StaffNo=1002,Title="Task 11",Description="description of task 11",CreateDate=DateTime.Parse("2019-09-17")}
            };
            return tasks;
        }

        /// <summary>
        /// Get timesheet list data
        /// </summary>
        /// <returns></returns>
        public static List<TimeSheet> GetTimeSheets()
        {
            var timesheets = new List<TimeSheet>
            {
                new TimeSheet{TimesheetID=10001,TaskNo=201,HandleDate=DateTime.Parse("2019-09-15"),WorkHours=1.5},
                new TimeSheet{TimesheetID=10002,TaskNo=202,HandleDate=DateTime.Parse("2019-09-17"),WorkHours=2.5},
                new TimeSheet{TimesheetID=10003,TaskNo=203,HandleDate=DateTime.Parse("2019-09-18"),WorkHours=4},
                new TimeSheet{TimesheetID=10004,TaskNo=204,HandleDate=DateTime.Parse("2019-09-17"),WorkHours=3.25},
                new TimeSheet{TimesheetID=10005,TaskNo=205,HandleDate=DateTime.Parse("2019-09-23"),WorkHours=1},
                new TimeSheet{TimesheetID=10006,TaskNo=206,HandleDate=DateTime.Parse("2019-09-23"),WorkHours=7.5},
                new TimeSheet{TimesheetID=10007,TaskNo=207,HandleDate=DateTime.Parse("2019-09-17"),WorkHours=4.5},
                new TimeSheet{TimesheetID=10008,TaskNo=208,HandleDate=DateTime.Parse("2019-09-20"),WorkHours=2},
                new TimeSheet{TimesheetID=10009,TaskNo=209,HandleDate=DateTime.Parse("2019-09-25"),WorkHours=5.5},
                new TimeSheet{TimesheetID=10010,TaskNo=210,HandleDate=DateTime.Parse("2019-09-21"),WorkHours=1.5},
                new TimeSheet{TimesheetID=10011,TaskNo=211,HandleDate=DateTime.Parse("2019-09-18"),WorkHours=3},
                new TimeSheet{TimesheetID=10012,TaskNo=211,HandleDate=DateTime.Parse("2019-09-19"),WorkHours=4.5},
                new TimeSheet{TimesheetID=10013,TaskNo=209,HandleDate=DateTime.Parse("2019-09-26"),WorkHours=2.5},
                new TimeSheet{TimesheetID=10014,TaskNo=207,HandleDate=DateTime.Parse("2019-09-22"),WorkHours=1},
                new TimeSheet{TimesheetID=10015,TaskNo=211,HandleDate=DateTime.Parse("2019-09-24"),WorkHours=4},
                new TimeSheet{TimesheetID=10016,TaskNo=202,HandleDate=DateTime.Parse("2019-09-19"),WorkHours=3.5},
                new TimeSheet{TimesheetID=10017,TaskNo=203,HandleDate=DateTime.Parse("2019-09-22"),WorkHours=1},
                new TimeSheet{TimesheetID=10018,TaskNo=204,HandleDate=DateTime.Parse("2019-09-19"),WorkHours=0.5},
                new TimeSheet{TimesheetID=10019,TaskNo=205,HandleDate=DateTime.Parse("2019-09-24"),WorkHours=6.5},
                new TimeSheet{TimesheetID=10020,TaskNo=206,HandleDate=DateTime.Parse("2019-09-25"),WorkHours=3},
                new TimeSheet{TimesheetID=10021,TaskNo=207,HandleDate=DateTime.Parse("2019-09-24"),WorkHours=1.5},
                new TimeSheet{TimesheetID=10022,TaskNo=201,HandleDate=DateTime.Parse("2019-09-22"),WorkHours=6}
            };
            return timesheets;

        }

    }
}
