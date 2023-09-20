using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.CountryViewModels;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories
{
    public class CountryListingViewModelFactory : IBookshelfViewModelFactory<CountryListingViewModel>
    {
        private readonly IDataService<Country> _dataService;
        private readonly IWindowService<AddObjectWindow> _windowService;
        private readonly IAddEntityViewModelFactory<Country> _addEntityViewModelFactory;
        private readonly IEntityListingElementViewModelFactory<Country> _entityListingElementViewModelFactory;

        public CountryListingViewModelFactory(IDataService<Country> dataService, IWindowService<AddObjectWindow> windowService, IAddEntityViewModelFactory<Country> addEntityViewModelFactory, IEntityListingElementViewModelFactory<Country> entityListingElementViewModelFactory)
        {
            _dataService = dataService;
            _windowService = windowService;
            _addEntityViewModelFactory = addEntityViewModelFactory;
            _entityListingElementViewModelFactory = entityListingElementViewModelFactory;
        }

        public CountryListingViewModel CreateViewModel()
        {
            return CountryListingViewModel.GetCountryListingViewModel(_dataService, _windowService, _addEntityViewModelFactory, _entityListingElementViewModelFactory);
        }
    }
}
