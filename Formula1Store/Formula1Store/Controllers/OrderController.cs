using Formula1Store.Core.Contracts;
using Formula1Store.Core.Extensions;
using Formula1Store.Core.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace Formula1Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrderController(IOrderService _orderService, ICartService _cartService)
        {
            this.cartService = _cartService;
            this.orderService = _orderService;
        }

        public async Task<IActionResult> All(OrdersViewModel model)
        {
            var userId = HttpContext.GetUserId();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model = await orderService.AllOrders(userId);

            return View(model);
        }

        public async Task<IActionResult> CreateOrder()
        {
            var userId = HttpContext.GetUserId();
            CheckoutViewModel model = new CheckoutViewModel
            {
                UserCart = await cartService.GetOrCreateCart(userId)
            };

            if (model.UserCart.CartItems.Count() < 1)
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var userId = HttpContext.GetUserId();
            var cart = await cartService.GetOrCreateCart(userId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (ModelState.IsValid)
            {
                await orderService.CreateOrder(userId,
                                             cart.Id,
                                             model.UserFullName,
                                             model.PhoneNumber,
                                             model.DeliveryAddress);

                return RedirectToAction("All", "Product");
            }

            model.UserCart = await cartService.GetOrCreateCart(userId);

            return View("CreateOrder", model);
        }
    }
}
