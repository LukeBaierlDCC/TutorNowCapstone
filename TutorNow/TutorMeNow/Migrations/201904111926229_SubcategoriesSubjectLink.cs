namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boomchakalaka : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subcategories", "FieldOfStudy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subcategories", "FieldOfStudy");
        }
    }
}
