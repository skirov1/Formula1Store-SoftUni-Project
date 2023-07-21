using Formula1Store.Core.Contracts;
using Formula1Store.Core.Models.Product;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            var model = new ProductModel()
            {
                ProductCategories = await productService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(ProductModel model)
        {
            if ((await productService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }

            int id = await productService.Create(model);

            return RedirectToAction(nameof(Details), new { id });
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
            query.Categories = await productService.AllCategoriesNames();
            query.Products = result.Products;

            return View(query);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await productService.ProductDetails(id);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var product = await productService.ProductDetails(id);
            var categoryId = await productService.GetProductCategoryId(id);

            var model = new ProductModel()
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                CategoryId = categoryId,
                ProductCategories = await productService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, ProductModel model)
        {

            if ((await productService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Product does not exist");
                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }

            if ((await productService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }

            await productService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            } 

            var product = await productService.ProductDetails(id);
            var model = new ProductDetailsModel()
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl
            };

            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id, ProductDetailsModel model)
        {
            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            await productService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}