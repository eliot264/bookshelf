﻿using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Commands
{
    public class AddEntityCommand<T> : CommandBase where T : DomainObject, new()
    {
        private readonly AddEntityViewModel<T> _addEntityViewModel;
        private readonly IDataService<T> _dataService;
        private readonly T _entity;

        public AddEntityCommand(AddEntityViewModel<T> addEntityViewModel, T entity, IDataService<T> dataService)
        {
            _addEntityViewModel = addEntityViewModel;
            _dataService = dataService;
            _entity = entity;
        }

        public override void Execute(object? parameter)
        {
            _dataService.Create(_entity).ContinueWith(task =>
            {
                if(task.Exception == null)
                {
                    _addEntityViewModel.PassAddedEntityToParent(task.Result);
                }
            });
        }
    }
}
