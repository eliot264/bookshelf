using Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories
{
    public interface IEntityDetailsViewModelFactory<T> where T : DomainObject, new()
    {
        EntityDetailsViewModel<T> CreateViewModel(EntityListingElementViewModel<T> entityListingElementViewModel, T entity);
        EntityDetailsViewModel<T> CreateViewModel(EntityListingViewModel<T> entityListingViewModel);
    }
}
