namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcategorytutormigrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subcategories", "Tutor_TutorId", c => c.Int());
            CreateIndex("dbo.Subcategories", "Tutor_TutorId");
            AddForeignKey("dbo.Subcategories", "Tutor_TutorId", "dbo.Tutors", "TutorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "Tutor_TutorId", "dbo.Tutors");
            DropIndex("dbo.Subcategories", new[] { "Tutor_TutorId" });
            DropColumn("dbo.Subcategories", "Tutor_TutorId");
        }
    }
}
