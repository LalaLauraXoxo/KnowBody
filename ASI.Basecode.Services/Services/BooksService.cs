using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Resources.Views;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public void AddBook(BooksViewModel booksViewModel)
        {
            Book book = new()
            {
                Author = booksViewModel.Author,
                Title = booksViewModel.Title,
                Description = booksViewModel.Description,
                CreatedBy = "Xymer Serna", // in real program to trace who create
                CreatedDate = DateTime.Now,
                UpdatedBy = "Xymer Serna",
                UpdatedTime = DateTime.Now,
            };

            _booksRepository.AddBook(book);
        }
        public List<Book> GetBooks()
        {
            var books = _booksRepository.GetBooks();
            return books;
        }
    }
}
