namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includelearninggoals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "LearningGoal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "LearningGoal");
        }
    }
}
