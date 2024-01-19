﻿using ECommerce.Mango.Services.AuthAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Mango.Services.AuthAPI.DatabaseContext;

public sealed class AppIdentityEFDbContext : IdentityDbContext<ApplicationUser>
{
    public AppIdentityEFDbContext(DbContextOptions<AppIdentityEFDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
