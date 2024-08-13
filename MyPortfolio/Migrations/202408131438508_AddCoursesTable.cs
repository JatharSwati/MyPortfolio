namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoursesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CoursesId = c.Guid(nullable: false),
                        PortfolioUserId = c.Guid(nullable: false),
                        CourseName = c.String(nullable: false, maxLength: 100),
                        CoursePlatfrom = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Description = c.String(maxLength: 1000),
                        Skills = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.CoursesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
        }
    }
}
