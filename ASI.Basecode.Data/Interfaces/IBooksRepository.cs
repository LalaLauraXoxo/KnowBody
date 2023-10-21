using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IBooksRepository
    {
        public void AddBook(Book book);

        public List<Book> GetBooks();
    }
}