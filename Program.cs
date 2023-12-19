global using CJPWASM.Services.ProveedorService;
using CJPWASM.Services.ProductoService;
using CJPWASM.Services.CompraService;
using CJPWASM;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ICompraService, CompraService>();


await builder.Build().RunAsync();
