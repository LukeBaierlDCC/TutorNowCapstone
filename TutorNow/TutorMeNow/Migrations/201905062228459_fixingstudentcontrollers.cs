namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingstudentcontrollers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Tutors", "ZipCode", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "Zip");
            DropColumn("dbo.Tutors", "Zip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tutors", "Zip", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Zip", c => c.Int(nullable: false));
            DropColumn("dbo.Tutors", "ZipCode");
            DropColumn("dbo.Students", "ZipCode");
        }
    }
}
