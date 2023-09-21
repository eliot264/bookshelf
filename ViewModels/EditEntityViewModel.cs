using Bookshelf.Commands;
using Bookshelf.Models;
using Bookshelf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookshelf.ViewModels
{
    public class EditEntityViewModel<T> : ViewModelBase where T : DomainObject, new()
    {
        private readonly EntityListingElementViewModel<T> _entityListingElementViewModel;
        private readonly IDataService<T> _dataService;
        protected T _entity;

        public ICommand UpdateEntityCommand { get; set; }

        public EditEntityViewModel(EntityListingElementViewModel<T> entityListingElementViewModel, IDataService<T> dataService, T entity)
        {
            _entityListingElementViewModel = entityListingElementViewModel;
            _dataService = dataService;
            _entity = entity;

            UpdateEntityCommand = new UpdateEntityCommand<T>(this, _dataService, _entity);
        }

        public void PassUpdatedEntityToParent(T entity)
        {
            _entityListingElementViewModel.UpdateEntity(entity);
        }
    }
}
