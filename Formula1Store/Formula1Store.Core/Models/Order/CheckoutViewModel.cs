using Formula1Store.Core.Models.Cart;
using System.ComponentModel.DataAnnotations;
using static Formula1Store.Domain.Common.DataConstants.Order;

namespace Formula1Store.Core.Models.Order
{
    public class CheckoutViewModel
    {
        public string? OrderNumber { get; set; }

        [Required]
        public string DeliveryAddress { get; set; } = null!;

        [Required]
        [StringLength(UserPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(UserFullNameMaxLength, MinimumLength = UserFullNameMinLength)]
        public string UserFullName { get; set; } = null!;

        public ShoppingCartDto? UserCart { get; set; }

        public ICollection<ShoppingCartItemDto>? CartItems { get; set; }

        public decimal TotalPrice()
        {
            return Math.Round(UserCart.CartItems.Sum(x => x.Price * x.Quantity), 2);
        }
    }
}