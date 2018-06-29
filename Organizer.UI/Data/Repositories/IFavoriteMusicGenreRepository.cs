using Organizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.Data.Repositories
{
    public interface IFavoriteMusicGenreRepository
         : IGenericRepository<FavoriteMusicGenre>
    {
        Task<bool> IsReferencedByFriendAsync(int musicId);
    }
}
