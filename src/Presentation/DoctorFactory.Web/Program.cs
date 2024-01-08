using DoctorFactory.DAL.Context;
using DoctorFactory.Domain.Entities.Identity;
using DoctorFactory.Services;
using DoctorFactory.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Connection string used.

var dbConfig = builder.Configuration.GetSection("DoctorFactory");
var dbType = dbConfig["type"];
var dbConnection = dbConfig.GetConnectionString(dbType!);

builder.Services.AddDbContext<RezidentDatabase>(options =>
{
    options.UseSqlServer(dbConnection, x => x.MigrationsAssembly("DoctorFactory.SqlServer"));
});

#endregion

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<RezidentDatabase>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(opt =>
{
#if DEBUG
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 3;
    opt.Password.RequiredUniqueChars = 3;
#endif

    opt.User.RequireUniqueEmail = false;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ1234567890";

    opt.Lockout.AllowedForNewUsers = false;
    opt.Lockout.MaxFailedAccessAttempts = 10;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
});

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.Name = "DoctorFactory.Cookie";
    opt.Cookie.HttpOnly = true;
    opt.ExpireTimeSpan = TimeSpan.FromDays(10);

    opt.LoginPath = "/Account/Login";
    opt.LogoutPath = "/Account/Logout";
    opt.AccessDeniedPath = "/Account/AccessDenied";

    opt.SlidingExpiration = true;
});

//------------------------------------------------------------------------------//

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<RezitentiatDbInitializer>();
    await dbInitializer.InitializeAsync();
}

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
