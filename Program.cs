using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GitHubPagesDemo;
using BlazorBootstrap;
using GitHubPagesDemo.Data;
using GitHubPagesDemo.Interface;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.InkML;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazorBootstrap();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseInMemoryDatabase("TestDatabase"));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlite("Data Source=MyApp.db"));

builder.Services.AddScoped<IServiceFactory, ServiceFactory>();
builder.Services.AddScoped<ToastService>();

await builder.Build().RunAsync();

//var app = builder.Build();

//using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
//{
//    using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    context.Database.Migrate();
//}