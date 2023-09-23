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
    public class CountryListingElementViewModelFactory : IEntityListingElementViewModelFactory<Country>
    {
        private readonly IWindowService<EntityDetailsWindow> _windowService;
        private readonly IDataService<Country> _dataService;
        private readonly IEntityDetailsViewModelFactory<Country> _entityDetailsViewModelFactory;

        public CountryListingElementViewModelFactory(IDataService<Country> dataService, IWindowService<EntityDetailsWindow> windowService, IEntityDetailsViewModelFactory<Country> entityDetailsViewModelFactory)
        {
            _dataService = dataService;
            _windowService = windowService;
            _entityDetailsViewModelFactory = entityDetailsViewModelFactory;
        }

        public EntityListingElementViewModel<Country> CreateViewModel(EntityListingViewModel<Country> entityListingViewModel, Country entity)
        {
            return new CountryListingElementViewModel(entityListingViewModel, _dataService, _windowService, entity, _entityDetailsViewModelFactory);
        }
    }
}
