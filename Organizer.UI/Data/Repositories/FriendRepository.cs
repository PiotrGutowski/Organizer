using Organizer.DataAccess;
using Organizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.Data.Repositories
{
   public class FriendRepository : IFriendRepository
    {
        private readonly OrganizerDbContext _organizerDbContext;
        public FriendRepository(OrganizerDbContext organizerDbContext)
        {
            _organizerDbContext = organizerDbContext;
        }

        public async Task<Friend>GetByIdAsync(int friendId)
        {

            return await _organizerDbContext.Friends.SingleAsync(f => f.Id == friendId);
            
        }

        public bool HasChanges()
        {
            return _organizerDbContext.ChangeTracker.HasChanges();
        }

        public async Task SaveAsync()
        {
        
            await _organizerDbContext.SaveChangesAsync();
        }
    }
}
