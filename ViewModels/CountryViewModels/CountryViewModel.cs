using Bookshelf.Models;
using Bookshelf.ViewModels.ContinentViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.CountryViewModels
{
    public class CountryViewModel : ViewModelBase
    {
        private readonly Country _country;
        private readonly ObservableCollection<ContinentViewModel> _continents;
        //private bool _isChecked;
        
        public string Name => _country.Name;
        public int Id => _country.Id;
        public ObservableCollection<ContinentViewModel> Continents => _continents;

        //public event IsCheckedChangedEventHandler? IsCheckedChanged;
        //public bool IsChecked
        //{
        //    get { return _isChecked; }
        //    set
        //    {
        //        _isChecked = value;
        //        OnPropertyChanged(nameof(IsChecked));
        //        OnIsCheckedChanged();
        //    }
        //}

        public CountryViewModel(Country country)
        {
            _country = country;
            _continents = new ObservableCollection<ContinentViewModel>();
            foreach(var continent in _country.Continents)
            {
                _continents.Add(new ContinentViewModel(continent));
            }
            //_isChecked = false;
        }

        public override string ToString()
        {
            return Name;
        }
        //private void OnIsCheckedChanged()
        //{
        //    IsCheckedChanged?.Invoke(_country, new IsCheckedChangedEventArgs { IsChecked = IsChecked });
        //}
    }
}
