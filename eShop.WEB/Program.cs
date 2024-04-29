using eShop.Data.Context;
using eShop.Service.BrandsService.BrandsForServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region تنظیمات رشته اتصال به پایگاه داده

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
	option.UseSqlServer(builder.Configuration.GetConnectionString("StrEShopConDb"));
});
#endregion

#region متصل کردن کلیه سرویس های پروژه در سمت سرور

builder.Services.AddTransient<IBrandsServiceForServer, BrandsServiceForServer>();
#endregion

#region متصل کردن کلیه سرویس های پروژه در سمت کلاینت

#endregion

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
    name: "area",
    pattern: "{area:exists}/{controller=AdminDashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
