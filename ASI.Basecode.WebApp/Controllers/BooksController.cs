using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
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
    }
}
