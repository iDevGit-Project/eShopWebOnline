﻿using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.ProductsViewModels.ProductsVMServer;
using eShop.Service.BrandsService.BrandsForServer;
using eShop.Service.CategoryService.Query;
using eShop.Service.ProductService.ProductForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
    [Area(nameof(Administrator))]
	public class ProductController : BaseAdminController
	{
		#region متد های سرویس های کالاها یا محصولات، برندها و دسته بندی ها
		private readonly IProductServiceForServer _productService;
		private readonly IBrandsServiceForServer _brandService;
		private readonly ICategoryServiceQuery _categoryServiceQuery;
		private readonly IToastNotification _toastNotification;

		public ProductController(IProductServiceForServer productService, IBrandsServiceForServer brandService,
			ICategoryServiceQuery categoryServiceQuery, IToastNotification toastNotification)
		{
			_productService = productService;
			_brandService = brandService;
			_categoryServiceQuery = categoryServiceQuery;
			_toastNotification = toastNotification;
		}
		#endregion

		#region متد نمایش کلیه اطلاعات کالاها یا محصولات
		public IActionResult Index()
		{
			return View(_productService.GetProducts());
		}
		#endregion

		#region متد ثبت محصول یا کالای جدید

		[HttpGet]
		public IActionResult Create()
		{
			CreateProductViewModel createProduct = new CreateProductViewModel();
			createProduct.GetCategories = _categoryServiceQuery.GetCategories();
			createProduct.Brands = _brandService.getBrands();
			return View(createProduct);
		}
		[HttpPost]
		public IActionResult Create(CreateProductViewModel createProduct)
		{
			if (!ModelState.IsValid)
			{
				createProduct.GetCategories = _categoryServiceQuery.GetCategories();
				createProduct.Brands = _brandService.getBrands();
				return View(createProduct);
			}

			var Result = _productService.CreateProduct(createProduct);
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

		#region متد ویرایش اطلاعات محصول یا کالا

		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindProduct = _productService.FindProductByIdForUpdate(Id);
			if (FindProduct == null)
				return NotFound();

			FindProduct.GetCategories = _categoryServiceQuery.GetCategories();
			FindProduct.Brands = _brandService.getBrands();
			return View(FindProduct);
		}
		[HttpPost]
		public IActionResult Update(UpdateProductViewModel UpdateProduct)
		{
			if (!ModelState.IsValid)
			{
				UpdateProduct.GetCategories = _categoryServiceQuery.GetCategories();
				UpdateProduct.Brands = _brandService.getBrands();
				return View(UpdateProduct);
			}

			var Result = _productService.UpdateProduct(UpdateProduct);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddInfoToastMessage("ویرایش اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = false,
				NewestOnTop = true,
				TimeOut = 2000,
				Title = "بروزرسانی...",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}

		#endregion

		#region متد حذف اطلاعات محصول یا کالا

		#endregion

		#region متد ثبت اطلاعات مربوط به توضیحات کالا یا محصولات
		[HttpGet]
		public IActionResult ProductReview(int Id)
		{
			var FindProductReview = _productService.FindProductReviewById(Id);
			if (FindProductReview == null)
				FindProductReview = FindProductReview ?? new AddOrUpdateProductReviewViewModel() { ProductId = Id };

			return View(FindProductReview);
		}

		[HttpPost]
		public IActionResult ProductReview(AddOrUpdateProductReviewViewModel orUpdateProductReview)
		{
			var Result = _productService.UpdateProductReview(orUpdateProductReview);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddSuccessToastMessage("ثبت توضیحات کالا با موفقیت انجام شد.", new ToastrOptions()
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
