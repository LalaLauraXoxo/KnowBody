using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class ForgotPasswordController : Controller
    {
        [AllowAnonymous]
        public IActionResult ForgotPasswordView()
        {
            return View();
        }
    }
}
