using Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels
{
    public class ContinentViewModel : ViewModelBase
    {
        private readonly Continent _continent;

        public string Name => _continent.Name;

        public ContinentViewModel(Continent continent)
        {
            _continent = continent;
        }
    }
}
