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
    public enum DeleteEntityMode
    {
        Single, Many
    }
    public class DeleteEntityCommand<T> : CommandBase where T : DomainObject, new()
    {
        private readonly DeleteEntityMode _mode;
        private readonly IDataService<T> _dataService;
        private readonly T? _entity;

        private readonly EntityListingElementViewModel<T>? _entityListingElementViewModel;

        public DeleteEntityCommand(IDataService<T> dataService, T entity, EntityListingElementViewModel<T> entityListingElementViewModel)
        {
            _mode = DeleteEntityMode.Single;
            _dataService = dataService;
            _entity = entity;
            _entityListingElementViewModel = entityListingElementViewModel;
        }

        public override void Execute(object? parameter)
        {
            switch (_mode)
            {
                case DeleteEntityMode.Single:
                    if(_entity != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if(result == MessageBoxResult.Yes)
                        {
                            _dataService.Delete(_entity.Id);
                            _entityListingElementViewModel?.RemoveFromParent();
                        }   
                    }
                    break;
                case DeleteEntityMode.Many:
                    //todo
                    break;
                default:
                    //todo
                    break;
            }
        }
    }
}
