namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamePortfolioUserCreatedOnColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PortfolioUsers", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.PortfolioUsers", "CreateOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PortfolioUsers", "CreateOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.PortfolioUsers", "CreatedOn");
        }
    }
}
