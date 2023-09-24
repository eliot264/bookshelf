using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.Factories;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.PublisherViewModels
{
    public class PublisherListingViewModel : EntityListingViewModel<Publisher>
    {
        private PublisherListingViewModel(IDataService<Publisher> dataService, IWindowService<EntityDetailsWindow> windowService, IEntityListingElementViewModelFactory<Publisher> entityListingElementViewModelFactory, IEntityDetailsViewModelFactory<Publisher> entityDetailsViewModelFactory) : base(dataService, windowService, entityListingElementViewModelFactory, entityDetailsViewModelFactory)
        {
        }

        public static PublisherListingViewModel GetPublisherListingViewModel(IDataService<Publisher> dataService, IWindowService<EntityDetailsWindow> windowService, IEntityListingElementViewModelFactory<Publisher> entityListingElementViewModelFactory, IEntityDetailsViewModelFactory<Publisher> entityDetailsViewModelFactory)
        {
            PublisherListingViewModel publisherListingViewModel = new PublisherListingViewModel(dataService, windowService, entityListingElementViewModelFactory, entityDetailsViewModelFactory);
            publisherListingViewModel.LoadEntities();
            return publisherListingViewModel;
        }
    }
}
