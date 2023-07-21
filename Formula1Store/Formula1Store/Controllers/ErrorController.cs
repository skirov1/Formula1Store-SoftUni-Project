using Microsoft.AspNetCore.Mvc;

namespace Formula1Store.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}