using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using eShop.Data.ViewModels.WarrantiesViewModels.WarrantiesVMServer;
using eShop.Service.BrandsService.BrandsForServer;
using eShop.Service.WarrantyService.WarrantyForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class WarrantyController : BaseAdminController
	{
		#region متد سرویس های گارانتی
		private readonly IToastNotification _toastNotification;
		private readonly IWarrantiesServiceForServer _warrantiesService;
		public WarrantyController(IWarrantiesServiceForServer warrantiesService, IToastNotification toastNotification)
        {
			_warrantiesService = warrantiesService;
			_toastNotification = toastNotification;
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
			_toastNotification.AddSuccessToastMessage("ثبت اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = true,
				NewestOnTop = true,
				TimeOut = 2000,
				Title = "ثبت",
				PositionClass = ToastPositions.TopFullWidth,
			});
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
			_toastNotification.AddInfoToastMessage("ویرایش اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = true,
				NewestOnTop = true,
				TimeOut = 2000,
				Title = "ویرایش",
				PositionClass = ToastPositions.TopFullWidth,
			});
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
			_toastNotification.AddErrorToastMessage("حذف اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = true,
				NewestOnTop = true,
				TimeOut = 2000,
				Title = "حذف",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
