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
    public class AddEntityViewModel<T> : ViewModelBase where T : DomainObject, new()
    {
        private readonly EntityListingViewModel<T> _entityListingViewModel;
        private readonly IDataService<T> _dataService;
        protected T _entity;

        public ICommand AddEntityCommand { get; set; }

        public AddEntityViewModel(EntityListingViewModel<T> entityListingViewModel, IDataService<T> dataService)
        {
            _entityListingViewModel = entityListingViewModel;
            _dataService = dataService;
            _entity = new T();
            AddEntityCommand = new AddEntityCommand<T>(this, _entity, _dataService);
        }
        public void PassAddedEntityToParent(T entity)
        {
            _entityListingViewModel.AddEntityToList(entity);
        }
    }
}
