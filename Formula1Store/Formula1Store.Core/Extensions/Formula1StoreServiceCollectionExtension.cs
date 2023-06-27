using Formula1Store.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Formula1Store.Core.Extensions
{
    public static class Formula1StoreServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}