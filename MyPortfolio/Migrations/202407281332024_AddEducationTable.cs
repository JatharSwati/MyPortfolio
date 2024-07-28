namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEducationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        EducationId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        EducationName = c.String(nullable: false, maxLength: 50),
                        CollegeName = c.String(nullable: false, maxLength: 100),
                        PercentageOrCGPA = c.Double(),
                        StartYear = c.Int(nullable: false),
                        PassingYear = c.Int(),
                    })
                .PrimaryKey(t => t.EducationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Education");
        }
    }
}
