namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includeratingviewmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutors", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Tutors", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Tutors", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Tutors", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tutors", "Gender", c => c.Int());
            AlterColumn("dbo.Tutors", "State", c => c.String());
            AlterColumn("dbo.Tutors", "City", c => c.String());
            DropColumn("dbo.Tutors", "Street");
        }
    }
}
