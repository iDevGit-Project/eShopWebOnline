using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.SlidersViewModels.SlidersVMServer;
using eShop.Service.BrandsService.BrandsForServer;
using eShop.Service.SliderService.SliderForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class SliderController : BaseAdminController
	{
		#region متد سرویس های اسلایدر
		private readonly ISlidersServiceForServer _sliderService;
		public SliderController(ISlidersServiceForServer sliderService)
		{
			this._sliderService = sliderService;
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
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
