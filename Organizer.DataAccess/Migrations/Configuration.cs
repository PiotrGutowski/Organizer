namespace Organizer.DataAccess.Migrations
{
    using Organizer.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Organizer.DataAccess.OrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Organizer.DataAccess.OrganizerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Friends.AddOrUpdate(
                f => f.FirstName,
                new Friend { FirstName = "ala", LastName = "Gut" },
                 new Friend { FirstName = "Piotr", LastName = "Gut" },
                new Friend { FirstName = "John", LastName = "Rambo" },
                 new Friend { FirstName = "Adam", LastName = "Mickiewicz" }
                );
        }
    }
}
