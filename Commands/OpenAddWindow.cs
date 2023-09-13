using Bookshelf.ViewModels;
using Bookshelf.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Commands
{
    public class OpenAddWindow : CommandBase
    {
        private readonly ViewModelBase _viewModel;

        public OpenAddWindow(ViewModelBase viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            AddObjectWindow window = new AddObjectWindow
            {
                DataContext = _viewModel
            };
            window.ShowDialog();
        }
    }
}
