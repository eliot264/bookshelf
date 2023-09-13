using Bookshelf.Commands;
using Bookshelf.Models;
using Bookshelf.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookshelf.ViewModels
{
    public class ContinentTableViewModel : ViewModelBase, ITableViewModel
    {
        private readonly IDataService<Continent> _continentService;
        private ObservableCollection<ContinentViewModel> _continents;

        public ICommand OpenAddContinentWindowCommand { get; }

        public ObservableCollection<ContinentViewModel> Continents
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
            _continents = new ObservableCollection<ContinentViewModel>();

            OpenAddContinentWindowCommand = new OpenAddWindow(new AddContinentViewModel(continentService, this));
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
            Continents = new ObservableCollection<ContinentViewModel>(continents.Select(continent => new ContinentViewModel(continent)));
        }

        public async Task ReloadData()
        {
            await LoadContinents();
        }
    }
}
