using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels.ContinentViewModels;
using Bookshelf.ViewModels.Factories;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.CountryViewModels
{
    public class CountryListingElementViewModel : EntityListingElementViewModel<Country>
    {
        private ObservableCollection<ContinentViewModel> _continents;

        public string Name
        {
            get { return _entity.Name; }
            set
            {
                _entity.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public ObservableCollection<ContinentViewModel> Continents
        {
            get { return _continents; }
            set
            {
                _continents = value;
                OnPropertyChanged(nameof(Continents));
            }
        }
        public CountryListingElementViewModel(EntityListingViewModel<Country> entityListingViewModel, IWindowService<EditObjectWindow> windowService, IEditEntityViewModelFactory<Country> editEntityViewModelFactory, Country entity) : base(entityListingViewModel, windowService, editEntityViewModelFactory, entity)
        {
            _continents = new ObservableCollection<ContinentViewModel>();
            LoadContinents(entity.Continents);

            base.EntityChanged += CountryListingElementViewModelEntityChanged;
        }

        private void CountryListingElementViewModelEntityChanged()
        {
            OnPropertyChanged(nameof(Name));
            _continents.Clear();
            LoadContinents(_entity.Continents);
        }

        private void LoadContinents(ICollection<Continent> continents)
        {
            foreach(Continent continent in continents)
            {
                Continents.Add(new ContinentViewModel(continent));
            }
            OnPropertyChanged(nameof(Continents));
        }
    }
}
