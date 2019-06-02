namespace Testarea_Lab5_Ganusceac_Vlad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentCourse", "CourseName", c => c.String());
            AddColumn("dbo.StudentCourse", "Grade", c => c.Single());
            AddColumn("dbo.StudentCourse", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Student", "GroupId", c => c.Int());
            AddColumn("dbo.Student", "GroupName", c => c.String());
            AddColumn("dbo.Student", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.StudentCourse", "Attestation_first", c => c.Single());
            AlterColumn("dbo.StudentCourse", "Attestation_second", c => c.Single());
            AlterColumn("dbo.StudentCourse", "Exam", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentCourse", "Exam", c => c.Single(nullable: false));
            AlterColumn("dbo.StudentCourse", "Attestation_second", c => c.Single(nullable: false));
            AlterColumn("dbo.StudentCourse", "Attestation_first", c => c.Single(nullable: false));
            DropColumn("dbo.Student", "Discriminator");
            DropColumn("dbo.Student", "GroupName");
            DropColumn("dbo.Student", "GroupId");
            DropColumn("dbo.StudentCourse", "Discriminator");
            DropColumn("dbo.StudentCourse", "Grade");
            DropColumn("dbo.StudentCourse", "CourseName");
        }
    }
}
