namespace Payroll_Sys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Keyinregisterviewmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisterViewModels");
        }
    }
}
