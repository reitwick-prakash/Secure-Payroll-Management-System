namespace Payroll_Sys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingsalaryfieldinregisterpage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Salary", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Salary");
        }
    }
}
