using Bookshelf.ViewModels;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bookshelf.Services
{
    public class GenericWindowService<T> : IWindowService<T> where T : Window, new()
    {
        public void ShowDialogWindow(ViewModelBase viewModel)
        {
            T window = new T()
            {
                DataContext = viewModel
            };
            window.ShowDialog();
        }

        public void CloseWindow()
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Application.Current.Windows.OfType<T>().First().Close();
            });
        }
    }
}
