using JobDashBoard.DAL;
using JobDashBoard.IBLL;
using JobDashBoard.IDAL;
using JobDashBoard.Models;

namespace JobDashBoard.BLL
{
    /// <summary>
    /// Staff Service
    /// </summary>
    public class StaffService : BaseService<Staff>, IStaffService
    {
        public StaffService() : base(RepositoryFactory.StaffRespository)
        {

        }

        public StaffService(IStaffRespository staffRespository) : base(staffRespository)
        {
            CurrentRespository = staffRespository;
        }

    }
}
