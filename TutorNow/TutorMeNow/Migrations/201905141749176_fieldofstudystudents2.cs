namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldofstudystudents2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FieldOfStudy_SubjectId", c => c.Int());
            CreateIndex("dbo.Students", "FieldOfStudy_SubjectId");
            AddForeignKey("dbo.Students", "FieldOfStudy_SubjectId", "dbo.FieldOfStudies", "SubjectId");
            DropColumn("dbo.Students", "FieldOfStudy_Subject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "FieldOfStudy_Subject", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "FieldOfStudy_SubjectId", "dbo.FieldOfStudies");
            DropIndex("dbo.Students", new[] { "FieldOfStudy_SubjectId" });
            DropColumn("dbo.Students", "FieldOfStudy_SubjectId");
        }
    }
}
