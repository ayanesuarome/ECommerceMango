using ECommerce.Mango.Services.CouponAPI.Persistence;
using ECommerce.Mango.Services.CouponAPI.Persistence.DatabaseContext;
using ECommerce.Mango.Services.CouponAPI.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCouponEFDbContext(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// apply pending migrations
MigrationHelper.ApplyMigration(app.Services);

app.Run();