using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class Country : DomainObject
    {
        public string Name { get; set; }
        public ICollection<Continent> Continents { get; set; }
        public ICollection<Publisher> Publishers { get; }
        public ICollection<Author> Authors { get; }

        public Country()
        {
            Name = string.Empty;
            Continents = new List<Continent>();
            Publishers = new List<Publisher>();
            Authors = new List<Author>();
        }
    }
}
