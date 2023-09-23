using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bookshelf.Commands
{
    public enum DeleteEntityMode
    {
        Single, Many
    }
    public class DeleteEntityCommand<T> : CommandBase where T : DomainObject, new()
    {
        private readonly DeleteEntityMode _mode;
        private readonly IDataService<T> _dataService;
        private readonly T? _entity;
        private readonly ICollection<T>? _entities;

        private readonly EntityListingElementViewModel<T>? _entityListingElementViewModel;
        private readonly EntityListingViewModel<T>? _entityListingViewModel;

        public DeleteEntityCommand(IDataService<T> dataService, T entity, EntityListingElementViewModel<T> entityListingElementViewModel)
        {
            _mode = DeleteEntityMode.Single;
            _dataService = dataService;
            _entity = entity;
            _entityListingElementViewModel = entityListingElementViewModel;
        }
        public DeleteEntityCommand(IDataService<T> dataService, ICollection<T> entities, EntityListingViewModel<T> entityListingViewModel)
        {
            _mode = DeleteEntityMode.Many;
            _dataService = dataService;
            _entities = entities;
            _entityListingViewModel = entityListingViewModel;

            _entityListingViewModel.PropertyChanged += _entityListingViewModelPropertyChanged;
        }

        private void _entityListingViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_entityListingViewModel.CheckedEntitiesNumber))
            {
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if(_mode == DeleteEntityMode.Many)
            {
                return _entities?.Count > 0;
            }
            return true;
        }
        public override void Execute(object? parameter)
        {
            switch (_mode)
            {
                case DeleteEntityMode.Single:
                    if(_entity != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if(result == MessageBoxResult.Yes)
                        {
                            _dataService.Delete(_entity.Id);
                            _entityListingElementViewModel?.RemoveFromParent();
                        }   
                    }
                    break;
                case DeleteEntityMode.Many:
                    if(_entities != null)
                    {
                        MessageBoxResult result = MessageBox.Show($"Are you sure to delete {_entities.Count} entities?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if(result == MessageBoxResult.Yes)
                        {
                            foreach(var entity in _entities)
                            {
                                _dataService.Delete(entity.Id);
                            }
                            _entityListingViewModel?.RemoveSelectedEntitiesFromList();
                        }
                    }
                    break;
                default:
                    //todo
                    break;
            }
        }
    }
}
