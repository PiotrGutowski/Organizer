using Autofac.Features.Indexed;
using Organizer.Model;
using Organizer.UI.Data;
using Organizer.UI.Event;
using Organizer.UI.View.Services;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Organizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {


        public  INavigationViewModel NavigationViewModel { get; }

        private readonly IEventAggregator _eventAggregator;

        private IDetailViewModel _detailViewModel;

        private readonly IMessageDialogService _messageDialogService;
        private readonly IIndex<string, IDetailViewModel> _detailViewModelCreator;

        public MainViewModel(INavigationViewModel navigationViewModel
            , IIndex<string, IDetailViewModel> detailViewModelCreator, IEventAggregator eventAggregator
            
            , IMessageDialogService messageDialogService)
        {
            _messageDialogService = messageDialogService;
            _detailViewModelCreator = detailViewModelCreator;
       
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenDetailViewEvent>()
               .Subscribe(OnOpenDetailView);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            CreateNewDetailCommand = new DelegateCommand<Type>(OnCreateNewDetailExecute);

            NavigationViewModel = navigationViewModel;
        }

       
        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();

        }

        public IDetailViewModel DetailViewModel
        {
            get { return _detailViewModel; }
            private set
            {
                _detailViewModel = value;
                OnPropertyChanged();
            }

        }

        public ICommand CreateNewDetailCommand { get; }

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            if(DetailViewModel!=null && DetailViewModel.HasChanges)
            {
               var result = _messageDialogService.ShowOkCancelDialog("You Have made changes. Navigare away?", "Question");  
                if (result == MessageDialogResult.Cancel)
                {
                    return;
                }

            }
            DetailViewModel = _detailViewModelCreator[args.ViewModelName];
       
            await DetailViewModel.LoadAsync(args.Id);
           
        }

        private void AfterDetailDeleted (AfterDetailDeletedEventArgs args)
        {
            DetailViewModel = null;
        }

        private void OnCreateNewDetailExecute(Type viewModelType)
        {
            OnOpenDetailView(new OpenDetailViewEventArgs { ViewModelName = viewModelType.Name });
        }


        
    }
}

      




    

