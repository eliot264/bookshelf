using Bookshelf.Commands;
using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.Factories;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookshelf.ViewModels
{
    public class EntityListingViewModel<T> : ViewModelBase where T : DomainObject, new()
    {
        private readonly IDataService<T> _dataService;
        private readonly IWindowService<EntityDetailsWindow> _windowService;
        public readonly IEntityListingElementViewModelFactory<T> _entityListingElementViewModelFactory;
        public readonly IEntityDetailsViewModelFactory<T> _entityDetailsViewModelFactory;

        private readonly ObservableCollection<EntityListingElementViewModel<T>> _entities;
        private readonly ObservableCollection<T> _checkedEntities;
        private int _checkedEntitiesCount;

        public ObservableCollection<EntityListingElementViewModel<T>> Entities => _entities;
        public int CheckedEntitiesNumber
        {
            get { return _checkedEntitiesCount; }
            set
            {
                _checkedEntitiesCount = value;
                OnPropertyChanged(nameof(CheckedEntitiesNumber));
            }
        }

        public ICommand OpenAddEntityWindowCommand { get; set; }
        public ICommand DeleteEntitiesCommand { get; set; }

        protected EntityListingViewModel(IDataService<T> dataService, IWindowService<EntityDetailsWindow> windowService, IEntityListingElementViewModelFactory<T> entityListingElementViewModelFactory, IEntityDetailsViewModelFactory<T> entityDetailsViewModelFactory)
        {
            _entityListingElementViewModelFactory = entityListingElementViewModelFactory;
            _entityDetailsViewModelFactory = entityDetailsViewModelFactory;
            _dataService = dataService;
            _windowService = windowService;
            _entities = new ObservableCollection<EntityListingElementViewModel<T>>();
            _checkedEntities = new ObservableCollection<T>();
            _checkedEntitiesCount = 0;

            OpenAddEntityWindowCommand = new OpenEntityDetailsWindowCommand<T>(this, _windowService, _entityDetailsViewModelFactory);
            DeleteEntitiesCommand = new DeleteEntityCommand<T>(_dataService, _checkedEntities, this);
        }

        protected void LoadEntities()
        {
            _dataService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    foreach (var entity in task.Result)
                    {
                        Entities.Add(_entityListingElementViewModelFactory.CreateViewModel(this, entity));
                    }
                }
            });
        }
        public void AddEntityToList(T entity)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Entities.Add(_entityListingElementViewModelFactory.CreateViewModel(this, entity));
            });
            OnPropertyChanged(nameof(Entities));
            _windowService.CloseWindow();
        }

        public void RemoveEntityFromList(EntityListingElementViewModel<T> entityListingElementViewModel)
        {
            App.Current?.Dispatcher.Invoke(() =>
            {
                Entities.Remove(entityListingElementViewModel);
            });
            OnPropertyChanged(nameof(Entities));
        }
        public void AddToChecked(T entity)
        {
            _checkedEntities.Add(entity);
        }
        public void RemoveToChecked(T entity)
        {
            _checkedEntities.Remove(entity);
        }
        public void RemoveSelectedEntitiesFromList()
        {
            App.Current?.Dispatcher.Invoke(() =>
            {
                foreach (var entity in _checkedEntities)
                {
                    Entities.Remove(Entities.First(e => e.Id == entity.Id));
                }
                _checkedEntities.Clear();
                CheckedEntitiesNumber = 0;
                OnPropertyChanged(nameof(Entities));
            });
        }
    }
}
