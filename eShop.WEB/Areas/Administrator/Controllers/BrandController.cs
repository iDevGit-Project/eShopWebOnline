using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using eShop.Service.BrandsService.BrandsForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class BrandController : BaseAdminController
	{
		#region متد های سرویس برند
		private readonly IBrandsServiceForServer _brandsService;
		public BrandController(IBrandsServiceForServer brandsService)
        {
			this._brandsService = brandsService;
		}
		#endregion

		#region متد نمایش لیست کلیه برندها

		public IActionResult Index()
		{
			return View(_brandsService.getBrands());
		}
		#endregion

		#region متد ثبت اطلاعات برند جدید
		
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateBrandViewModel createBrand)
		{
			var result = _brandsService.CreateBrand(createBrand);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(result);
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
