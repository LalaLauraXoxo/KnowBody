using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class ForgotPasswordController : Controller
    {
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
