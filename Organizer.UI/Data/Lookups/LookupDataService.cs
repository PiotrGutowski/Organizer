using Organizer.DataAccess;
using Organizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.Data.Lookups
{
    public class LookupDataService : IFriendLookupDataService, IMusicGenreLookupDataService, IMeetingLookupDataService
    {
        private readonly OrganizerDbContext _organizerDbContext;
        public LookupDataService(OrganizerDbContext organizerDbContext)
        {
            _organizerDbContext = organizerDbContext;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
           return await _organizerDbContext.Friends.AsNoTracking()
                .Select(f => new LookupItem
                {
                    Id = f.Id,
                    DisplayMember = f.FirstName + " " + f.LastName
                }
                    ).ToListAsync();

        }

        public async Task<IEnumerable<LookupItem>> GetMusicGenreLookupAsync()
        {
            return await _organizerDbContext.FavoriteMusicGenre.AsNoTracking()
                 .Select(f => new LookupItem
                 {
                     Id = f.Id,
                     DisplayMember = f.Name 
                 }
                     ).ToListAsync();

        }
        public async Task<IEnumerable<LookupItem>> GetMeetingLookupAsync()
        {
            return await _organizerDbContext.Meetings.AsNoTracking()
                 .Select(f => new LookupItem
                 {
                     Id = f.Id,
                     DisplayMember = f.Title
                 }
                     ).ToListAsync();
            
        }


    }
}
