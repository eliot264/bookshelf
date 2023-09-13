using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels
{
    public interface ITableViewModel
    {
        public Task ReloadData();
    }
}
