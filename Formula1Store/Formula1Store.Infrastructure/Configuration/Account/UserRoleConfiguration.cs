using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Formula1Store.Infrastructure.Configuration.Account
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var identityRolesToSeed = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    UserId = "1566b311-5fd9-4d09-8cd7-3b126ffcf80e",
                    RoleId = "9a13d4a4-ac13-41fa-9de1-9de5331984d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "c3d5a085-6769-4739-9ae6-c5155c996db2",
                    RoleId = "e7a7d258-3928-49d8-b91b-3a3c5683e124"
                }
            };

            builder.HasData(identityRolesToSeed);
        }
    }
}