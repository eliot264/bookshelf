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
        private readonly IEntityDetailsViewModelFactory<Country> _entityDetailsViewModelFactory;

        public CountryListingElementViewModelFactory(IWindowService<EntityDetailsWindow> windowService, IEntityDetailsViewModelFactory<Country> entityDetailsViewModelFactory)
        {
            _windowService = windowService;
            _entityDetailsViewModelFactory = entityDetailsViewModelFactory;
        }

        public EntityListingElementViewModel<Country> CreateViewModel(EntityListingViewModel<Country> entityListingViewModel, Country entity)
        {
            return new CountryListingElementViewModel(entityListingViewModel, _windowService, entity, _entityDetailsViewModelFactory);
        }
    }
}
