using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class Language : DomainObject
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; }
    }
}
