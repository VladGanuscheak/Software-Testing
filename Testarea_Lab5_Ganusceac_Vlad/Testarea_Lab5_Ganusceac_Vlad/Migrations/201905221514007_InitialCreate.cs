namespace Testarea_Lab5_Ganusceac_Vlad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Attestation_first = c.Single(nullable: false),
                        Attestation_second = c.Single(nullable: false),
                        Exam = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.CourseId })
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        MiddleName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentGroup",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        DateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.GroupId, t.DateId })
                .ForeignKey("dbo.DateTable", t => t.DateId, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.GroupId)
                .Index(t => t.DateId);
            
            CreateTable(
                "dbo.DateTable",
                c => new
                    {
                        DateId = c.Int(nullable: false, identity: true),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DateId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.StudentProfessor",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        ProfessorId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.ProfessorId, t.CourseId })
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Professor", t => t.ProfessorId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ProfessorId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        MiddleName = c.String(),
                    })
                .PrimaryKey(t => t.ProfessorId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.IdentityUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserLogin", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserClaim", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.StudentCourse", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentProfessor", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentProfessor", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.StudentProfessor", "CourseId", "dbo.Course");
            DropForeignKey("dbo.StudentGroup", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentGroup", "GroupId", "dbo.Group");
            DropForeignKey("dbo.StudentGroup", "DateId", "dbo.DateTable");
            DropForeignKey("dbo.StudentCourse", "CourseId", "dbo.Course");
            DropIndex("dbo.IdentityUserLogin", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.StudentProfessor", new[] { "CourseId" });
            DropIndex("dbo.StudentProfessor", new[] { "ProfessorId" });
            DropIndex("dbo.StudentProfessor", new[] { "StudentId" });
            DropIndex("dbo.StudentGroup", new[] { "DateId" });
            DropIndex("dbo.StudentGroup", new[] { "GroupId" });
            DropIndex("dbo.StudentGroup", new[] { "StudentId" });
            DropIndex("dbo.StudentCourse", new[] { "CourseId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.IdentityUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Professor");
            DropTable("dbo.StudentProfessor");
            DropTable("dbo.Group");
            DropTable("dbo.DateTable");
            DropTable("dbo.StudentGroup");
            DropTable("dbo.Student");
            DropTable("dbo.StudentCourse");
            DropTable("dbo.Course");
        }
    }
}
