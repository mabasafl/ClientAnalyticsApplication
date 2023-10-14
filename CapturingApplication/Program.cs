using Application.Core.Dtos;
using Application.Core.Helpers;
using Application.Core.Interfaces;
using Application.Core.Mappers;
using Application.Core.Models;
using Application.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IMapper<Client, ClientDto>, ClientMapper>();
builder.Services.AddScoped<JsonDataHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
