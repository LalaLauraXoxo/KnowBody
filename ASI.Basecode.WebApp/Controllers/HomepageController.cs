using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Homepage()
        {
            return View();
        }
    }
}
