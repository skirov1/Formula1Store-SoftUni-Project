using Formula1Store.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1Store.Infrastructure.Configuration.Account
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
                Id = "c3d5a085-6769-4739-9ae6-c5155c996db2",
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
                Id = "1566b311-5fd9-4d09-8cd7-3b126ffcf80e",
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
