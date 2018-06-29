using Organizer.DataAccess;
using Organizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Organizer.UI.Data.Repositories
{
    public class MeetingRepository : GenericRepository<Meeting, OrganizerDbContext>, IMeetingRepository
    {
        public  MeetingRepository(OrganizerDbContext context) : base(context)
        {
            
        }

        public async Task<List<Friend>> GetAllFriendsAsync()
        {
            return await Context.Set<Friend>().ToListAsync();
        }

        public override async Task<Meeting> GetByIdAsync(int id)
        {
            return await Task.FromResult(Context.Meetings.Include(m => m.Friends).SingleOrDefault(x => x.Id == id)); 
        }

        public async Task ReloadFriendAsync(int friendId)
        {
            var dbEntityEntry = Context.ChangeTracker.Entries<Friend>()
                .SingleOrDefault(db => db.Entity.Id == friendId);
            if (dbEntityEntry != null)
            {
               await  dbEntityEntry.ReloadAsync();
            }
        }
    }
}
