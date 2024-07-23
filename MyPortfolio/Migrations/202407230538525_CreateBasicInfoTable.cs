namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBasicInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasicInfoes",
                c => new
                    {
                        BasicInfoId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Designation = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BasicInfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BasicInfoes");
        }
    }
}
