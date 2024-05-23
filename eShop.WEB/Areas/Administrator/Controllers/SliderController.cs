using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.SlidersViewModels.SlidersVMServer;
using eShop.Service.BrandsService.BrandsForServer;
using eShop.Service.SliderService.SliderForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class SliderController : BaseAdminController
	{
		#region متد سرویس های اسلایدر
		private readonly ISlidersServiceForServer _sliderService;
		private readonly IToastNotification _toastNotification;
		public SliderController(ISlidersServiceForServer sliderService, IToastNotification toastNotification)
		{
			this._sliderService = sliderService;
			_toastNotification = toastNotification;
		}
		#endregion

		#region متد نمایش لیست اسلایدرها

		public IActionResult Index()
		{
			return View(_sliderService.GetSliders());
		}
		#endregion

		#region  متد ثبت اسلایدر جدید
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateSliderViewModel createSlider)
		{
			var Result = _sliderService.CreateSlider(createSlider);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddSuccessToastMessage("ثبت اطلاعات با موفقیت انجام شد", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = true,
				NewestOnTop = true,
				Debug = false,
				TimeOut = 2000,
				Title = "موفق",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region متد بروزرسانی اسلایدرها
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindBrand = _sliderService.FindSliderByIdForUpdate(Id);

			if (FindBrand == null)
				return NotFound();

			return View(FindBrand);
		}

		[HttpPost]
		public IActionResult Update(UpdateSliderViewModel UpdateSlider)
		{
			var Result = _sliderService.UpdateSlider(UpdateSlider);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddInfoToastMessage("ویرایش اطلاعات با موفقیت انجام شد", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = true,
				NewestOnTop = true,
				Debug = false,
				Title = "ویرایش",
				TimeOut = 2000,
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region متد حذف اسلایدرها
		[HttpGet]
		public IActionResult Remove(int Id)
		{
			var FindBrand = _sliderService.FindSliderByIdForRemove(Id);

			if (FindBrand == null)
				return NotFound();

			return View(FindBrand);
		}

		[HttpPost]
		public IActionResult Remove(RemoveSliderViewModel RemoveSlider)
		{
			var Result = _sliderService.RemoveSlider(RemoveSlider);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddErrorToastMessage("حذف اطلاعات با موفقیت انجام شد", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = true,
				NewestOnTop = true,
				Debug = false,
				Title = "حذف",
				TimeOut = 2000,
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
