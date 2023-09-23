using Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Services
{
    public interface IDataSeedService<T> where T : DomainObject
    {
        void Seed();
    }
}
