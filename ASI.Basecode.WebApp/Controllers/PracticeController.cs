using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class PracticeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
