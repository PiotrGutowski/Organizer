using Organizer.UI.Event;
using Organizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;
using Organizer.UI.Data.Repositories;
using Organizer.Model;
using System;
using Organizer.UI.View.Services;

namespace Organizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private readonly IFriendRepository _dataService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IMessageDialogService _messageDialogService;
        private FriendWrapper _friend;
        private bool _hasChanges;

        public FriendDetailViewModel(IFriendRepository dataService,
            IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute);
        }


        public async Task LoadAsync(int? friendId)
        {
            var friend = friendId.HasValue
                 ? await _dataService.GetByIdAsync(friendId.Value) : CreateNewFriend();

            Friend = new FriendWrapper(friend);

            Friend.PropertyChanged += (s, e) =>
                {
                    if (!HasChanges)
                    {
                        HasChanges = _dataService.HasChanges();
                    }
                    if (e.PropertyName == nameof(Friend.HasErrors))
                    {
                        ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                    }
                };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            if (Friend.Id == 0)
            {
                Friend.FirstName = ""; 
            }
        }


        public FriendWrapper Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

                }
            }
        }

        public ICommand SaveCommand { get; }

        public ICommand DeleteCommand { get; }

        private bool OnSaveCanExecute()
        {
            return Friend != null && !Friend.HasErrors && HasChanges;
        }

        private async void OnSaveExecute()
        {
            await _dataService.SaveAsync();
            HasChanges = _dataService.HasChanges();
            _eventAggregator.GetEvent<AfterFriendSaveEvent>().Publish(
                new AfterFriendSaveEventArgs
                {
                    Id = Friend.Id,
                    DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
                });
        }


        private Friend CreateNewFriend()
        {
            var friend = new Friend();
            _dataService.Add(friend);
            return friend;
        }

        private async void OnDeleteExecute()
        {
            var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete {Friend.FirstName} {Friend.LastName}", "Question");
            if(result == MessageDialogResult.OK)
            {
                _dataService.Remove(Friend.Model);
                await _dataService.SaveAsync();
                _eventAggregator.GetEvent<AfterFriendDeletedEvent>().Publish(Friend.Id);
            }
            
        }
    }
}
