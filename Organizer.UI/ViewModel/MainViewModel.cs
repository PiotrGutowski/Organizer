using Organizer.Model;
using Organizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public INavigationViewModel NavigationViewModel { get; }
        public IFriendDetailViewModel FriendDetailViewModel { get; }
      

        public MainViewModel( INavigationViewModel navigationViewModel, IFriendDetailViewModel friendDetailViewModel)
        {

            FriendDetailViewModel = friendDetailViewModel;
            NavigationViewModel = navigationViewModel;
        }
 
        public async Task LoadAsync()
        {
           await NavigationViewModel.LoadAsync();

        }

          

      
    }
}
