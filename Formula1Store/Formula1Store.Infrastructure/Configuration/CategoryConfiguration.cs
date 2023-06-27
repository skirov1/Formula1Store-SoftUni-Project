using Formula1Store.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1Store.Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private List<Category> SeedCategories()
        {
            var categories = new List<Category>();

            var category = new Category()
            {
                Id = 1,
                Name = "T-Shirt"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Jackets"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Headwear"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Shorts"
            };

            categories.Add(category);

            return categories;
        }
    }
}