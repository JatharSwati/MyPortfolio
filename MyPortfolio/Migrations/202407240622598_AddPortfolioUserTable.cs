namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPortfolioUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortfolioUsers",
                c => new
                    {
                        PortfolioUserId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CreateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PortfolioUserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PortfolioUsers");
        }
    }
}
