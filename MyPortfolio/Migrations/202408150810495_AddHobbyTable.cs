namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHobbyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hobby",
                c => new
                    {
                        HobbyId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.HobbyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hobby");
        }
    }
}
