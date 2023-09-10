using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel => _currentViewModel;

        public MainViewModel(ViewModelBase currentViewModel)
        {
            _currentViewModel = currentViewModel;
        }
    }
}
