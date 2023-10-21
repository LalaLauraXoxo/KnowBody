using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IBooksService
    {
        public void AddBook(BooksViewModel booksViewModel);

        public List<Book> GetBooks();

        public Book GetBook(int id);

        public bool UpdateBook(BooksViewModel booksViewModel);

        public bool DeleteBook(BooksViewModel booksViewModel);
    }
}
