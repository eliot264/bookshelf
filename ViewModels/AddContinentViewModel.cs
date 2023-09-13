using Bookshelf.Commands;
using Bookshelf.Models;
using Bookshelf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookshelf.ViewModels
{
    public class AddContinentViewModel : ViewModelBase
    {
        private readonly IDataService<Continent> _continentService;
        private readonly ContinentTableViewModel _continentTableViewModel;
        private Continent _continent;

        public string Name
        {
            get { return _continent.Name; }
            set
            {
                _continent.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand AddContinentAndCloseWindowCommand { get; }

        public AddContinentViewModel(IDataService<Continent> continentService, ContinentTableViewModel continentTableViewModel)
        {
            _continentService = continentService;
            _continent = new Continent();
            _continentTableViewModel = continentTableViewModel;

            AddContinentAndCloseWindowCommand = new AddAndCloseWindow<Continent>(_continentService, _continent, _continentTableViewModel);
        }
    }
}
