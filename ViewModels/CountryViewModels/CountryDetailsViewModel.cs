using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.ContinentViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.CountryViewModels
{
    public class CountryDetailsViewModel : EntityDetailsViewModel<Country>
    {
        private readonly IDataService<Continent> _continentService;
        private readonly ObservableCollection<ContinentViewModel> _allContinents;

        public string Name
        {
            get { return _entity.Name; }
            set
            {
                _entity.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ObservableCollection<ContinentViewModel> AllContinents => _allContinents;

        private CountryDetailsViewModel(IDataService<Country> countryService, IDataService<Continent> continentService, EntityListingViewModel<Country> entityListingViewModel) : base(countryService, entityListingViewModel)
        {
            _continentService = continentService;
            _allContinents = new ObservableCollection<ContinentViewModel>();
        }

        private CountryDetailsViewModel(IDataService<Country> countryService, IDataService<Continent> continentService, EntityListingElementViewModel<Country> entityListingElementViewModel, Country entity) : base(countryService, entityListingElementViewModel, entity)
        {
            _continentService = continentService;
            _allContinents = new ObservableCollection<ContinentViewModel>();
        }

        public static CountryDetailsViewModel GetCountryDetailsViewModel(IDataService<Country> countryService, IDataService<Continent> continentService, EntityListingViewModel<Country> entityListingViewModel)
        {
            CountryDetailsViewModel countryDetailsViewModel = new CountryDetailsViewModel(countryService, continentService, entityListingViewModel);
            countryDetailsViewModel.LoadContinents();
            return countryDetailsViewModel;
        }

        public static CountryDetailsViewModel GetCountryDetailsViewModel(IDataService<Country> countryService, IDataService<Continent> continentService, EntityListingElementViewModel<Country> entityListingElementViewModel, Country entity)
        {
            CountryDetailsViewModel countryDetailsViewModel = new CountryDetailsViewModel(countryService, continentService, entityListingElementViewModel, entity);
            countryDetailsViewModel.LoadContinents();
            return countryDetailsViewModel;
        }

        private void LoadContinents()
        {
            _continentService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    foreach (Continent continent in task.Result)
                    {
                        ContinentViewModel continentViewModel = new ContinentViewModel(continent)
                        {
                            IsChecked = Mode == EntityDetailsMode.Update && _entity.Continents.Where(e => e.Id == continent.Id).Any()
                        };

                        continentViewModel.IsCheckedChanged += ContinentViewModelIsCheckedChanged;
                        _allContinents.Add(continentViewModel);
                    }
                }
            });
        }

        private void ContinentViewModelIsCheckedChanged(object sender, IsCheckedChangedEventArgs e)
        {
            Continent continent = (Continent)sender;
            int id = continent.Id;

            if (e.IsChecked == true)
            {
                _entity.Continents.Add(continent);
            }
            else
            {
                _entity.Continents.Remove(_entity.Continents.First(c => c.Id == id));
            }
        }
    }
}
