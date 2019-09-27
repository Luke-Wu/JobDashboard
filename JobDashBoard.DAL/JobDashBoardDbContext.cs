using JobDashBoard.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JobDashBoard.DAL
{
    /// <summary>
    /// DB Context
    /// </summary>
    public class JobDashBoardDbContext : DbContext
    {
        public JobDashBoardDbContext() : base("JobDashBoardDbContext")
        {
            Database.SetInitializer(new JobDashBoardInitializer());
        }


        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TimeSheet> TimeSheets { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            base.OnModelCreating(modelBuilder);
        }


    }
}
