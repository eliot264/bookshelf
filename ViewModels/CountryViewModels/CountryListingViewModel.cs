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
        private CountryListingViewModel(IDataService<Country> dataService, IWindowService<EntityDetailsWindow> windowService, IEntityListingElementViewModelFactory<Country> entityListingElementViewModelFactory, IEntityDetailsViewModelFactory<Country> entityDetailsViewModelFactory) : base(dataService, windowService, entityListingElementViewModelFactory, entityDetailsViewModelFactory)
        {
        }

        public static CountryListingViewModel GetCountryListingViewModel(IDataService<Country> dataService, IWindowService<EntityDetailsWindow> windowService, IEntityListingElementViewModelFactory<Country> entityListingElementViewModelFactory, IEntityDetailsViewModelFactory<Country> entityDetailsViewModelFactory)
        {
            CountryListingViewModel countryListingViewModel = new CountryListingViewModel(dataService, windowService, entityListingElementViewModelFactory, entityDetailsViewModelFactory);
            countryListingViewModel.LoadEntities();
            return countryListingViewModel;
        }
    }
}
