using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Organizer.Model;
using Organizer.UI.Data.Repositories;
using Organizer.UI.View.Services;
using Organizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;

namespace Organizer.UI.ViewModel
{
    public class FavoriteMusicGenreDetailViewModel:DetailViewModelBase
    {
        private IFavoriteMusicGenreRepository _favoriteMusicGenreRepository;
        private FavoriteMusicGenreWrapper _selectedFavoriteMusicGenre;

        public FavoriteMusicGenreDetailViewModel(IEventAggregator ewentAggreagator, 
            IMessageDialogService messageDialogService, IFavoriteMusicGenreRepository favoriteMusicGenreRepository) : base(ewentAggreagator, messageDialogService)
        {
            _favoriteMusicGenreRepository = favoriteMusicGenreRepository;
            Title = "Music Genre";

            FavoriteMusicGenres = new ObservableCollection<FavoriteMusicGenreWrapper>();
            AddCommand = new DelegateCommand(OnAddExecute);
            RemoveCommand = new DelegateCommand(OnRemoveExecute, OnRemoveCanExecute);
        }

        private void OnAddExecute()
        {
            var wrapper = new FavoriteMusicGenreWrapper(new FavoriteMusicGenre());
            wrapper.PropertyChanged += Wrapper_PropertyChanged;
            _favoriteMusicGenreRepository.Add(wrapper.Model);
            FavoriteMusicGenres.Add(wrapper);

            wrapper.Name = "";
        }

    

        private bool OnRemoveCanExecute()
        {
            return SelectedFavoriteMusicGenre != null;
        }

        public ObservableCollection<FavoriteMusicGenreWrapper> FavoriteMusicGenres { get; }

        public ICommand RemoveCommand { get; }
        public ICommand AddCommand { get; }

        public FavoriteMusicGenreWrapper SelectedFavoriteMusicGenre
        {
            get { return _selectedFavoriteMusicGenre; }
            set
            {
                _selectedFavoriteMusicGenre = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveCommand).RaiseCanExecuteChanged();
            }
        }

        public async override Task LoadAsync(int id)
        {
            Id = id;

            foreach (var wrapper in FavoriteMusicGenres)
            {
                wrapper.PropertyChanged -= Wrapper_PropertyChanged;
            }

            FavoriteMusicGenres.Clear();

            var music = await _favoriteMusicGenreRepository.GetAllAsync();

            foreach (var model in music)
            {
                var wrapper = new FavoriteMusicGenreWrapper(model);
                wrapper.PropertyChanged += Wrapper_PropertyChanged;
                FavoriteMusicGenres.Add(wrapper);
            }
        }
        private void Wrapper_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!HasChanges)
            {
                HasChanges = _favoriteMusicGenreRepository.HasChanges();
            }
            if (e.PropertyName == nameof(FavoriteMusicGenreWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }
        protected override void OnDeleteExecute()
        {
            throw new NotImplementedException();
        }

        protected override bool OnSaveCanExecute()
        {
            return HasChanges && FavoriteMusicGenres.All(m => !m.HasErrors);
        }

        protected async override void OnSaveExecute()
        {
            try
            {
                await _favoriteMusicGenreRepository.SaveAsync();
                HasChanges = _favoriteMusicGenreRepository.HasChanges();
                RaiseCollectionSavedEvent();
            }catch(Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
               await MessageDialogService.ShowInfoDialogAsync("Error while saving the entities, " +
                  "the data will be reloaded. Details: " + ex.Message);
                await LoadAsync(Id);
            }
        }

        private async void OnRemoveExecute()
        {
            var isReferenced =
              await _favoriteMusicGenreRepository.IsReferencedByFriendAsync(
                SelectedFavoriteMusicGenre.Id);
            if (isReferenced)
            {
               await MessageDialogService.ShowInfoDialogAsync($"The music genre {SelectedFavoriteMusicGenre.Name}" +
                  $" can't be removed, as it is referenced by at least one friend");
                return;
            }

            SelectedFavoriteMusicGenre.PropertyChanged -= Wrapper_PropertyChanged;
            _favoriteMusicGenreRepository.Remove(SelectedFavoriteMusicGenre.Model);
            FavoriteMusicGenres.Remove(SelectedFavoriteMusicGenre);
            SelectedFavoriteMusicGenre= null;
            HasChanges = _favoriteMusicGenreRepository.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

    }
}
