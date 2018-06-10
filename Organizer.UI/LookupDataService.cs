using Organizer.DataAccess;
using Organizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI
{
    public class LookupDataService : IFriendLookupDataService
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

    }
}
