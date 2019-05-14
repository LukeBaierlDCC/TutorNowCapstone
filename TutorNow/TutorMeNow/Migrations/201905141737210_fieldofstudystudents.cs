namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fieldofstudystudents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FieldOfStudy_Subject", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "FieldOfStudy_Subject");
        }
    }
}
