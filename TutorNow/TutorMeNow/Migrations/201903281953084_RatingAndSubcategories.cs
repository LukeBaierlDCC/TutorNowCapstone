namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingAndSubcategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        AvgRating = c.Int(nullable: false),
                        TutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Tutors", t => t.TutorId, cascadeDelete: true)
                .Index(t => t.TutorId);
            
            CreateTable(
                "dbo.StudentProgresses",
                c => new
                    {
                        StudentProgressID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.StudentProgressID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentProgresses", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Ratings", "TutorId", "dbo.Tutors");
            DropIndex("dbo.StudentProgresses", new[] { "StudentID" });
            DropIndex("dbo.Ratings", new[] { "TutorId" });
            DropTable("dbo.StudentProgresses");
            DropTable("dbo.Ratings");
        }
    }
}
