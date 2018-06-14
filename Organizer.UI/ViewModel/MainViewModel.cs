using Organizer.Model;
using Organizer.UI.Data;
using Organizer.UI.Event;
using Organizer.UI.View.Services;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Organizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Func<IFriendDetailViewModel> _friendDetailViewModelCreator;

        public  INavigationViewModel NavigationViewModel { get; }

        private readonly IEventAggregator _eventAggregator;

        private IFriendDetailViewModel _friendDetailViewModel;

        private readonly IMessageDialogService _messageDialogService;


        public MainViewModel(INavigationViewModel navigationViewModel
            , Func<IFriendDetailViewModel> friendDetailViewModelCreator, IEventAggregator eventAggregator
            ,IMessageDialogService messageDialogService)
        {
            _messageDialogService = messageDialogService;
            _friendDetailViewModelCreator = friendDetailViewModelCreator;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
               .Subscribe(OnOpenFriendDetailView);

            NavigationViewModel = navigationViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();

        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            if(FriendDetailViewModel!=null && FriendDetailViewModel.HasChanges)
            {
               var result = _messageDialogService.ShowOkCancelDialog("You Have made changes. Navigare away?", "Question");  
                if (result == MessageDialogResult.Cancel)
                {
                    return;
                }

            }
            FriendDetailViewModel = _friendDetailViewModelCreator();
            await FriendDetailViewModel.LoadAsync(friendId);
           
        }

        public IFriendDetailViewModel FriendDetailViewModel
        {
            get { return _friendDetailViewModel; }
            private set { _friendDetailViewModel = value;
                OnPropertyChanged();
            }

        }
    }
}

      




    

