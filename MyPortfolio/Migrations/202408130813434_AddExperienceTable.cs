namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExperienceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        ExperienceId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        ExperienceType = c.String(nullable: false, maxLength: 50),
                        Designation = c.String(nullable: false, maxLength: 50),
                        OrganizationName = c.String(nullable: false, maxLength: 100),
                        JoiningDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Skills = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ExperienceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Experience");
        }
    }
}
