using Formula1Store.Domain.Models;
using System.ComponentModel.DataAnnotations;
using static Formula1Store.Domain.Common.DataConstants.Product;

namespace Formula1Store.Core.Models.Product
{
    public class AddProductViewModel
    {
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Domain.Models.Category> Categories { get; set; } = new List<Domain.Models.Category>();
    }
}