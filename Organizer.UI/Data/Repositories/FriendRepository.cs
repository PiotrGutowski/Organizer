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

    public class FriendRepository : GenericRepository<Friend, OrganizerDbContext>,
                                    IFriendRepository
    {
        
        public FriendRepository(OrganizerDbContext organizerDbContext): base(organizerDbContext)
        {
            
        }

        public override async Task<Friend>GetByIdAsync(int friendId)
        {

            return await Context.Friends.Include(p=>p.PhoneNumbers)
                .SingleAsync(f => f.Id == friendId);
            
        }

    
        public void RemovePhoneNumber(FriendPhoneNumber model)
        {
           Context.FriendPhoneNumbers.Remove(model);
        }

    }
}
