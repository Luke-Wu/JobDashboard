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
    public class TaskServiceTest
    {
        ITaskService _taskService;
        ITaskRespository _taskRespository;
        List<Task> _tasks;

        [SetUp]
        public void SetUp()
        {
            _tasks = SetupTasks();

            _taskRespository = SetupTaskRespository();

            _taskService = new TaskService(_taskRespository);


        }


        public List<Task> SetupTasks()
        {
            var tasks = JobDashBoardInitializer.GetTasks();
            return tasks;
        }

        public ITaskRespository SetupTaskRespository()
        {

            // Init repository
            var repo = new Mock<ITaskRespository>();

            // Setup mocking behavior


            repo.Setup(r => r.Add(It.IsAny<Task>()))
                .Callback(new Action<Task>(newTask =>
                {
                    int maxTaskNo = _tasks.Last().TaskNo;
                    int nextTaskNo = maxTaskNo + 1;
                    newTask.TaskNo = nextTaskNo;

                    _tasks.Add(newTask);
                }));

            repo.Setup(r => r.Update(It.IsAny<Task>()))
                .Callback(new Action<Task>(x =>
                {
                    var oldTask = _tasks.Find(t => t.TaskNo == x.TaskNo);
                    oldTask.CreateDate = DateTime.Now;
                    oldTask = x;
                }));

            repo.Setup(r => r.Delete(It.IsAny<Task>()))
               .Callback(new Action<Task>(x =>
               {
                   var _taskToRemove = _tasks.Find(t => t.TaskNo == x.TaskNo);

                   if (_taskToRemove != null)
                       _tasks.Remove(_taskToRemove);
               }));


            repo.Setup(r => r.Exist(It.IsAny<Expression<Func<Task, bool>>>()))
                .Callback(
                new Action<Task>(x =>
                {
                    _tasks.Find(t => t.Title == x.Title);

                }));



            return repo.Object;


        }



        [Test]
        public void TaskServiceShouldAddNewTask()
        {
            var _newTask = new Task()
            {
                 Title = "Test Task 12",
                 CreateDate = DateTime.Parse("2019-09-25"),
                 Description = "description of test task 12",
                 StaffNo = 1001
            };

            int maxTaskNo = _tasks.Max(t => t.TaskNo);
            _newTask.TaskNo = maxTaskNo + 1;
            _taskService.Add(_newTask);

            Assert.That(_newTask, Is.EqualTo(_tasks.Last()));

        }

        [Test]
        public void TaskSheetServiceShouldUpdateTask()
        {
            var _firstTask = _tasks.First();

            _firstTask.Title = "Test Task 12 Update";
            _firstTask.CreateDate = DateTime.Now;
            _taskService.Update(_firstTask);

            Assert.That(_firstTask.CreateDate, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(_firstTask.Title, Is.EqualTo("Test Task 12 Update"));
            Assert.That(_firstTask.TaskNo, Is.EqualTo(201)); //TaskNo hasn't changed
        }

        [Test]
        public void TaskServiceShouldDeleteTask()
        {
            int maxTaskNo = _tasks.Max(t => t.TaskNo); // the max one before remove
            var _lastTask = _tasks.Last();

            // Remove the last task
            _taskService.Delete(_lastTask);

            Assert.That(maxTaskNo, Is.GreaterThan(_tasks.Max(t => t.TaskNo)));
        }


        [Test]
        public void TaskServiceShouldExistTask()
        {
            var existTask = _tasks.Find(t => t.Title == "Task 1");

            var exist = existTask == null ? false : true;
  
            Assert.That(exist, Is.EqualTo(_taskService.Exist("Task 1")));
        }

    }
}
