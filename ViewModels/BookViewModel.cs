using Bookshelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels
{
    public class BookViewModel : ViewModelBase
    {
        private readonly Book _book;

        public string Title => _book.Title;
        public ICollection<Category> Categories => _book.Categories;
        public DateOnly PublicationDate => _book.PublicationDate;
        public int NumberOfPages => _book.NumberOfPages;
        public ICollection<Author> Authors => _book.Authors;
        public Publisher Publisher => _book.Publisher;
        public Format Format => _book.Format;
        public Language Language => _book.Language;
        public string ISBN => _book.ISBN;

        public BookViewModel(Book book)
        {
            _book = book;
        }
    }
}
