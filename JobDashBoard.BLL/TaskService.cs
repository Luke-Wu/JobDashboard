
using JobDashBoard.DAL;
using JobDashBoard.IBLL;
using JobDashBoard.IDAL;
using JobDashBoard.Models;

namespace JobDashBoard.BLL
{
    /// <summary>
    /// Task Service
    /// </summary>
    public class TaskService : BaseService<Task>, ITaskService
    {
        public TaskService() : base(RepositoryFactory.TaskRespository)
        {

        }


        public TaskService(ITaskRespository taskRespository) : base(taskRespository)
        {
            CurrentRespository = taskRespository;
        }

        /// <summary>
        /// Check task exist or not based on task title
        /// </summary>
        /// <param name="taskTitle">task title</param>
        /// <returns>exist or not</returns>
        public bool Exist(string taskTitle)
        {
            return CurrentRespository.Exist(t => t.Title == taskTitle);
        }

      
    }
}
