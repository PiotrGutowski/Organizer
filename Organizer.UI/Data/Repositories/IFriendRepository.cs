using System.Collections.Generic;
using Organizer.Model;

namespace Organizer.UI.Data.Repositories
{

    public interface IFriendRepository : IGenericRepository<Friend>
    {
       
        void RemovePhoneNumber(FriendPhoneNumber model);
    }
} 