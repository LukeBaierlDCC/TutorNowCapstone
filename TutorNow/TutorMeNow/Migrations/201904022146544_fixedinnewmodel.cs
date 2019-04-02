namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedinnewmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RatingViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        State = c.Int(nullable: false),
                        Rating_RatingId = c.Int(),
                        Tutor_TutorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ratings", t => t.Rating_RatingId)
                .ForeignKey("dbo.Tutors", t => t.Tutor_TutorId)
                .Index(t => t.Rating_RatingId)
                .Index(t => t.Tutor_TutorId);
            
            AddColumn("dbo.Ratings", "RatingView_Id", c => c.Int());
            CreateIndex("dbo.Ratings", "RatingView_Id");
            AddForeignKey("dbo.Ratings", "RatingView_Id", "dbo.RatingViews", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatingViews", "Tutor_TutorId", "dbo.Tutors");
            DropForeignKey("dbo.Ratings", "RatingView_Id", "dbo.RatingViews");
            DropForeignKey("dbo.RatingViews", "Rating_RatingId", "dbo.Ratings");
            DropIndex("dbo.RatingViews", new[] { "Tutor_TutorId" });
            DropIndex("dbo.RatingViews", new[] { "Rating_RatingId" });
            DropIndex("dbo.Ratings", new[] { "RatingView_Id" });
            DropColumn("dbo.Ratings", "RatingView_Id");
            DropTable("dbo.RatingViews");
        }
    }
}
