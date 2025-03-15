using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FoodShopBilling.Server.Shared.Services;
using FoodShopBilling.Server.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the FoodShopBilling.Server.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
