using Formula1Store.Core.Contracts;
using Formula1Store.Core.Repositories;
using Formula1Store.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Formula1Store.Core.Extensions
{
    public static class Formula1StoreServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();

            return services;
        }
    }
}