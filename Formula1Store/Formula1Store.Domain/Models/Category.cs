using System.ComponentModel.DataAnnotations;
using static Formula1Store.Domain.Common.DataConstants.Category;

namespace Formula1Store.Domain.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; }
    }
}