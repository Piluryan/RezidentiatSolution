using DoctorFactory.DAL.Context;
using DoctorFactory.Services;
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
