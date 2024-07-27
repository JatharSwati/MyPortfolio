namespace MyPortfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileColumnAndMakeBirthdateNullabaleInBasicInfoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasicInfo", "Profile", c => c.String());
            AlterColumn("dbo.BasicInfo", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BasicInfo", "Birthdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.BasicInfo", "Profile");
        }
    }
}
