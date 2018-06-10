using System.Collections.Generic;
using System.Threading.Tasks;
using Organizer.Model;

namespace Organizer.UI
{
    public interface IFriendLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetFriendLookupAsync();
    }
}