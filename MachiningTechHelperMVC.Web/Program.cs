using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Infrastrucure;
using MachiningTechHelperMVC.Infrastrucure.Repositories;
using MachiningTechHelperMVC.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MachiningTechHelperMVC.Application;
using FluentValidation.AspNetCore;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>();

// dependency injection
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddControllersWithViews().AddFluentValidation(fv => fv.DisableDataAnnotationsValidation = true); //FluentValidation

builder.Services.AddTransient<IValidator<NewDrillVm>, NewDrillValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
