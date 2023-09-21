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
    public class IsCheckedChangedEventArgs : EventArgs
    {
        public bool IsChecked { get; set; }
    }
    public delegate void IsCheckedChangedEventHandler(object sender, IsCheckedChangedEventArgs e);
    public class ContinentViewModel : ViewModelBase
    {
        private readonly Continent _continent;
        //private readonly AddCountryViewModel _addCountryViewModel;
        private bool _isChecked;

        public string Name => _continent.Name;

        public event IsCheckedChangedEventHandler? IsCheckedChanged;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));

                OnIsCheckedChanged();
            }
        }

        public ContinentViewModel(Continent continent)
        {
            _continent = continent;
            _isChecked = false;
        }

        public override string ToString()
        {
            return Name;
        }

        private void OnIsCheckedChanged()
        {
            IsCheckedChanged?.Invoke(_continent, new IsCheckedChangedEventArgs { IsChecked = IsChecked });
        }
    }
}
