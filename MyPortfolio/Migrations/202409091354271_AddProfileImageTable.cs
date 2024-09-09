namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileImage",
                c => new
                    {
                        ProfileImageId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        ImageName = c.String(),
                        ContentType = c.String(),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ProfileImageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfileImage");
        }
    }
}
