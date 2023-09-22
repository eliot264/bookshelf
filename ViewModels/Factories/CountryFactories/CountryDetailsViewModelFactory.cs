using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.CountryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories.CountryFactories
{
    public class CountryDetailsViewModelFactory : IEntityDetailsViewModelFactory<Country>
    {
        private readonly IDataService<Country> _countryService;
        private readonly IDataService<Continent> _continentService;
        public CountryDetailsViewModelFactory(IDataService<Country> countryService, IDataService<Continent> continentService)
        {
            _countryService = countryService;
            _continentService = continentService;
        }
        public EntityDetailsViewModel<Country> CreateViewModel(EntityListingElementViewModel<Country> entityListingElementViewModel, Country entity)
        {
            return CountryDetailsViewModel.GetCountryDetailsViewModel(_countryService, _continentService, entityListingElementViewModel, entity);
        }

        public EntityDetailsViewModel<Country> CreateViewModel(EntityListingViewModel<Country> entityListingViewModel)
        {
            return CountryDetailsViewModel.GetCountryDetailsViewModel(_countryService, _continentService, entityListingViewModel);
        }
    }
}
