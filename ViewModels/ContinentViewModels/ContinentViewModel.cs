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
    public class ContinentViewModel : ViewModelBase
    {
        private readonly Continent _continent;
        private readonly AddCountryViewModel _addCountryViewModel;

        public string Name => _continent.Name;

        public ContinentViewModel(Continent continent)
        {
            _continent = continent;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
