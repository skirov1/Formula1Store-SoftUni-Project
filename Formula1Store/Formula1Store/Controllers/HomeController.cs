using Formula1Store.Core.Contracts;
using Formula1Store.Core.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Formula1Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        private readonly ILogger logger;

        public HomeController(
            ILogger<HomeController> _logger,
            IProductService _productService)
        {
            logger = _logger;
            productService = _productService;
        }

        public async Task<IActionResult> Index()
        {
            //if (User.IsInRole(AdminRolleName))
            //{
            //    return RedirectToAction("Index", "Admin", new { area = "Admin" });
            //}
            var model = await productService.LastThreeProducts();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}