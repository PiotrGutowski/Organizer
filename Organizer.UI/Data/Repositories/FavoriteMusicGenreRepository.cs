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
    public class FavoriteMusicGenreRepository : GenericRepository<FavoriteMusicGenre, OrganizerDbContext>,
         IFavoriteMusicGenreRepository
    {
        public FavoriteMusicGenreRepository(OrganizerDbContext context) 
            : base(context)
        {
        }

        public async Task<bool> IsReferencedByFriendAsync(int musicId)
        {
            return await Context.Friends.AsNoTracking()
                .AnyAsync(f => f.FavoriteMusicGenreId == musicId);
        }
    }
}
