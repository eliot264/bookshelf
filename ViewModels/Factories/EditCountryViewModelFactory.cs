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
    public class EditCountryViewModelFactory : IEditEntityViewModelFactory<Country>
    {
        private readonly IDataService<Country> _dataService;
        private readonly IDataService<Continent> _continentService;

        public EditCountryViewModelFactory(IDataService<Country> dataService, IDataService<Continent> continentService)
        {
            _dataService = dataService;
            _continentService = continentService;
        }

        public EditEntityViewModel<Country> CreateEditEntityViewModel(EntityListingElementViewModel<Country> entityListingElementViewModel, Country entity)
        {
            return new EditCountryViewModel(entityListingElementViewModel, _dataService, _continentService, entity);
        }
    }
}
