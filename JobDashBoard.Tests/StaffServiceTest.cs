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
namespace JobDashBoard.Tests
{
    [TestFixture]
    public class StaffServiceTest
    {
        IStaffService _staffService;
        IStaffRespository _staffRespository;
        List<Staff> _staffs;

        [SetUp]
        public void SetUp()
        {
            _staffs = SetupStaffs();

            _staffRespository = SetupStaffRespository();

            _staffService = new StaffService(_staffRespository);


        }


        public List<Staff> SetupStaffs()
        {
            var staffs = JobDashBoardInitializer.GetStaffs();
            return staffs;
        }

        public IStaffRespository SetupStaffRespository()
        {

            // Init repository
            var repo = new Mock<IStaffRespository>();

            // Setup mocking behavior


            repo.Setup(r => r.Add(It.IsAny<Staff>()))
                .Callback(new Action<Staff>(newStaff =>
                {
                    int maxStaffNo = _staffs.Last().StaffNo;
                    int nextStaffNo = maxStaffNo + 1;
                    newStaff.StaffNo = nextStaffNo;

                    _staffs.Add(newStaff);
                }));

            repo.Setup(r => r.Update(It.IsAny<Staff>()))
                .Callback(new Action<Staff>(x =>
                {
                    var oldStaff = _staffs.Find(s => s.StaffNo == x.StaffNo);
                    oldStaff.BirthDate = DateTime.Parse("1990-09-01");
                    oldStaff = x;
                }));

            repo.Setup(r => r.Delete(It.IsAny<Staff>()))
               .Callback(new Action<Staff>(x =>
               {
                   var _staffToRemove = _staffs.Find(s => s.StaffNo == x.StaffNo);

                   if (_staffToRemove != null)
                       _staffs.Remove(_staffToRemove);
               }));



            return repo.Object;


        }



        [Test]
        public void StaffServiceShouldAddNewStaff()
        {
            var _newStaff = new Staff()
            {
                FirstName = "Luke",
                LastName = "Wu",
                BirthDate = DateTime.Parse("1987-09-25")
               
            };

            int maxStaffNo = _staffs.Max(s => s.StaffNo);
            _newStaff.StaffNo = maxStaffNo + 1;
            _staffService.Add(_newStaff);

            Assert.That(_newStaff, Is.EqualTo(_staffs.Last()));

        }

        [Test]
        public void StaffSheetServiceShouldUpdateStaff()
        {
            var _firstStaff = _staffs.First();

            _firstStaff.FirstName = "Nick";
            _firstStaff.BirthDate = DateTime.Parse("1983-09-25");
            _staffService.Update(_firstStaff);

            Assert.That(_firstStaff.BirthDate, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(_firstStaff.FirstName, Is.EqualTo("Nick"));
            Assert.That(_firstStaff.StaffNo, Is.EqualTo(1001)); //StaffNo hasn't changed
        }

        [Test]
        public void StaffServiceShouldDeleteStaff()
        {
            int maxStaffNo = _staffs.Max(t => t.StaffNo); // the max one before remove
            var _lastStaff = _staffs.Last();

            // Remove the last staff
            _staffService.Delete(_lastStaff);

            Assert.That(maxStaffNo, Is.GreaterThan(_staffs.Max(s => s.StaffNo)));
        }



    }
}
