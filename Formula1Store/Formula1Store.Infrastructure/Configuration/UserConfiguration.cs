using Formula1Store.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1Store.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<User> SeedUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "Admin123/");

            users.Add(user);

            user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Kiril",
                LastName = "Atanasov",
                UserName = "Kiro",
                NormalizedUserName = "KIRO",
                Email = "kiro@gmail.com",
                NormalizedEmail = "KIRO@GMAIL.COM"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "Kiro123/");

            users.Add(user);

            return users;
        }
    }
}
