using Organizer.Model;
using Organizer.UI.Data;
using Organizer.UI.Data.Lookups;
using Organizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.ViewModel
{
   public class NavigationViewModel : ViewModelBase,  INavigationViewModel
    {
        private readonly IFriendLookupDataService _friendLookupDataService;
        private readonly IEventAggregator _eventAggregator;
        public NavigationViewModel(IFriendLookupDataService friendLookupDataService, IEventAggregator eventAggregator)
        {
            _friendLookupDataService = friendLookupDataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterFriendSaveEvent>().Subscribe(AfterFriendSaved);
            _eventAggregator.GetEvent<AfterFriendDeletedEvent>().Subscribe(AfterFriendDeleted);
        }

        public async Task LoadAsync()
        {
            var lookup = await _friendLookupDataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMember, _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; }

        private void AfterFriendSaved(AfterFriendSaveEventArgs obj)
        {
           var lookupItem =  Friends.SingleOrDefault(l => l.Id == obj.Id);
            if(lookupItem == null)
            {
                Friends.Add(new NavigationItemViewModel(obj.Id, obj.DisplayMember, _eventAggregator));
            }
            else
            {
                lookupItem.DisplayMember = obj.DisplayMember;
            }
        
        }

        private void AfterFriendDeleted(int friendId)
        {
            var friend = Friends.SingleOrDefault(f => f.Id == friendId);
            if (friend != null)
            {
                Friends.Remove(friend);
            }
        }

       
       
    }
}
