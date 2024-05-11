using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using eShop.Data.ViewModels.WarrantiesViewModels.WarrantiesVMServer;
using eShop.Service.BrandsService.BrandsForServer;
using eShop.Service.WarrantyService.WarrantyForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class WarrantyController : BaseAdminController
	{
		#region متد سرویس های گارانتی
		private readonly IWarrantiesServiceForServer _warrantiesService;
		public WarrantyController(IWarrantiesServiceForServer warrantiesService)
        {
			_warrantiesService = warrantiesService;
        }
		#endregion

		#region متد نمایش لیست کلیه گارانتی ها
		public IActionResult Index()
		{
			return View(_warrantiesService.getWarranties());
		}
		#endregion

		#region متد ثبت اطلاعات گارانتی جدید
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateWarrantyViewModel createWarranty)
		{
			var result = _warrantiesService.CreateWarranty(createWarranty);

			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(result);
			TempData["SuccessAlert"] = "ثبت گارانتی جدید با موفقیت انجام شد";
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region متد بروزرسانی اطلاعات گارانتی
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindBrand = _warrantiesService.FindWarrantyByIdForUpdate(Id);

			if (FindBrand == null)
				return NotFound();

			return View(FindBrand);
		}

		[HttpPost]
		public IActionResult Update(UpdateWarrantyViewModel UpdateWarranty)
		{
			var Result = _warrantiesService.UpdateWarranty(UpdateWarranty);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region متد حذف اطلاعات گارانتی 
		[HttpGet]
		public IActionResult Remove(int Id)
		{
			var FindBrand = _warrantiesService.FindWarrantyByIdForRemove(Id);

			if (FindBrand == null)
				return NotFound();

			return View(FindBrand);
		}

		[HttpPost]
		public IActionResult Remove(RemoveWarrantyViewModel RemoveWarranty)
		{
			var Result = _warrantiesService.RemoveWarranty(RemoveWarranty);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
