using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Data.Repositories;
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

        public Book GetBook(int id)
        {
            var book = _booksRepository.GetBook(id);

            return book;
        }
        public bool UpdateBook(BooksViewModel bookViewModel)
        {
            Book book = _booksRepository.GetBook(bookViewModel.Id);
            if (book != null)
            {
                book.Title = bookViewModel.Title;
                book.Author = bookViewModel.Author;
                book.Description = bookViewModel.Description;
                book.UpdatedBy = "hanphil";
                book.UpdatedTime = System.DateTime.Now;

                _booksRepository.UpdateBook(book);
                return true;
            }

            return false;
        }
        public bool DeleteBook(BooksViewModel bookViewModel)
        {
            Book book = _booksRepository.GetBook(bookViewModel.Id);
            if (book != null)
            {
                _booksRepository.DeleteBook(book);
                return true;
            }

            return false;
        }

    }
}
