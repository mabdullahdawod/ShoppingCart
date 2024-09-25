using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;
using Radzen;
using ShoppingCart.Client.Pages;
using ShoppingCart.Components;
using ShoppingCart.Services;
using ShoppingCart.SharedService;
using ShoppingCartShared.Dbcontext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();



builder.Services.AddScoped<ProductServices>();
builder.Services.AddSingleton<ProductShareService>();
builder.Services.AddRadzenComponents();
builder.Services.AddBootstrapBlazor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ShoppingCart.Client._Imports).Assembly);

app.Run();
