using Bookshelf.Models;
using Bookshelf.ViewModels.CountryViewModels;
using Bookshelf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.ContinentViewModels
{
    public class AddCountryContinentViewModel : ViewModelBase
    {
        private readonly Continent _continent;
        private readonly AddCountryViewModel _addCountryViewModel;
        private bool _isSelected;

        public string Name => _continent.Name;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                if(value == true)
                {
                    _addCountryViewModel.AddToSelected(_continent);
                }
                else
                {
                    _addCountryViewModel.RemoveFromSelected(_continent);
                }
                OnPropertyChanged(nameof(IsSelected));
            }
        }


        public AddCountryContinentViewModel(Continent continent, AddCountryViewModel addCountryViewModel)
        {
            _continent = continent;
            _isSelected = false;
            _addCountryViewModel = addCountryViewModel;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
