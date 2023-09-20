using Bookshelf.Models;
using Bookshelf.ViewModels.CountryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories
{
    public class CountryListingElementViewModelFactory : IEntityListingElementViewModelFactory<Country>
    {
        public EntityListingElementViewModel<Country> CreateViewModel(EntityListingViewModel<Country> entityListingViewModel, Country entity)
        {
            return new CountryListingElementViewModel(entityListingViewModel, entity);
        }
    }
}
