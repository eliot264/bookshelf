using Bookshelf.Models;
using Bookshelf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.ViewModels
{
    public class BookTableViewModel : ViewModelBase
    {
        private readonly IDataService<Book> _bookService;
        private IEnumerable<BookViewModel> _books;

        public IEnumerable<BookViewModel> Books => _books;

        private BookTableViewModel(IDataService<Book> bookService)
        {
            _bookService = bookService;
            _books = new List<BookViewModel>();
        }

        public static BookTableViewModel LoadBookTableViewModel(IDataService<Book> bookService)
        {
            BookTableViewModel bookTableViewModel = new BookTableViewModel(bookService);
            bookTableViewModel.LoadBooks();
            return bookTableViewModel;
        }

        private async Task LoadBooks()
        {
             IEnumerable<Book> books = await _bookService.GetAll();
            _books = books.Select(book => new BookViewModel(book));
        }
    }
}
