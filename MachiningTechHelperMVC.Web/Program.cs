using FluentValidation;
using FluentValidation.AspNetCore;
using MachiningTechelperMVC.Application.ViewModels.DrillCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.DrillParametersRange;
using MachiningTechHelperMVC.Application;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using MachiningTechHelperMVC.Infrastrucure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//use serilog logger
Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

builder.Services.AddSerilog();
Log.Information("Application starting up");

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// role based authorization
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Context>();

//Add dependency injection
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

//Use fluentValidation libary
builder.Services.AddControllersWithViews().AddFluentValidation(fv => fv.DisableDataAnnotationsValidation = true);

builder.Services.AddTransient<IValidator<NewDrillVm>, NewDrillValidation>();
builder.Services.AddTransient<IValidator<DrillCheckedParametersVm>, DrillCheckedParametersValidation>();
builder.Services.AddTransient<IValidator<DrillParametersRangeVm>, DrillParametersRangeValidation>();

// Configure register and login pages
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;

    options.SignIn.RequireConfirmedEmail = false;

    options.User.RequireUniqueEmail = true;
});

//Add google and facebook authentication
builder.Services.AddAuthentication().AddGoogle(options =>
{
    IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
    options.ClientId = googleAuthNSection["ClientId"];
    options.ClientSecret = googleAuthNSection["ClientSecret"];
}).AddFacebook(options =>
{
    IConfigurationSection facebookAuthNSection = builder.Configuration.GetSection("Authentication:Facebook");
    options.AppId = facebookAuthNSection["AppId"];
    options.AppSecret = facebookAuthNSection["AppSecret"];
});

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

// close serilog
Log.CloseAndFlush();