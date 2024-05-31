using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer;
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
				CloseButton = true,
				NewestOnTop = true,
				TimeOut = 2000,
				Title = "موفق",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
