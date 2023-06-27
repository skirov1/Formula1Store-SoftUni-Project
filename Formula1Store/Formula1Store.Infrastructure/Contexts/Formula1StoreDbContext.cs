using Formula1Store.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Formula1Store.Infrastructure.Data
{
    public class Formula1StoreDbContext : IdentityDbContext<User>
    {
        public Formula1StoreDbContext(DbContextOptions<Formula1StoreDbContext> options)
            : base(options)
        {
        }
    }
}