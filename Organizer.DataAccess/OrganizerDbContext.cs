using Organizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.DataAccess
{
    public class OrganizerDbContext: DbContext
    {
        public OrganizerDbContext(): base("Organizer")
        {

        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<FavoriteMusicGenre> FavoriteMusicGenre { get; set; }
        public DbSet<FriendPhoneNumber> FriendPhoneNumbers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
