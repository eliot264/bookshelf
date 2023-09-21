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
    public class EditCountryViewModel : EditEntityViewModel<Country>
    {
        private readonly IDataService<Continent> _continentService;
        private readonly ObservableCollection<ContinentViewModel> _allContinents;
        //private readonly IList<Continent> _allContinents;

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

        public EditCountryViewModel(EntityListingElementViewModel<Country> entityListingElementViewModel, IDataService<Country> dataService, IDataService<Continent> continentService, Country entity) : base(entityListingElementViewModel, dataService, entity)
        {
            _continentService = continentService;
            _allContinents = new ObservableCollection<ContinentViewModel>();

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
                        ContinentViewModel continentViewModel = new ContinentViewModel(continent)
                        {
                            IsChecked = _entity.Continents.Where(e => e.Id == continent.Id).Any(),
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
            int id = ((Continent)sender).Id;

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
