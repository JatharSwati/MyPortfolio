namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStrengthTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Strength",
                c => new
                    {
                        StrengthId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.StrengthId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Strength");
        }
    }
}
