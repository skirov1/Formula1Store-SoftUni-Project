using Microsoft.AspNetCore.Mvc;

namespace Formula1Store.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
