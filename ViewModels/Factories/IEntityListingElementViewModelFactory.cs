using Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories
{
    public interface IEntityListingElementViewModelFactory<T> where T: DomainObject, new()
    {
        EntityListingElementViewModel<T> CreateViewModel(EntityListingViewModel<T> entityListingViewModel, T entity);
    }
}
