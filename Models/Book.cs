using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class Book : DomainObject
    {
        public string Title { get; set; }
        public ICollection<Category> Categories { get; }
        public DateOnly PublicationDate { get; set; }
        public int NumberOfPages { get; set; }
        public ICollection<Author> Authors { get; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; }
        public int FormatId { get; set; }
        public Format Format { get; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string ISBN { get; set; }
    }
}
