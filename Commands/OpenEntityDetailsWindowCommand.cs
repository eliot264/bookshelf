using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels;
using Bookshelf.ViewModels.Factories;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Commands
{
    public class OpenEntityDetailsWindowCommand<T> : CommandBase where T : DomainObject, new()
    {
        private readonly EntityDetailsMode _mode;

        private readonly IWindowService<EntityDetailsWindow> _windowService;
        private readonly IEntityDetailsViewModelFactory<T> _entityDetailsViewModelFactory;

        private readonly EntityListingViewModel<T>? _entityListingViewModel;
        private readonly EntityListingElementViewModel<T>? _entityListingElementViewModel;

        private readonly T? _entity;

        public OpenEntityDetailsWindowCommand(EntityListingViewModel<T> entityListingViewModel, IWindowService<EntityDetailsWindow> windowService, IEntityDetailsViewModelFactory<T> entityDetailsViewModelFactory)
        {
            _mode = EntityDetailsMode.Add;
            _entityListingViewModel = entityListingViewModel;
            _windowService = windowService;
            _entityDetailsViewModelFactory = entityDetailsViewModelFactory;
        }
        public OpenEntityDetailsWindowCommand(T entity, EntityListingElementViewModel<T> entityListingElementViewModel, IWindowService<EntityDetailsWindow> windowService, IEntityDetailsViewModelFactory<T> entityDetailsViewModelFactory)
        {
            _mode = EntityDetailsMode.Update;
            _entityListingElementViewModel = entityListingElementViewModel;
            _windowService = windowService;
            _entityDetailsViewModelFactory = entityDetailsViewModelFactory;
            _entity = entity;
        }
        public override void Execute(object? parameter)
        {
            switch (_mode)
            {
                case EntityDetailsMode.Add:
                    if(_entityListingViewModel != null)
                    {
                        _windowService.ShowDialogWindow(_entityDetailsViewModelFactory.CreateViewModel(_entityListingViewModel));
                    }
                    break;
                case EntityDetailsMode.Update:
                    if(_entityListingElementViewModel != null && _entity != null)
                    {
                        _windowService.ShowDialogWindow(_entityDetailsViewModelFactory.CreateViewModel(_entityListingElementViewModel, _entity));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
