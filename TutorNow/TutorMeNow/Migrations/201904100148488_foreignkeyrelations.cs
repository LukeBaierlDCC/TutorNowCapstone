namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includingstuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "PastSession", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "AvgRating", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "StudentId");
            AddForeignKey("dbo.Ratings", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "StudentId", "dbo.Students");
            DropIndex("dbo.Ratings", new[] { "StudentId" });
            DropColumn("dbo.Students", "AvgRating");
            DropColumn("dbo.Students", "PastSession");
            DropColumn("dbo.Ratings", "StudentId");
        }
    }
}
