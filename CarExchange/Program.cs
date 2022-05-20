using CarExchange.Common;
using CarExchange.Core.Services;
using CarExchange.Core.Services.Contracts;
using CarExchange.Infrastructure.Data;
using CarExchange.Infrastructure.Data.Common.ApplicationRepository;
using CarExchange.Infrastructure.Data.Common.ApplicationRepository.Contracts;
using CarExchange.Infrastructure.Data.Settings;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("ConnectionStrings:Mongo"));

builder.Services.AddDbContexts(builder.Configuration);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services
    .AddScoped<IApplicationRepository, ApplicationRepository>()
    .AddScoped<IImageService, ImageService>()
    .AddScoped<ICarService, CarService>()
    .AddScoped<IFeatureService, FeatureService>();

builder.Services.AddControllersWithViews();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 4;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: Constraints.Role.Admin,
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
