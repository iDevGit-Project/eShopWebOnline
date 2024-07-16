using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.ProductPropertyValueViewModels.ProductPropertyValueVMServer;
using eShop.Service.ProductPropertyNameService.ProductPropertyNameForServer;
using eShop.Service.ProductPropertyValueService.ProductPropertyValueServer;
using eShop.Service.ProductService.ProductForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class ProductPropertyValueController : BaseAdminController
	{
		#region متد های پیکربندی مقادیر ویژه گی های کالاها یا محصولات در سمت سرور یا مدیرسایت
		private readonly IProductPropertyValueServiceForServer _propertyValueService;
		private readonly IProductPropertyNameServiceForServer _propertyNameService;
		private readonly IProductServiceForServer _productService;
		private readonly IToastNotification _toastNotification;

		public ProductPropertyValueController(IProductPropertyValueServiceForServer propertyValueService,
			IProductPropertyNameServiceForServer propertyNameService, IProductServiceForServer productService, IToastNotification toastNotification)
		{
			_propertyValueService = propertyValueService;
			_propertyNameService = propertyNameService;
			_productService = productService;
			_toastNotification = toastNotification;
		}
		#endregion

		#region متد نمایش لیست کلیه مقادر ویژه گی های محصولات یا کالاها
		public IActionResult Index()
		{
			return View(_propertyValueService.GetProductPropertyValues());
		}
		#endregion

		#region متد ثبت مقادیر برای ویژه گی های محصولات یا کالاهای سایت
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.ProductPropertyNames = _propertyNameService.GetProductPropertyNames();
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateProductPropertyValueViewModel createPropertyValue)
		{
			var Result = _propertyValueService.CreateProductPropertyValue(createPropertyValue);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddSuccessToastMessage("ثبت اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = false,
				NewestOnTop = true,
				TimeOut = 2000,
				Title = "موفق...",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region متد ثبت یا بروزرسانی مقادیر ویژه گی های محصولات یا کالاهای سایت برای مدیر سایت
		[HttpGet]
		public IActionResult ProductProperty(int Id)
		{
			AddOrUpdateProductPropertyValueForProductViewModel addOrUpdate = new AddOrUpdateProductPropertyValueForProductViewModel();
			addOrUpdate.categoryid = _productService.FindProductById(Id).CategoryId;
			addOrUpdate.propertyNameForProduct = _propertyValueService.GetProductPropertyNameForProductByCategoryId(addOrUpdate.categoryid);
			ViewBag.OldValue = _propertyValueService.oldProductPropertyValueForProduct(Id);
			addOrUpdate.ProductId = Id;

			return View(addOrUpdate);
		}

		[HttpPost]
		public IActionResult ProductProperty(AddOrUpdateProductPropertyValueForProductViewModel addOrUpdateProperty)
		{

			if (addOrUpdateProperty.nameid.Count() != addOrUpdateProperty.value.Count())
			{
				addOrUpdateProperty.categoryid = _productService.FindProductById(addOrUpdateProperty.ProductId).CategoryId;
				addOrUpdateProperty.propertyNameForProduct = _propertyValueService.GetProductPropertyNameForProductByCategoryId(addOrUpdateProperty.categoryid);
				ViewBag.OldValue = _propertyValueService.oldProductPropertyValueForProduct(addOrUpdateProperty.ProductId);

				return View(addOrUpdateProperty);
			}

			var Result = _propertyValueService.AddOrRemoveProductPropertyForProduct(addOrUpdateProperty);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddSuccessToastMessage("ثبت اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = false,
				NewestOnTop = true,
				TimeOut = 2000,
				Title = "موفق...",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}

		#endregion
	}
}
