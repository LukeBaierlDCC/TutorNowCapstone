namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentsubjectsmigrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Subcategory_SubjectId", c => c.Int());
            AddColumn("dbo.Subcategories", "Student_StudentId", c => c.Int());
            CreateIndex("dbo.Students", "SubjectId");
            CreateIndex("dbo.Students", "Subcategory_SubjectId");
            CreateIndex("dbo.Subcategories", "Student_StudentId");
            AddForeignKey("dbo.Subcategories", "Student_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Students", "Subcategory_SubjectId", "dbo.Subcategories", "SubjectId");
            AddForeignKey("dbo.Students", "SubjectId", "dbo.FieldOfStudies", "SubjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SubjectId", "dbo.FieldOfStudies");
            DropForeignKey("dbo.Students", "Subcategory_SubjectId", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Subcategories", new[] { "Student_StudentId" });
            DropIndex("dbo.Students", new[] { "Subcategory_SubjectId" });
            DropIndex("dbo.Students", new[] { "SubjectId" });
            DropColumn("dbo.Subcategories", "Student_StudentId");
            DropColumn("dbo.Students", "Subcategory_SubjectId");
        }
    }
}
