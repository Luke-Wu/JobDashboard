namespace JobDashBoard.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        StaffNo = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.StaffNo);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskNo = c.Int(nullable: false),
                        StaffNo = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TaskNo)
                .ForeignKey("dbo.Staff", t => t.StaffNo, cascadeDelete: true)
                .Index(t => t.StaffNo);
            
            CreateTable(
                "dbo.TimeSheet",
                c => new
                    {
                        TimesheetID = c.Int(nullable: false),
                        TaskNo = c.Int(nullable: false),
                        HandleDate = c.DateTime(nullable: false),
                        WorkHours = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TimesheetID)
                .ForeignKey("dbo.Task", t => t.TaskNo, cascadeDelete: true)
                .Index(t => t.TaskNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSheet", "TaskNo", "dbo.Task");
            DropForeignKey("dbo.Task", "StaffNo", "dbo.Staff");
            DropIndex("dbo.TimeSheet", new[] { "TaskNo" });
            DropIndex("dbo.Task", new[] { "StaffNo" });
            DropTable("dbo.TimeSheet");
            DropTable("dbo.Task");
            DropTable("dbo.Staff");
        }
    }
}
