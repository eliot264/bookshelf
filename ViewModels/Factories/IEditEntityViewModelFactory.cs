using Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories
{
    public interface IEditEntityViewModelFactory<T> where T : DomainObject, new()
    {
        EditEntityViewModel<T> CreateEditEntityViewModel(EntityListingElementViewModel<T> entityListingElementViewModel, T entity);
    }
}
