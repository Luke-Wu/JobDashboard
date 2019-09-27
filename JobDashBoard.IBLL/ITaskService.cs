using JobDashBoard.Models;

namespace JobDashBoard.IBLL
{
    /// <summary>
    /// Task service interface
    /// </summary>
    public interface ITaskService : IBaseService<Task>
    {
   

        bool Exist(string taskTitle);
    }
}
