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
    public class OpenAddEntityWindowCommand<T> : CommandBase where T: DomainObject, new()
    {
        private readonly EntityListingViewModel<T> _entityListingViewModel;
        private readonly IDataService<T> _dataService;
        private readonly IWindowService<AddObjectWindow> _windowService;
        private readonly IAddEntityViewModelFactory<T> _addEntityViewModelFactory;

        public OpenAddEntityWindowCommand(EntityListingViewModel<T> entityListingViewModel, IDataService<T> dataService, IWindowService<AddObjectWindow> windowService, IAddEntityViewModelFactory<T> addEntityViewModelFactory)
        {
            _entityListingViewModel = entityListingViewModel;
            _dataService = dataService;
            _windowService = windowService;
            _addEntityViewModelFactory = addEntityViewModelFactory;
        }

        public override void Execute(object? parameter)
        {
            _windowService.ShowDialogWindow(_addEntityViewModelFactory.CreateAddEntityViewModel(_entityListingViewModel));
        }
    }
}
