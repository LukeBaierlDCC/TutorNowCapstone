namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mathscienceenglishadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Englishes",
                c => new
                    {
                        EnglishId = c.Int(nullable: false, identity: true),
                        EnglishSubcategory = c.String(),
                        EnglishTutor = c.String(),
                        EnglishStudent = c.String(),
                    })
                .PrimaryKey(t => t.EnglishId);
            
            CreateTable(
                "dbo.Maths",
                c => new
                    {
                        MathId = c.Int(nullable: false, identity: true),
                        MathSubcategory = c.String(),
                        MathTutor = c.String(),
                        MathStudent = c.String(),
                    })
                .PrimaryKey(t => t.MathId);
            
            CreateTable(
                "dbo.Sciences",
                c => new
                    {
                        ScienceId = c.Int(nullable: false, identity: true),
                        ScienceSubcategory = c.String(),
                        ScienceTutor = c.String(),
                        ScienceStudent = c.String(),
                    })
                .PrimaryKey(t => t.ScienceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sciences");
            DropTable("dbo.Maths");
            DropTable("dbo.Englishes");
        }
    }
}
