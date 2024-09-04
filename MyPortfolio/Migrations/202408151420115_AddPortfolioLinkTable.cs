namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPortfolioLinkTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortfolioLink",
                c => new
                    {
                        PortfolioLinkId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        LinkType = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PortfolioLinkId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PortfolioLink");
        }
    }
}
