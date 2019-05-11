namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrateforsubcategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectFields", "FieldOfStudy", c => c.String(nullable: false));
            DropColumn("dbo.SubjectFields", "SubjectName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectFields", "SubjectName", c => c.String(nullable: false));
            DropColumn("dbo.SubjectFields", "FieldOfStudy");
        }
    }
}
