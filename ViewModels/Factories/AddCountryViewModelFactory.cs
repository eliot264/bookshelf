using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.CountryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories
{
    public class AddCountryViewModelFactory : IAddEntityViewModelFactory<Country>
    {
        private readonly IDataService<Country> _dataService;
        private readonly IDataService<Continent> _continentService;

        public AddCountryViewModelFactory(IDataService<Country> dataService, IDataService<Continent> continentService)
        {
            _dataService = dataService;
            _continentService = continentService;
        }

        public AddEntityViewModel<Country> CreateAddEntityViewModel(EntityListingViewModel<Country> entityListingViewModel)
        {
            return new AddCountryViewModel((CountryListingViewModel)entityListingViewModel, _dataService, _continentService);
        }
    }
}
