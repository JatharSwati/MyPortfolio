namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePluralizingTableNameConvention : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BasicInfoes", newName: "BasicInfo");
            RenameTable(name: "dbo.PortfolioUsers", newName: "PortfolioUser");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PortfolioUser", newName: "PortfolioUsers");
            RenameTable(name: "dbo.BasicInfo", newName: "BasicInfoes");
        }
    }
}
