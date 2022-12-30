using Hospital.DataAccess.Abstract;
using Hospital.DataAccess.EntityFramework.Concrete;
using Hospital.DataAccess.EntityFramework.Context;
using HospitalAutomation.Models.SeedDataFolder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HospitalDBContext>(
    _ =>
    {
        _.UseSqlServer(builder.Configuration.GetConnectionString("HospitalConnectionString"));
    });

builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IManagerRepo, ManagerRepo>();
builder.Services.AddScoped<IPersonnelRepo, PersonnelRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


SeedData.Seed(app);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
