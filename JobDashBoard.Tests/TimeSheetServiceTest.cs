using JobDashBoard.BLL;
using JobDashBoard.DAL;
using JobDashBoard.IBLL;
using JobDashBoard.IDAL;
using JobDashBoard.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JobDashBoard.Tests
{
    [TestFixture]
    public class TimeSheetServiceTest
    {
        ITimeSheetService _timesheetService;
        ITimeSheetRespository _timesheetRespository;
        List<TimeSheet> _timesheets;

        private DateTime beginDate;
        private DateTime endDate;


        [SetUp]
        public void SetUp()
        {
            _timesheets = SetupTimeSheets();



            _timesheetRespository = SetupTimeSheetRespository();

            _timesheetService = new TimeSheetService(_timesheetRespository);
           

        }


        public List<TimeSheet> SetupTimeSheets()
        {
            var timesheets = JobDashBoardInitializer.GetTimeSheets();
            return timesheets;
        }

        public ITimeSheetRespository SetupTimeSheetRespository()
        {

            // Init repository
            var repo = new Mock<ITimeSheetRespository>();

            // Setup mocking behavior


            repo.Setup(r => r.Add(It.IsAny<TimeSheet>()))
                .Callback(new Action<TimeSheet>(newTimeSheet =>
                {
                    int maxTimeSheetID = _timesheets.Last().TimesheetID;
                    int nextTimeSheetID = maxTimeSheetID + 1;
                    newTimeSheet.TimesheetID = nextTimeSheetID;

                    _timesheets.Add(newTimeSheet);
                }));

            repo.Setup(r => r.Update(It.IsAny<TimeSheet>()))
                .Callback(new Action<TimeSheet>(x =>
                {
                    var oldTimeSheet = _timesheets.Find(t => t.TimesheetID == x.TimesheetID);
                    oldTimeSheet.HandleDate = DateTime.Now;
                    oldTimeSheet = x;
                }));

            repo.Setup(r => r.Delete(It.IsAny<TimeSheet>()))
               .Callback(new Action<TimeSheet>(x =>
               {
                   var _timesheetToRemove = _timesheets.Find(t => t.TimesheetID == x.TimesheetID);

                   if (_timesheetToRemove != null)
                       _timesheets.Remove(_timesheetToRemove);
               }));


            repo.Setup(r => r.FindList(It.IsAny<Expression<Func<TimeSheet, bool>>>()))
            .Returns(_timesheets.FindAll(t => t.HandleDate >= beginDate && t.HandleDate <= endDate).AsQueryable());

            return repo.Object;

        }
   



        [Test]
        public void TimeSheetServiceShouldAddNewTimeSheet()
        {
            var _newTimeSheet = new TimeSheet()
            {
              
                TaskNo = 210,
                HandleDate = DateTime.Parse("2019-09-25"),
                WorkHours = 1.5

            };

            int maxTimeSheetID = _timesheets.Max(t => t.TimesheetID);
            _newTimeSheet.TimesheetID = maxTimeSheetID + 1;
            _timesheetService.Add(_newTimeSheet);

            Assert.That(_newTimeSheet, Is.EqualTo(_timesheets.Last()));
     
        }

        [Test]
        public void TimeSheetServiceShouldUpdateTimeSheet()
        {
            var _firstTimesheet = _timesheets.First();

            _firstTimesheet.WorkHours = 4.5;
            _firstTimesheet.HandleDate = DateTime.Now;
            _timesheetService.Update(_firstTimesheet);

            Assert.That(_firstTimesheet.HandleDate, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(_firstTimesheet.WorkHours, Is.EqualTo(4.5));
            Assert.That(_firstTimesheet.TimesheetID, Is.EqualTo(10001)); //TimeSheetID hasn't changed
        }

        [Test]
        public void TimeSheetServiceShouldDeleteTimeSheet()
        {
            int maxTimeSheetID = _timesheets.Max(t => t.TimesheetID); // the max one before remove
            var _lastTimeSheet = _timesheets.Last();

            // Remove the last TimeSheet
            _timesheetService.Delete(_lastTimeSheet);

            Assert.That(maxTimeSheetID, Is.GreaterThan(_timesheets.Max(t => t.TimesheetID))); 
        }

        [Test]
        public void TimeSheetServiceShouldFindTimeSheetlist()
        {
            beginDate = DateTime.Parse("2019-09-19");
            endDate = DateTime.Parse("2019-09-20");
            var timesheetList = _timesheets.FindAll(t => t.HandleDate <= endDate && t.HandleDate >= beginDate);
            var testTimesheetList = _timesheetService.FindList(beginDate, endDate);

            
            Assert.AreEqual(timesheetList.Count, testTimesheetList.Count());

         
        }

    }
}
