using Bookshelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bookshelf.Services
{
    public interface IWindowService<T> where T : Window
    {
        void ShowDialogWindow(ViewModelBase viewModel);
        void CloseWindow();
    }
}
