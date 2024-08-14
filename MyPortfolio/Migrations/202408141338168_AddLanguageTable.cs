namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLanguageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        LanguageId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.LanguageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Language");
        }
    }
}
