namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Gender = c.Int(),
                        SubjectId = c.Int(nullable: false),
                        SubjectName_SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.SubjectName_SubjectId)
                .Index(t => t.SubjectName_SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SubjectName_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Subjects", new[] { "Student_StudentId" });
            DropIndex("dbo.Students", new[] { "SubjectName_SubjectId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
        }
    }
}
