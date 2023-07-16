using Formula1Store.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1Store.Core.Models.Product
{
    public class ProductServiceModel : IProductModel
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;

        public decimal Price { get; init; }
    }
}
