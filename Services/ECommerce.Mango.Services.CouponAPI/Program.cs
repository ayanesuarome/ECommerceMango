using ECommerce.Mango.Services.CouponAPI.Core.Application;
using ECommerce.Mango.Services.CouponAPI.Extensions;
using ECommerce.Mango.Services.CouponAPI.Persistence;
using ECommerce.Mango.Services.CouponAPI.Persistence.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCouponEFDbContext(builder.Configuration);
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "CouponAPIAll",
//        policy => policy
//            //.WithOrigins("https://localhost:7039")
//            .WithMethods("GET", "POST", "PUT", "DELETE")
//            .AllowAnyOrigin()
//            .AllowAnyHeader());
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "COUPON API v1");
    options.RoutePrefix = string.Empty;
});

//app.UseCors("CouponAPIAll");

app.UseHttpsRedirection();

// Authentication and Authorization
app.UseAuthentication().UseAuthorization();

app.MapControllers();

app.ApplyPendingMigrations();

app.Run();