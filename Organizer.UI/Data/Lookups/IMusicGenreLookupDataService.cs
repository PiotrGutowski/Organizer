using System.Collections.Generic;
using System.Threading.Tasks;
using Organizer.Model;

namespace Organizer.UI.Data.Lookups
{
    public interface IMusicGenreLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetMusicGenreLookupAsync();
    }
}