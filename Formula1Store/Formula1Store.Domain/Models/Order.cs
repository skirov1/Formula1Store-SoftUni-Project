using Formula1Store.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using static Formula1Store.Domain.Common.DataConstants.Order;
using static Formula1Store.Domain.Common.DataConstants.Common;

namespace Formula1Store.Domain.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new List<ShoppingCartItem>();
        }

        [Key]
        public int Id { get; set; }

        public string CustomerId { get; set; } = null!;

        [Required]
        [StringLength(UserFullNameMaxLength, MinimumLength = UserFullNameMinLength)]
        public string UserFullName { get; set; } = null!;

        [Required]
        [StringLength(UserPhoneNumberMaxLength)]
        public string UserPhoneNumber { get; set; } = null!;

        [Required]
        public string DeliveryAddress { get; set; } = null!;

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = DateFormat)]
        public DateTime OrderDate { get; private set; } = DateTime.Now;

        public ICollection<ShoppingCartItem> Products { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        public decimal TotalOrderPrice()
        {
            var total = 0m;

            foreach (var item in Products)
            {
                total += item.Price * item.Quantity;
            }

            return total;
        }
    }
}