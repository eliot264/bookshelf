using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bookshelf.Commands
{
    public class AddAndCloseWindow<T> : CommandBase where T : DomainObject
    {
        private readonly IDataService<T> _dataService;
        private readonly T _entity;
        private readonly ITableViewModel _tableViewModel;

        public AddAndCloseWindow(IDataService<T> dataService, T entity, ITableViewModel tableViewModel)
        {
            _dataService = dataService;
            _entity = entity;
            _tableViewModel = tableViewModel;
        }

        public override void Execute(object? parameter)
        {
            _dataService.Create(_entity);
            _tableViewModel.ReloadData();
            Window? window = (Window?)parameter;
            if(window != null)
            {
                window.Close();
            }
        }
    }
}
