using ECommerce.Mango.Services.AuthAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Mango.Services.AuthAPI.Data.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        PasswordHasher<ApplicationUser> hasher = new();

        builder.HasData(
            new ApplicationUser
            {
                Id = "82ef7b08-5017-4718-988e-e4f119594fca",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, ""),
                EmailConfirmed = true
            });
    }
}
