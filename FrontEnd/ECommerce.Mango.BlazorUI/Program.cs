using Blazored.LocalStorage;
using ECommerce.Mango.BlazorUI;
using ECommerce.Mango.BlazorUI.Interfaces;
using ECommerce.Mango.BlazorUI.Services.Coupons;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add Microsoft.Extensions.Http
builder.Services.AddHttpClient<ICouponClient, CouponClient>(
    configureClient: options =>
    {
        options.BaseAddress = new Uri("https://localhost:7001");
        options.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json", 1.0));
    });

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ICouponService, CouponService>();

await builder.Build().RunAsync();
