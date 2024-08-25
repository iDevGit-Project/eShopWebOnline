using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer;
using eShop.Data.ViewModels.WarrantiesViewModels.WarrantiesVMServer;
using eShop.Service.DisCountService.DisCountForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class DisCountController : Controller
	{
		#region متدهای پیکربندی سیستم تخفیفات در فروشگاه
		private readonly IDisCountServiceForServer _disCountService;
		private readonly IToastNotification _toastNotification;
		public DisCountController(IDisCountServiceForServer disCountService, IToastNotification toastNotification)
		{
			_disCountService = disCountService;
			_toastNotification = toastNotification;
		}
		#endregion

		#region متد نمایش کلیه لیست های تخفیف در فروشگاه
		[HttpGet]
		public IActionResult Index()
		{
			return View(_disCountService.GetDisCounts());
		}

		#endregion

		#region متد ثبت اطلاعات تخفیف جدید در فروشگاه
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateDisCountViewModel createDisCount)
		{
			var Result = _disCountService.CreateDisCount(createDisCount);
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

		#region متد حذف کد های تخفیف در فروشگاه
		[HttpGet]
		public IActionResult Remove(int Id)
		{
			var FindDisCount = _disCountService.FindDisCountByIdForRemove(Id);

			if (FindDisCount == null)
				return NotFound();

			return View(FindDisCount);
		}

		[HttpPost]
		public IActionResult Remove(RemoveDisCountViewModel RemoveDisCount)
		{
			if (!ModelState.IsValid)
			{
				return View(RemoveDisCount);
			}

			var Result = _disCountService.RemoveDisCount(RemoveDisCount);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddErrorToastMessage("حذف اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = false,
				NewestOnTop = true,
				TimeOut = 2000,
				Title = "حذف...",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region متد بروزرسانی کدهای تخفیف در فروشگاه
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindBrand = _disCountService.FindDiscountByIdForUpdate(Id);

			if (FindBrand == null)
				return NotFound();

			return View(FindBrand);
		}

		[HttpPost]
		public IActionResult Update(UpdateDisCountViewModel UpdateDisCount)
		{
			var Result = _disCountService.UpdateDisCount(UpdateDisCount);
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
	}
}
