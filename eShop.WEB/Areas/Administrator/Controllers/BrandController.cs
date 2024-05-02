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

		#region متد بروزرسانی اطلاعات برند
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindBrand = _brandsService.FindBrandByIdForUpdate(Id);

			if (FindBrand == null)
				return NotFound();

			return View(FindBrand);
		}

		[HttpPost]
		public IActionResult Update(UpdateBrandViewModel UpdateBrand)
		{
			var Result = _brandsService.UpdateBrand(UpdateBrand);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region متد حذف اطلاعات برند 
		[HttpGet]
		public IActionResult Remove(int Id)
		{
			//return PartialView("_ModalDeleteBrand", _brandsService.FindBrandByIdForRemove(Id));

			var FindBrand = _brandsService.FindBrandByIdForRemove(Id);

			if (FindBrand == null)
				return NotFound();

			return View(FindBrand);
		}

		[HttpPost]
		public IActionResult Remove(RemoveBrandViewModel RemoveBrand)
		{
			var Result = _brandsService.RemoveBrand(RemoveBrand);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
