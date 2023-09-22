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

        public ObservableCollection<EntityListingElementViewModel<T>> Entities => _entities;

        public ICommand OpenAddEntityWindowCommand { get; set; }

        protected EntityListingViewModel(IDataService<T> dataService, IWindowService<EntityDetailsWindow> windowService, IEntityListingElementViewModelFactory<T> entityListingElementViewModelFactory, IEntityDetailsViewModelFactory<T> entityDetailsViewModelFactory)
        {
            _entityListingElementViewModelFactory = entityListingElementViewModelFactory;
            _entityDetailsViewModelFactory = entityDetailsViewModelFactory;
            _dataService = dataService;
            _windowService = windowService;
            _entities = new ObservableCollection<EntityListingElementViewModel<T>>();

            OpenAddEntityWindowCommand = new OpenEntityDetailsWindowCommand<T>(this, _windowService, _entityDetailsViewModelFactory);
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
    }
}
