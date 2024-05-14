using FluentValidation;
using FluentValidation.AspNetCore;
using MachiningTechelperMVC.Application.ViewModels.DrillCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.DrillParametersRange;
using MachiningTechelperMVC.Application.ViewModels.MillingInsertParametersRange;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingTool;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolParametersRange;
using MachiningTechHelperMVC.Application;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using MachiningTechHelperMVC.Infrastrucure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//use serilog logger
Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs.txt")
                .CreateLogger();

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
builder.Services.AddTransient<IValidator<DrillCheckedParametersVm>, DrillCheckedParametersValidation>();
builder.Services.AddTransient<IValidator<DrillParametersRangeVm>, DrillParametersRangeValidation>();
builder.Services.AddTransient<IValidator<MillingInsertParametersRangeVm>, MillingInsertParametersRangeValidation>();
builder.Services.AddTransient<IValidator<NewSolidMillingToolVm>, NewSolidMillingToolValidation>();
builder.Services.AddTransient<IValidator<SolidMillingToolParametersRangeVm>, SolidMillingToolParametersRangeValidation>();

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
