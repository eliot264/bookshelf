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
        private readonly IWindowService<AddObjectWindow> _windowService;
        public readonly IAddEntityViewModelFactory<T> _addEntityViewModelFactory;
        public readonly IEntityListingElementViewModelFactory<T> _entityListingElementViewModelFactory;
        private readonly ObservableCollection<EntityListingElementViewModel<T>> _entities;

        public ObservableCollection<EntityListingElementViewModel<T>> Entities => _entities;

        public ICommand OpenAddEntityWindowCommand { get; set; }

        protected EntityListingViewModel(IDataService<T> dataService, IWindowService<AddObjectWindow> windowService, IAddEntityViewModelFactory<T> addEntityViewModelFactory, IEntityListingElementViewModelFactory<T> entityListingElementViewModelFactory)
        {
            _addEntityViewModelFactory = addEntityViewModelFactory;
            _entityListingElementViewModelFactory = entityListingElementViewModelFactory;
            _dataService = dataService;
            _windowService = windowService;
            _entities = new ObservableCollection<EntityListingElementViewModel<T>>();

            OpenAddEntityWindowCommand = new OpenAddEntityWindowCommand<T>(this, _dataService, _windowService, _addEntityViewModelFactory);
        }
        
        protected void LoadEntities()
        {
            _dataService.GetAll().ContinueWith(task =>
            {
                if(task.Exception == null)
                {
                    foreach(var entity in task.Result)
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

        public void UpdateEntityOnList(T entity)
        {
            //App.Current.Dispatcher.Invoke(() =>
            //{
            //    Entities.First(e => e.Id == entity.Id)
            //});
        }
    }
}
