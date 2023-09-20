using Bookshelf.DbContexts;
using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.ContinentViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.CountryViewModels
{
    public class AddCountryViewModel : AddEntityViewModel<Country>
    {
        private readonly IDataService<Continent> _continentService;
        private readonly IList<Continent> _allContinents;
        public string Name
        {
            get { return _entity.Name; }
            set
            {
                _entity.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ObservableCollection<AddCountryContinentViewModel> AllContinents => new ObservableCollection<AddCountryContinentViewModel>(_allContinents.Select(continent => new AddCountryContinentViewModel(continent, this)));

        public ICollection<Continent> SelectedContinents
        {
            get { return _entity.Continents; }
            set
            {
                _entity.Continents = value;
                OnPropertyChanged(nameof(SelectedContinents));
            }
        }
        public AddCountryViewModel(CountryListingViewModel countryListingViewModel, IDataService<Country> dataService, IDataService<Continent> continentService) : base(countryListingViewModel, dataService)
        {
            _continentService = continentService;
            _allContinents = new List<Continent>();

            LoadContinents();
        }

        private void LoadContinents()
        {
            _continentService.GetAll().ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    foreach (Continent continent in task.Result)
                    {
                        _allContinents.Add(continent);
                    }
                }
            });
            
        }

        public void AddToSelected(Continent continent)
        {
            SelectedContinents.Add(continent);
            OnPropertyChanged(nameof(SelectedContinents));
        }

        public void RemoveFromSelected(Continent continent)
        {
            SelectedContinents.Remove(continent);
            OnPropertyChanged(nameof(SelectedContinents));
        }
    }
}
