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
        private readonly IWindowService<EditObjectWindow> _windowService;
        private readonly IEditEntityViewModelFactory<Country> _editEntityViewModelFactory;

        public CountryListingElementViewModelFactory(IWindowService<EditObjectWindow> windowService, IEditEntityViewModelFactory<Country> editEntityViewModelFactory)
        {
            _windowService = windowService;
            _editEntityViewModelFactory = editEntityViewModelFactory;
        }

        public EntityListingElementViewModel<Country> CreateViewModel(EntityListingViewModel<Country> entityListingViewModel, Country entity)
        {
            return new CountryListingElementViewModel(entityListingViewModel,_windowService, _editEntityViewModelFactory, entity);
        }
    }
}
