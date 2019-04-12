namespace TutorMeNow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bamalama : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subcategories", "Subcategory_SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Tutors", "SubcategoryId", "dbo.Subcategories");
            RenameColumn(table: "dbo.Subcategories", name: "Subcategory_SubcategoryId", newName: "Subcategory_SubjectId");
            RenameIndex(table: "dbo.Subcategories", name: "IX_Subcategory_SubcategoryId", newName: "IX_Subcategory_SubjectId");
            DropPrimaryKey("dbo.Subcategories");
            AddColumn("dbo.FieldOfStudies", "Subcategory", c => c.String());
            AddColumn("dbo.FieldOfStudies", "Other", c => c.String());
            AlterColumn("dbo.Subcategories", "SubcategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Subcategories", "SubjectId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Subcategories", "SubjectId");
            AddForeignKey("dbo.Subcategories", "Subcategory_SubjectId", "dbo.Subcategories", "SubjectId");
            AddForeignKey("dbo.Tutors", "SubcategoryId", "dbo.Subcategories", "SubjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutors", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "Subcategory_SubjectId", "dbo.Subcategories");
            DropPrimaryKey("dbo.Subcategories");
            AlterColumn("dbo.Subcategories", "SubjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Subcategories", "SubcategoryId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.FieldOfStudies", "Other");
            DropColumn("dbo.FieldOfStudies", "Subcategory");
            AddPrimaryKey("dbo.Subcategories", "SubcategoryId");
            RenameIndex(table: "dbo.Subcategories", name: "IX_Subcategory_SubjectId", newName: "IX_Subcategory_SubcategoryId");
            RenameColumn(table: "dbo.Subcategories", name: "Subcategory_SubjectId", newName: "Subcategory_SubcategoryId");
            AddForeignKey("dbo.Tutors", "SubcategoryId", "dbo.Subcategories", "SubcategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Subcategories", "Subcategory_SubcategoryId", "dbo.Subcategories", "SubcategoryId");
        }
    }
}
