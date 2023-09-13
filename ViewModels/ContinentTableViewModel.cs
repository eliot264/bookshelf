using Bookshelf.Models;
using Bookshelf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels
{
    public class ContinentTableViewModel : ViewModelBase
    {
        private readonly IDataService<Continent> _continentService;
        private IEnumerable<ContinentViewModel> _continents;

        public IEnumerable<ContinentViewModel> Continents
        {
            get { return _continents; }
            set
            {
                _continents = value;
                OnPropertyChanged(nameof(Continents));
            }
        }

        private ContinentTableViewModel(IDataService<Continent> continentService)
        {
            _continentService = continentService;
            _continents = new List<ContinentViewModel>();
        }

        public static ContinentTableViewModel LoadContinentTableViewModel(IDataService<Continent> continentService)
        {
            ContinentTableViewModel continentTableViewModel = new ContinentTableViewModel(continentService);
            continentTableViewModel.LoadContinents();
            return continentTableViewModel;
        }

        private async Task LoadContinents()
        {
            IEnumerable<Continent> continents = await _continentService.GetAll();
            _continents = continents.Select(continent => new ContinentViewModel(continent));
        }
    }
}
