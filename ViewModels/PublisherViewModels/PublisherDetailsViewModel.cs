using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.CountryViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.PublisherViewModels
{
    public class PublisherDetailsViewModel : EntityDetailsViewModel<Publisher>
    {
        private readonly IDataService<Country> _countryService;
        private readonly ObservableCollection<CountryViewModel> _allCountries;
        private CountryViewModel? _selectedCountry;
        private bool _isFoundationDate;

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
        public ObservableCollection<CountryViewModel> AllCountries => _allCountries;
        public CountryViewModel? SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
                if(value != null)
                {
                    SetCountry(value.Id);
                }
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }
        public bool IsFoundationDate
        {
            get { return _isFoundationDate; }
            set
            {
                _isFoundationDate = value;
                OnPropertyChanged(nameof(IsFoundationDate));
            }
        }

        private PublisherDetailsViewModel(IDataService<Publisher> publisherService, IDataService<Country> countryService, EntityListingViewModel<Publisher> entityListingViewModel) : base(publisherService, entityListingViewModel)
        {
            _countryService = countryService;
            _allCountries = new ObservableCollection<CountryViewModel>();
            _isFoundationDate = false;
        }
        private PublisherDetailsViewModel(IDataService<Publisher> publisherService, IDataService<Country> countryService, EntityListingElementViewModel<Publisher> entityListingElementViewModel, Publisher entity) : base(publisherService, entityListingElementViewModel, entity)
        {
            _countryService = countryService;
            _allCountries = new ObservableCollection<CountryViewModel>();
            _isFoundationDate = entity.FoundationDate != null;

            //SelectedCountry = _allCountries.First(c => c.Id == entity.CountryId);
        }

        public static PublisherDetailsViewModel GetPublisherDetailsViewModel(IDataService<Publisher> publisherService, IDataService<Country> countryService, EntityListingViewModel<Publisher> entityListingViewModel)
        {
            PublisherDetailsViewModel publisherDetailsViewModel = new PublisherDetailsViewModel(publisherService, countryService, entityListingViewModel);
            publisherDetailsViewModel.LoadCountries();
            return publisherDetailsViewModel;
        }
        public static PublisherDetailsViewModel GetPublisherDetailsViewModel(IDataService<Publisher> publisherService, IDataService<Country> countryService, EntityListingElementViewModel<Publisher> entityListingElementViewModel, Publisher entity)
        {
            PublisherDetailsViewModel publisherDetailsViewModel = new PublisherDetailsViewModel(publisherService, countryService, entityListingElementViewModel, entity);
            publisherDetailsViewModel.LoadCountries();
            return publisherDetailsViewModel;
        }

        private void LoadCountries()
        {
            _countryService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    foreach (Country country in task.Result)
                    {
                        CountryViewModel countryViewModel = new CountryViewModel(country);
                        _allCountries.Add(countryViewModel);

                        if(Mode == EntityDetailsMode.Update)
                        {
                            if(_entity.Country.Id == country.Id)
                            {
                                SelectedCountry = countryViewModel;
                            }
                        }
                    }
                }
            });
        }

        public void SetCountry(int id)
        {
            _countryService.Get(id).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    _entity.Country = task.Result;
                }
            });
        }
    }
}
