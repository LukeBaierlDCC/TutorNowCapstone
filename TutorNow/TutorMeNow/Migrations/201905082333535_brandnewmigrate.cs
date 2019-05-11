namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brandnewmigrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subcategories", "Tutor_TutorId1", c => c.Int());
            CreateIndex("dbo.Subcategories", "Tutor_TutorId1");
            AddForeignKey("dbo.Subcategories", "Tutor_TutorId1", "dbo.Tutors", "TutorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "Tutor_TutorId1", "dbo.Tutors");
            DropIndex("dbo.Subcategories", new[] { "Tutor_TutorId1" });
            DropColumn("dbo.Subcategories", "Tutor_TutorId1");
        }
    }
}
