using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1Store.Infrastructure.Configuration.Account
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var rolesToSeed = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = "9a13d4a4-ac13-41fa-9de1-9de5331984d5",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole()
                {
                    Id = "e7a7d258-3928-49d8-b91b-3a3c5683e124",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };

            builder.HasData(rolesToSeed);
        }
    }
}
