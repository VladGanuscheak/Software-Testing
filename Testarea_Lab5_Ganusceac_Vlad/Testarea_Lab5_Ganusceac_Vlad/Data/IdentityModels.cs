using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using Testarea_Lab5_Ganusceac_Vlad.Queries;

namespace Testarea_Lab5_Ganusceac_Vlad.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
    }
        }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer<ApplicationDbContext>(null);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        #region DbSets
        public DbSet<Course> Courses { get; set; }

        public DbSet<DateTable> DateTables { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Professor> Professors { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<StudentGroup> StudentGroups { get; set; }

        public DbSet<StudentProfessor> StudentProfessors { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<IdentityUser>().HasKey<string>(u => u.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            #region Course
            modelBuilder.Entity<Course>()
                .HasKey(p => p.CourseId);

            modelBuilder.Entity<Course>()
                .Property(p => p.CourseId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            #endregion

            #region DateTable
            modelBuilder.Entity<DateTable>()
                .HasKey(p => p.DateId);

            modelBuilder.Entity<DateTable>()
                .Property(p => p.DateId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            #endregion

            #region Group
            modelBuilder.Entity<Group>()
                .HasKey(p => p.GroupId);

            modelBuilder.Entity<Group>()
                .Property(p => p.GroupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            #endregion

            #region Professor 
            modelBuilder.Entity<Professor>()
                .HasKey(p => p.ProfessorId);

            modelBuilder.Entity<Professor>()
                .Property(p => p.ProfessorId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            #endregion

            #region Student
            modelBuilder.Entity<Student>()
                .HasKey(p => p.StudentId);

            modelBuilder.Entity<Student>()
                .Property(p => p.StudentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            #endregion

            #region StudentCourse
            modelBuilder.Entity<StudentCourse>()
                .HasKey(p => new { p.StudentId, p.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasRequired<Course>(c => c.Course)
                .WithMany(p => p.StudentCourses)
                .HasForeignKey(fk => fk.CourseId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<StudentCourse>()
                .HasRequired<Student>(s => s.Student)
                .WithMany(p => p.StudentCourses)
                .HasForeignKey(fk => fk.StudentId)
                .WillCascadeOnDelete(true);
            #endregion

            #region StudentGroup
            modelBuilder.Entity<StudentGroup>()
                .HasKey(p => new { p.StudentId, p.GroupId, p.DateId });

            modelBuilder.Entity<StudentGroup>()
                .HasRequired<Student>(s => s.Student)
                .WithMany(c => c.StudentGroups)
                .HasForeignKey(fk => fk.StudentId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<StudentGroup>()
                .HasRequired<Group>(g => g.Group)
                .WithMany(p => p.StudentGroups)
                .HasForeignKey(fk => fk.GroupId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<StudentGroup>()
                .HasRequired<DateTable>(d => d.DateTable)
                .WithMany(p => p.StudentGroups)
                .HasForeignKey(fk => fk.DateId)
                .WillCascadeOnDelete(true);
            #endregion

            #region StudentProfessor
            modelBuilder.Entity<StudentProfessor>()
                .HasKey(p => new { p.StudentId, p.ProfessorId, p.CourseId });

            modelBuilder.Entity<StudentProfessor>()
                .HasRequired<Student>(s => s.Student)
                .WithMany(p => p.StudentProfessors)
                .HasForeignKey(fk => fk.StudentId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<StudentProfessor>()
                .HasRequired<Professor>(s => s.Professor)
                .WithMany(p => p.StudentProfessors)
                .HasForeignKey(fk => fk.ProfessorId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<StudentProfessor>()
                .HasRequired<Course>(c => c.Course)
                .WithMany(p => p.StudentProfessors)
                .HasForeignKey(fk => fk.CourseId)
                .WillCascadeOnDelete(true);
            #endregion
        }
    }

    public class LabDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext> //CreateDatabaseIfNotExists<Pharmacy_DBContext>
    {
        #region Seed(ApplicationDbContext db)
        protected override void Seed(ApplicationDbContext db)
        {
            StudentsQueries studentsQueries = new StudentsQueries();

            db.Groups.Add(new Group
            {
                GroupName = "FAF-161"
            });

            db.Groups.Add(new Group
            {
                GroupName = "FI-161"
            });

            db.Groups.Add(new Group
            {
                GroupName = "FAF-171"
            });

            studentsQueries.CreateStudent(new ViewModels.StudentViewModel
            {
                FirstName = "Bacal",
                SecondName = "Tatiana",
                MiddleName = "Vitalii",
                GroupName = "FAF-161",
                GroupId = 1
            });

            studentsQueries.CreateStudent(new ViewModels.StudentViewModel
            {
                FirstName = "Vlad",
                SecondName = "Ganusceac",
                MiddleName = "Oleg",
                GroupName = "FAF-161",
                GroupId = 1
            });
            
            studentsQueries.CreateStudent(new ViewModels.StudentViewModel
            {
                FirstName = "Dincer",
                SecondName = "Deniz",
                MiddleName = "Metin",
                GroupName = "FAF-161",
                GroupId = 1
            });

            studentsQueries.CreateStudent(new ViewModels.StudentViewModel
            {
                FirstName = "Erol",
                SecondName = "Sezgin",
                MiddleName = "Mahmud",
                GroupName = "FAF-161",
                GroupId = 1
            });

            studentsQueries.CreateStudent(new ViewModels.StudentViewModel
            {
                FirstName = "Metei",
                SecondName = "Vasile",
                MiddleName = "Ion",
                GroupName = "FAF-161",
                GroupId = 1,
            });

            //db.Students.Add(new Student { FirstName = "Ganusceac", SecondName = "Vlad", MiddleName = "Oleg" });

            base.Seed(db);
        }
        #endregion
    }
}