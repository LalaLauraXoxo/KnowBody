using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using ASI.Basecode.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;

        //constructor to call service
        
        public BooksController(IBooksService booksService) 
        {
            _booksService = booksService;
        }
        public IActionResult Index()
        {
            var books = _booksService.GetBooks();
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BooksViewModel booksViewModel)
        {
            _booksService.AddBook(booksViewModel);
            return RedirectToAction("Index");
        }

        //check book if exist, then display data
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _booksService.GetBook(id);
            if (book != null)
            {
                BooksViewModel bookViewModel = new()
                {
                    Id = id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                };

                return View(bookViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(BooksViewModel bookViewModel)
        {
            bool isUpdated = _booksService.UpdateBook(bookViewModel);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Delete(BooksViewModel bookViewModel)
        {
            bool isDeleted = _booksService.DeleteBook(bookViewModel);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
