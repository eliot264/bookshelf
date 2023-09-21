using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Commands
{
    public class UpdateEntityCommand<T> : CommandBase where T : DomainObject, new()
    {
        private readonly EditEntityViewModel<T> _editEntityViewModel;
        private readonly IDataService<T> _dataService;
        private readonly T _entity;

        public UpdateEntityCommand(EditEntityViewModel<T> editEntityViewModel, IDataService<T> dataService, T entity)
        {
            _editEntityViewModel = editEntityViewModel;
            _dataService = dataService;
            _entity = entity;
        }

        public override void Execute(object? parameter)
        {
            _dataService.Update(_entity.Id, _entity).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    _editEntityViewModel.PassUpdatedEntityToParent(task.Result);
                }
                else
                {
                    throw task.Exception;
                }
            });
        }
    }
}
