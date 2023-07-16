using System.ComponentModel.DataAnnotations;
using static Formula1Store.Domain.Common.DataConstants.Category;

namespace Formula1Store.Core.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}