using Bookshelf.Commands;
using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.Factories;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookshelf.ViewModels
{
    public delegate void EntityChangedEventHandler();
    public class EntityListingElementViewModel<T> : ViewModelBase where T : DomainObject, new()
    {
        private readonly EntityListingViewModel<T> _entityListingViewModel;
        private readonly IDataService<T> _dataService;
        private readonly IWindowService<EntityDetailsWindow> _windowService;
        private readonly IEntityDetailsViewModelFactory<T> _entityDetailsViewModelFactory;
        protected T _entity;
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));

                if(value == true)
                {
                    _entityListingViewModel.AddToChecked(_entity);
                    _entityListingViewModel.CheckedEntitiesNumber++;
                }
                else
                {
                    _entityListingViewModel.RemoveToChecked(_entity);
                    _entityListingViewModel.CheckedEntitiesNumber--;
                }
            }
        }
        public int Id => _entity.Id;
        public ICommand OpenEditEntityWindowCommand { get; set; }
        public ICommand DeleteEntityCommand { get; set; }

        protected event EntityChangedEventHandler? EntityChanged;

        public EntityListingElementViewModel(EntityListingViewModel<T> entityListingViewModel, IDataService<T> dataService, IWindowService<EntityDetailsWindow> windowService, T entity, IEntityDetailsViewModelFactory<T> entityDetailsViewModelFactory)
        {
            _entityListingViewModel = entityListingViewModel;
            _dataService = dataService;
            _windowService = windowService;
            _entityDetailsViewModelFactory = entityDetailsViewModelFactory;
            _entity = entity;
            _isChecked = false;

            OpenEditEntityWindowCommand = new OpenEntityDetailsWindowCommand<T>(_entity, this, _windowService, _entityDetailsViewModelFactory);
            DeleteEntityCommand = new DeleteEntityCommand<T>(_dataService, _entity, this);
        }

        public void UpdateEntity(T entity)
        {
            _entity = entity;
            OnEntityChanged();
            _windowService.CloseWindow();
            //OnPropertyChanged(string.Empty); // refresh all properties
        }

        public void RemoveFromParent()
        {
            _entityListingViewModel.RemoveEntityFromList(this);
        }

        private void OnEntityChanged()
        {
            EntityChanged?.Invoke();
        }
    }
}
