using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using sahibinden_frontend.Components;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<UserService>();



// Add authentication services
builder.Services.AddAuthentication("YourScheme")
    .AddCookie("YourScheme", options =>
    {
        options.LoginPath = "/login";
    });

// Add HttpClient
builder.Services.AddHttpClient();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery(); 


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
