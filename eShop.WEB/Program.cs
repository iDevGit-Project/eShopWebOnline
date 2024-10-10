using eShop.Data.Context;
using eShop.Service.BrandsService.BrandsForServer;
using eShop.Service.CategoryService.Command;
using eShop.Service.CategoryService.Query;
using eShop.Service.ColorService.Command;
using eShop.Service.ColorService.Query;
using eShop.Service.Comment_FAQ.Command.FAQ;
using eShop.Service.Comment_FAQ.CommentFAQForClient;
using eShop.Service.Comment_FAQ.CommentFAQForServer;
using eShop.Service.Comment_FAQ.Query.FAQ;
using eShop.Service.DisCountService.DisCountForServer;
using eShop.Service.ProductGalleryService.ProductGalleryForServer;
using eShop.Service.ProductPropertyGroupService.ProductPropertyGroupForServer;
using eShop.Service.ProductPropertyNameService.ProductPropertyNameForServer;
using eShop.Service.ProductPropertyValueService.ProductPropertyValueServer;
using eShop.Service.ProductService.ProductForClient;
using eShop.Service.ProductService.ProductForServer;
using eShop.Service.SliderService.SliderForClient;
using eShop.Service.SliderService.SliderForServer;
using eShop.Service.WarrantyService.WarrantyForServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
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


#region Command سرویس های مربوط به 
builder.Services.AddTransient<ICategoryServiceCommand, CategoryServiceCommand>();
builder.Services.AddTransient<IColorServiceCommand, ColorServiceCommand>();
builder.Services.AddScoped<IFAQServiceCommand, FAQServiceCommand>();
#endregion

#region Query سرویس های مربوط به 
builder.Services.AddTransient<ICategoryServiceQuery, CategoryServiceQuery>();
builder.Services.AddTransient<IColorServiceQuery, ColorServiceQuery>();
builder.Services.AddScoped<IFAQServiceQuery, FAQServiceQuery>();
#endregion

//#region متصل کردن کلیه سرویس های پروژه در سمت سرور

//builder.Services.AddTransient<IBrandsServiceForServer, BrandsServiceForServer>();
//builder.Services.AddTransient<IWarrantiesServiceForServer, WarrantiesServiceForServer>();
//builder.Services.AddTransient<ISlidersServiceForServer, SlidersServiceForServer>();
//builder.Services.AddTransient<IColorsServiceForServer, ColorsServiceForServer>();
//builder.Services.AddTransient<IProductServiceForServer, ProductServiceForServer>();
//builder.Services.AddTransient<IProductGalleryServiceForServer, ProductGalleryServiceForServer>();
//builder.Services.AddTransient<IProductPropertyGroupServiceForServer, ProductPropertyGroupServiceForServer>();
//builder.Services.AddTransient<IProductPropertyNameServiceForServer, ProductPropertyNameServiceForServer>();
//builder.Services.AddTransient<IProductPropertyValueServiceForServer, ProductPropertyValueServiceForServer>();
//builder.Services.AddTransient<IDisCountServiceForServer, DisCountServiceForServer>();
//builder.Services.AddTransient<ICommentFAQServiceForServer, CommentFAQServiceForServer>();

//#endregion

//#region متصل کردن کلیه سرویس های پروژه در سمت کلاینت
//builder.Services.AddTransient<ISliderServiceForClient, SliderServiceForClient>();
//builder.Services.AddTransient<IProductServiceForClient, ProductServiceForClient>();
//builder.Services.AddTransient<ICommentFAQServiceForClient, CommentFAQServiceForClient>();
//#endregion

#region عملیات نمایش پیغام های گرافیکی
builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions
{
	ProgressBar = true,
    CloseButton = true,
    NewestOnTop = true,
	PositionClass = ToastPositions.TopCenter,
});
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
app.UseNToastNotify();

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=AdminDashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
