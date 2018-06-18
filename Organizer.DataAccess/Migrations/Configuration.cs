namespace Organizer.DataAccess.Migrations
{
    using Organizer.Model;
    using System;
    using System.Collections.Generic;
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
            context.FavoriteMusicGenre.AddOrUpdate(
                h => h.Name,
                new FavoriteMusicGenre { Name = "Rock" },
                new FavoriteMusicGenre { Name = "HeavyMetal" },
                new FavoriteMusicGenre { Name = "HardCore" },
                new FavoriteMusicGenre { Name = "Disco" },
                new FavoriteMusicGenre { Name = "RAP" },
                new FavoriteMusicGenre { Name = "Classic" }
                );
            context.SaveChanges();
            context.FriendPhoneNumbers.AddOrUpdate(
                p => p.Number,
                new FriendPhoneNumber { Number = "555-555-555", FrinedId = context.Friends.FirstOrDefault().Id });

            context.Meetings.AddOrUpdate(m => m.Title,
        new Meeting
        {
            Title = "Watching Football",
            DateFrom = new DateTime(2018, 5, 26),
            DateTo = new DateTime(2018, 5, 26),
            Friends = new List<Friend>
          {
            context.Friends.Single(f => f.FirstName == "Rocky" && f.LastName == "Balboa"),
            context.Friends.Single(f => f.FirstName == "Capitan" && f.LastName == "Amercia")
          }
        });

        }
    }
}
