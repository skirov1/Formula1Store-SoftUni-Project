using Formula1Store.Core.Contracts;
using Formula1Store.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Formula1Store.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            this.productService = _productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllProductsQueryModel query)
        {
            var result = await productService.GetAllAsync(
               query.Category,
               query.CurrentPage,
               query.SearchTerm,
               query.Sorting,
               AllProductsQueryModel.ProductsPerPage);

            query.TotalProductsCount = result.TotalProductsCount;
            //query.Categories = await productService
            query.Products = result.Products;

            return View(query);
        }
    }
}