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
        private readonly IWindowService<EditObjectWindow> _windowService;
        private readonly IEditEntityViewModelFactory<T> _editEntityViewModelFactory;
        protected T _entity;
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public ICommand OpenEditEntityWindowCommand { get; set; }

        protected event EntityChangedEventHandler? EntityChanged;

        public EntityListingElementViewModel(EntityListingViewModel<T> entityListingViewModel, IWindowService<EditObjectWindow> windowService, IEditEntityViewModelFactory<T> editEntityViewModelFactory, T entity)
        {
            _entityListingViewModel = entityListingViewModel;
            _windowService = windowService;
            _editEntityViewModelFactory = editEntityViewModelFactory;
            _entity = entity;
            _isChecked = false;

            OpenEditEntityWindowCommand = new OpenEditEntityWindowCommand<T>(this, _windowService, _editEntityViewModelFactory, _entity);
        }

        public void UpdateEntity(T entity)
        {
            _entity = entity;
            OnEntityChanged();
            _windowService.CloseWindow();
            //OnPropertyChanged(string.Empty); // refresh all properties
        }

        private void OnEntityChanged()
        {
            EntityChanged?.Invoke();
        }
    }
}
