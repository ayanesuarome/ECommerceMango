using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Mango.Services.AuthAPI.Data.Configurations;

internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "bcfd3118-db1d-4bd6-af03-35536c4c5169",
                UserId = "82ef7b08-5017-4718-988e-e4f119594fca"
            });
    }
}
