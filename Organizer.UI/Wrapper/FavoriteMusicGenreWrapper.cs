using Organizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.Wrapper
{
    public class FavoriteMusicGenreWrapper : ModelWrapper<FavoriteMusicGenre>
    {
        public FavoriteMusicGenreWrapper(FavoriteMusicGenre model) : base(model)
        {
        }

        public int Id { get { return Model.Id; } }
        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
