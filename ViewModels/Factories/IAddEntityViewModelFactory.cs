using Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels.Factories
{
    public interface IAddEntityViewModelFactory<T> where T : DomainObject, new()
    {
        AddEntityViewModel<T> CreateAddEntityViewModel(EntityListingViewModel<T> entityListingViewModel);
    }
}
