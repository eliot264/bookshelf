using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.PublisherViewModels;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories.PublisherFactories
{
    public class PublisherListingViewModelFactory : IBookshelfViewModelFactory<PublisherListingViewModel>
    {
        private readonly IDataService<Publisher> _dataService;
        private readonly IWindowService<EntityDetailsWindow> _windowService;
        private readonly IEntityDetailsViewModelFactory<Publisher> _entityDetailsViewModelFactory;
        private readonly IEntityListingElementViewModelFactory<Publisher> _entityListingElementViewModelFactory;

        public PublisherListingViewModelFactory(IDataService<Publisher> dataService, IWindowService<EntityDetailsWindow> windowService, IEntityDetailsViewModelFactory<Publisher> entityDetailsViewModelFactory, IEntityListingElementViewModelFactory<Publisher> entityListingElementViewModelFactory)
        {
            _dataService = dataService;
            _windowService = windowService;
            _entityDetailsViewModelFactory = entityDetailsViewModelFactory;
            _entityListingElementViewModelFactory = entityListingElementViewModelFactory;
        }

        public PublisherListingViewModel CreateViewModel()
        {
            return PublisherListingViewModel.GetPublisherListingViewModel(_dataService, _windowService, _entityListingElementViewModelFactory, _entityDetailsViewModelFactory);
        }
    }
}
