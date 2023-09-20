using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories
{
    public interface IBookshelfViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
