﻿using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.ProductPropertyNameViewModels.ProductPropertyNameVMServer;
using eShop.Service.CategoryService.CategoryForServer;
using eShop.Service.ProductPropertyGroupService.ProductPropertyGroupForServer;
using eShop.Service.ProductPropertyNameService.ProductPropertyNameForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class ProductPropertyNameController : BaseAdminController
	{
		#region متد های پیکربندی اطلاعات نام ویژه گی های کالاها یا محصولات در سمت سرور یا مدیرسایت

		private readonly IProductPropertyNameServiceForServer _productPropertyNameService;
		private readonly IProductPropertyGroupServiceForServer _productPropertyGroupService;
		private readonly ICategoriesServiceForServer _categoryService;
		private readonly IToastNotification _toastNotification;
		public ProductPropertyNameController(IProductPropertyNameServiceForServer propertyNameService,
			IProductPropertyGroupServiceForServer propertyGroupService, ICategoriesServiceForServer categoryService, IToastNotification toastNotification)
		{
			_productPropertyNameService = propertyNameService;
			_productPropertyGroupService = propertyGroupService;
			_categoryService = categoryService;
			_toastNotification = toastNotification;
		}
		#endregion

		#region متد های دریافت لیست اطلاعات نام ویژه گی های کالاها یا محصولات در سمت سرور یا مدیرسایت

		public IActionResult Index()
		{
			return View(_productPropertyNameService.GetProductPropertyNames());
		}
		#endregion

		#region متد های ثبت نام ویژه گی های کالاها یا محصولات در سمت سرور یا مدیرسایت
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.ProductPropertyGroups = _productPropertyGroupService.GetProductPropertyGroups();
			ViewBag.GetCategories = _categoryService.GetCategories();
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateProductPropertyNameViewModel createProperty)
		{
			var Result = _productPropertyNameService.CreateProductPropertyName(createProperty);
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

		#region متد های بروزرسانی نام ویژه گی های کالاها یا محصولات در سمت سرور یا مدیرسایت

		#endregion

		#region متد های حذف نام ویژه گی های کالاها یا محصولات در سمت سرور یا مدیرسایت

		#endregion
	}
}
