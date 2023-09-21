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
    public class OpenEditEntityWindowCommand<T> : CommandBase where T : DomainObject, new()
    {
        private readonly EntityListingElementViewModel<T> _entityListingElementViewModel;
        private readonly IWindowService<EditObjectWindow> _windowService;
        private readonly IEditEntityViewModelFactory<T> _editEntityViewModelFactory;
        private readonly T _entity;

        public OpenEditEntityWindowCommand(EntityListingElementViewModel<T> entityListingElementViewModel, IWindowService<EditObjectWindow> windowService, IEditEntityViewModelFactory<T> editEntityViewModelFactory, T entity)
        {
            _entityListingElementViewModel = entityListingElementViewModel;
            _windowService = windowService;
            _editEntityViewModelFactory = editEntityViewModelFactory;
            _entity = entity;
        }

        public override void Execute(object? parameter)
        {
            _windowService.ShowDialogWindow(_editEntityViewModelFactory.CreateEditEntityViewModel(_entityListingElementViewModel, _entity));
        }
    }
}
