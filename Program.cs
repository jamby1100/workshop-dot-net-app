using Microsoft.EntityFrameworkCore;
using WorkshopApp.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WorkshopAppDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:WorkshopAppConnection"]);
});
builder.Services.AddScoped<IWorkshopRepository, EFWorkshopRepository>();
builder.Services.AddScoped<IChallengeRepository, EFChallengeRepository>();
builder.Services.AddScoped<IWorkshopProgressRepository, EFWorkshopProgressRepository>();


builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:IdentityConnection"]));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);

app.Run();
