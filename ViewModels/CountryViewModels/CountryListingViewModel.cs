using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.Factories;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.CountryViewModels
{
    public class CountryListingViewModel : EntityListingViewModel<Country>
    {
        private CountryListingViewModel(IDataService<Country> dataService, IWindowService<AddObjectWindow> windowService, IAddEntityViewModelFactory<Country> addEntityViewModelFactory, IEntityListingElementViewModelFactory<Country> entityListingElementViewModelFactory) : base(dataService, windowService, addEntityViewModelFactory, entityListingElementViewModelFactory)
        {
        }

        public static CountryListingViewModel GetCountryListingViewModel(IDataService<Country> dataService, IWindowService<AddObjectWindow> windowService, IAddEntityViewModelFactory<Country> addEntityViewModelFactory, IEntityListingElementViewModelFactory<Country> entityListingElementViewModelFactory)
        {
            CountryListingViewModel countryListingViewModel = new CountryListingViewModel(dataService, windowService, addEntityViewModelFactory, entityListingElementViewModelFactory);
            countryListingViewModel.LoadEntities();
            return countryListingViewModel;
        }
    }
}
