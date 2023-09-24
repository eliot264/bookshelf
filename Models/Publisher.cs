using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class Publisher : DomainObject
    {
        public string Name { get; set; }
        public DateOnly? FoundationDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Book> Books { get; }
    }
}
