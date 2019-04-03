namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class completedmodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tutors", "State", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "State", c => c.String());
            AlterColumn("dbo.Tutors", "State", c => c.String(nullable: false));
        }
    }
}
