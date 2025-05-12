using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NI_Project.UI;
using NI_Project.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7091") });

builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IReadersService, ReadersService>();
builder.Services.AddScoped<ILoansService, LoansService>();

await builder.Build().RunAsync();
