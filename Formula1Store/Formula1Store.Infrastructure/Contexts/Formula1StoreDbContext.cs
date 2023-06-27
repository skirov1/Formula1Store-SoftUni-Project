using Formula1Store.Domain.Enums;
using Formula1Store.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Formula1Store.Infrastructure.Data
{
    public class Formula1StoreDbContext : IdentityDbContext<User>
    {
        public Formula1StoreDbContext(DbContextOptions<Formula1StoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartItem> CartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserOrder>()
              .HasKey(uo => new
              {
                  uo.UserId,
                  uo.OrderId
              });

            base.OnModelCreating(builder);
        }
    }
}