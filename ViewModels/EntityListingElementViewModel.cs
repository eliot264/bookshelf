using Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels
{
    public class EntityListingElementViewModel<T> : ViewModelBase where T : DomainObject, new()
    {
        private readonly EntityListingViewModel<T> _entityListingViewModel;
        protected readonly T _entity;
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public EntityListingElementViewModel(EntityListingViewModel<T> entityListingViewModel, T entity)
        {
            _entityListingViewModel = entityListingViewModel;
            _entity = entity;
            _isChecked = false;
        }
    }
}
