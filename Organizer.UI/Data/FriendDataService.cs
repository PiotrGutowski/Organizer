using Organizer.DataAccess;
using Organizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.Data
{
   public class FriendDataService : IFriendDataService
    {
        private readonly OrganizerDbContext _organizerDbContext;
        public FriendDataService(OrganizerDbContext organizerDbContext)
        {
            _organizerDbContext = organizerDbContext;
        }

        public async Task<Friend>GetByIdAsync(int friendId)
        {


            return await _organizerDbContext.Friends.AsNoTracking().SingleAsync(f => f.Id == friendId);
            
        }
    }
}
