using System.Runtime.Remoting.Messaging;

namespace JobDashBoard.DAL
{
    /// <summary>
    /// Simple factory for get current DbContext
    /// </summary>
    public class ContextFactory
    {
        /// <summary>
        /// Get current DbContext 
        /// </summary>
        /// <returns>current JobDashBoardDbContext</returns>
        public static JobDashBoardDbContext GetCurrentContext()
        {
            JobDashBoardDbContext _jobContext = CallContext.GetData("JobDashBoardContext") as JobDashBoardDbContext;
            if (_jobContext == null)
            {
                _jobContext = new JobDashBoardDbContext();
                CallContext.SetData("JobDashBoardContext", _jobContext);
            }
            return _jobContext;
        }

    }
}
