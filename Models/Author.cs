using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class Author : DomainObject
    {
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly? DeathDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; } // Nationality
        public ICollection<Book> Books { get; }
    }
}
