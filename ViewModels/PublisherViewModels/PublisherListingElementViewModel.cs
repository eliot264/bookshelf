using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.CountryViewModels;
using Bookshelf.ViewModels.Factories;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.PublisherViewModels
{
    public class PublisherListingElementViewModel : EntityListingElementViewModel<Publisher>
    {
        private CountryViewModel _country;

        public string Name
        {
            get { return _entity.Name; }
            set
            {
                _entity.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public DateOnly? FoundationDate
        {
            get { return _entity.FoundationDate; }
            set
            {
                _entity.FoundationDate = value;
                OnPropertyChanged(nameof(FoundationDate));
            }
        }
        public CountryViewModel Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        public PublisherListingElementViewModel(EntityListingViewModel<Publisher> entityListingViewModel, IDataService<Publisher> dataService, IWindowService<EntityDetailsWindow> windowService, Publisher entity, IEntityDetailsViewModelFactory<Publisher> entityDetailsViewModelFactory) : base(entityListingViewModel, dataService, windowService, entity, entityDetailsViewModelFactory)
        {
            _country = new CountryViewModel(_entity.Country);
        }
    }
}
