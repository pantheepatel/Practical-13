namespace Task2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DesignationT2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeT2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        MobileNumber = c.String(nullable: false, maxLength: 10),
                        Address = c.String(maxLength: 100),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DesignationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DesignationT2", t => t.DesignationId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeT2", "DesignationId", "dbo.DesignationT2");
            DropIndex("dbo.EmployeeT2", new[] { "DesignationId" });
            DropTable("dbo.EmployeeT2");
            DropTable("dbo.DesignationT2");
        }
    }
}
