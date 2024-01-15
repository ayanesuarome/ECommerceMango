using ECommerce.Mango.Services.CouponAPI.Core.Application;
using ECommerce.Mango.Services.CouponAPI.Persistence;
using ECommerce.Mango.Services.CouponAPI.Persistence.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCouponEFDbContext(builder.Configuration);
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CouponAPIAll",
        policy => policy
            .WithOrigins("https://localhost:7039")
            .WithMethods("GET", "POST", "PUT", "DELETE")
            .AllowAnyHeader());
});

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

app.UseCors("CouponAPIAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// apply pending migrations
MigrationHelper.ApplyMigration(app.Services);

app.Run();