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
    public enum EntityDetailsMode
    {
        Add, Update
    }
    public class EntityDetailsViewModel<T> : ViewModelBase where T : DomainObject, new()
    {
        private readonly EntityDetailsMode _mode;
        private readonly IDataService<T> _dataService;
        private readonly EntityListingViewModel<T>? _entityListingViewModel;
        private readonly EntityListingElementViewModel<T>? _entityListingElementViewModel;
        protected T _entity;

        public EntityDetailsMode Mode => _mode;

        public ICommand AcceptCommand { get; set; }

        protected EntityDetailsViewModel(IDataService<T> dataService, EntityListingElementViewModel<T> entityListingElementViewModel, T entity)
        {
            _mode = EntityDetailsMode.Update;
            _dataService = dataService;
            _entityListingElementViewModel = entityListingElementViewModel;
            _entity = entity;

            AcceptCommand = new UpdateEntityCommand<T>(this, _dataService, _entity);
        }

        protected EntityDetailsViewModel(IDataService<T> dataService, EntityListingViewModel<T> entityListingViewModel)
        {
            _mode = EntityDetailsMode.Add;
            _dataService = dataService;
            _entityListingViewModel = entityListingViewModel;
            _entity = new T();

            AcceptCommand = new AddEntityCommand<T>(this, _entity, _dataService);
        }
        public void PassAddedEntityToParent(T entity)
        {
            _entityListingViewModel?.AddEntityToList(entity);
        }

        public void PassUpdatedEntityToParent(T entity)
        {
            _entityListingElementViewModel?.UpdateEntity(entity);
        }
    }
}
