namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includingflashcards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrammarFlashcards",
                c => new
                    {
                        GrammarId = c.Int(nullable: false, identity: true),
                        GrammarQuestion = c.String(),
                        GrammarAnswer = c.String(),
                    })
                .PrimaryKey(t => t.GrammarId);
            
            CreateTable(
                "dbo.MathWordProblems",
                c => new
                    {
                        MathId = c.Int(nullable: false, identity: true),
                        MathQuestion = c.String(),
                        MathAnswer = c.String(),
                    })
                .PrimaryKey(t => t.MathId);
            
            CreateTable(
                "dbo.ScienceFlashcards",
                c => new
                    {
                        ScienceId = c.Int(nullable: false, identity: true),
                        ScienceQuestion = c.String(),
                        ScienceAnswer = c.String(),
                    })
                .PrimaryKey(t => t.ScienceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScienceFlashcards");
            DropTable("dbo.MathWordProblems");
            DropTable("dbo.GrammarFlashcards");
        }
    }
}
