using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.PublisherViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories.PublisherFactories
{
    public class PublisherDetailsViewModelFactory : IEntityDetailsViewModelFactory<Publisher>
    {
        private readonly IDataService<Publisher> _publisherService;
        private readonly IDataService<Country> _countryService;

        public PublisherDetailsViewModelFactory(IDataService<Publisher> publisherService, IDataService<Country> countryService)
        {
            _publisherService = publisherService;
            _countryService = countryService;
        }

        public EntityDetailsViewModel<Publisher> CreateViewModel(EntityListingElementViewModel<Publisher> entityListingElementViewModel, Publisher entity)
        {
            return PublisherDetailsViewModel.GetPublisherDetailsViewModel(_publisherService, _countryService, entityListingElementViewModel, entity);
        }

        public EntityDetailsViewModel<Publisher> CreateViewModel(EntityListingViewModel<Publisher> entityListingViewModel)
        {
            return PublisherDetailsViewModel.GetPublisherDetailsViewModel(_publisherService, _countryService, entityListingViewModel);
        }
    }
}
