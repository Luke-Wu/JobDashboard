using JobDashBoard.API.Controllers;
using JobDashBoard.API.Models;
using JobDashBoard.BLL;
using JobDashBoard.DAL;
using JobDashBoard.IBLL;
using JobDashBoard.IDAL;
using JobDashBoard.Models;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace JobDashBoard.Tests
{
    [TestFixture]
    public class SearchApiControllerTest
    {
        private ITimeSheetService _timesheetService;
        private ITimeSheetRespository _timesheetRespository;
        private List<TimeSheet> _timesheets;
        private SearchApiController _searchApiController;
        private DateTime beginDate;
        private DateTime endDate;

        [SetUp]
        public void SetUp()
        {
            beginDate = DateTime.Parse("2019-09-16");

            endDate = DateTime.Parse("2019-09-24");

            _timesheets = SetupTimeSheets();

            _timesheetRespository = SetupTimeSheetRespository();

            _timesheetService = new TimeSheetService(_timesheetRespository);

            _searchApiController = new SearchApiController(_timesheetService);


        }


        private List<TimeSheet> SetupTimeSheets()
        {
            var timesheets = JobDashBoardInitializer.GetTimeSheets();
            return timesheets;
        }

        private ITimeSheetRespository SetupTimeSheetRespository()
        {

            // Init repository
            var repo = new Mock<ITimeSheetRespository>();

            repo.Setup(r => r.FindList(It.IsAny<Expression<Func<TimeSheet, bool>>>()))
          .Returns(_timesheets.FindAll(t => t.HandleDate >= beginDate && t.HandleDate <= endDate).AsQueryable());

            return repo.Object;



        }



        [Test]
        public void ControlerResponseShouldNotNull()
        {

            var apiResponse = _searchApiController.GetWorkHours(beginDate.ToString(), endDate.ToString());

            Assert.IsNotNull(apiResponse);
        }



        [Test]
        public void ControlerResponseShouldGetSuccessStatusCode()
        {

            var apiResponse = _searchApiController.GetWorkHours(beginDate.ToString(), endDate.ToString());

            Assert.IsTrue(apiResponse.IsSuccessStatusCode);
        }


        [Test]
        public void ControlerShouldGetWorkHours()
        {
            

           var result = _searchApiController.GetWorkHours(beginDate.ToString(), endDate.ToString());

            var timesheetList = _timesheets.FindAll(t => t.HandleDate >= beginDate && t.HandleDate <= endDate);

            var JobRecordList = JsonConvert.DeserializeObject<List<JobRecordModel>>(result.Content.ToString());

            Assert.AreEqual(timesheetList.Sum(t => t.WorkHours), JobRecordList.Sum(j => j.WorkHours));

            Assert.IsTrue(JobRecordList.Exists(j => j.StaffNo == timesheetList.FirstOrDefault().Task.StaffNo));


            

        }
        


    }
}
