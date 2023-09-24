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
    public class PublisherListingElementViewModelFactory : IEntityListingElementViewModelFactory<Publisher>
    {
        private readonly IWindowService<EntityDetailsWindow> _windowService;
        private readonly IDataService<Publisher> _dataService;
        private readonly IEntityDetailsViewModelFactory<Publisher> _entityDetailsViewModelFactory;

        public PublisherListingElementViewModelFactory(IWindowService<EntityDetailsWindow> windowService, IDataService<Publisher> dataService, IEntityDetailsViewModelFactory<Publisher> entityDetailsViewModelFactory)
        {
            _windowService = windowService;
            _dataService = dataService;
            _entityDetailsViewModelFactory = entityDetailsViewModelFactory;
        }

        public EntityListingElementViewModel<Publisher> CreateViewModel(EntityListingViewModel<Publisher> entityListingViewModel, Publisher entity)
        {
            return new PublisherListingElementViewModel(entityListingViewModel, _dataService, _windowService, entity, _entityDetailsViewModelFactory);
        }
    }
}
