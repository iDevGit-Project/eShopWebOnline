using eShop.Core.ExtentionMethods;
using eShop.Service.BrandsService.BrandsForServer;
using eShop.Service.ProductGalleryService.ProductGalleryForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
    [Area(nameof(Administrator))]
	public class ProductGalleryController : BaseAdminController
	{
		#region متد های سرویس گالری تصاویر محصولات
		private readonly IProductGalleryServiceForServer _productGalleryService;
		private readonly IToastNotification _toastNotification;
		public ProductGalleryController(IProductGalleryServiceForServer productGalleryService, IToastNotification toastNotification)
		{
			_productGalleryService = productGalleryService;
			_toastNotification = toastNotification;
		}
		#endregion

		#region متد نمایش لیست کلیه گالری تصاویر محصولات
		[HttpGet]
		public IActionResult Index(int Id)
		{
			TempData[TempDataName.ProductId] = Id;
			return View(_productGalleryService.getImageGalleryForProductById(Id));
		}
		#endregion

		#region متد ثبت اطلاعات گالری تصاویر محصولات
		[HttpPost]
		public IActionResult Create(int ProductId, IFormFile ImgName)
		{
			var Result = _productGalleryService.CreateImageForProductGallery(ProductId, ImgName);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			return RedirectToAction(nameof(Index), new { Id = ProductId });
		}
		#endregion
	}
}
