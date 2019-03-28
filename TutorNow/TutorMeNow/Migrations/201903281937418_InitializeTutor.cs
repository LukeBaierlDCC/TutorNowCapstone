namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeTutor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        TutorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Gender = c.Int(),
                        AvgRating = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TutorId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Tutors", new[] { "SubjectId" });
            DropTable("dbo.Tutors");
        }
    }
}
