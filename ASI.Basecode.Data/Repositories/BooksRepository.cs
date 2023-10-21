using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class BooksRepository : BaseRepository , IBooksRepository
    {
        public BooksRepository(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {

        }
        //add books
        public void AddBook(Book book) 
        { 
            this.GetDbSet<Book>().Add(book);
            UnitOfWork.SaveChanges();
        } 
        //get all books
        public List<Book> GetBooks() 
        { 
            var books = GetDbSet<Book>().ToList();  
            return books;
        }

        //retrieve single book
        public Book GetBook(int id)
        {
            var book = this.GetDbSet<Book>().FirstOrDefault(x => x.Id == id);
            return book;
        }
        //update book
        public void UpdateBook(Book book)
        {
            this.GetDbSet<Book>().Update(book);
            UnitOfWork.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            this.GetDbSet<Book>().Remove(book);
            UnitOfWork.SaveChanges();
        }
    }
}
