namespace Testarea_Lab5_Ganusceac_Vlad.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Testarea_Lab5_Ganusceac_Vlad.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Testarea_Lab5_Ganusceac_Vlad.Models.ApplicationDbContext";
        }

        protected override void Seed(Testarea_Lab5_Ganusceac_Vlad.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
