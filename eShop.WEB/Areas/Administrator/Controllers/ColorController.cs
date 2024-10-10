using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.ColorsViewModels.ColorsVMServer;
using eShop.Service.ColorService.Command;
using eShop.Service.ColorService.Query;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
    [Area(nameof(Administrator))]
	public class ColorController : BaseAdminController
	{
		#region Color متد سرویس های 
		private readonly IColorServiceQuery _colorServiceQuery;
		private readonly IColorServiceCommand _colorServiceCommand;
		private readonly IToastNotification _toastNotification;
		public ColorController(IToastNotification toastNotification, IColorServiceQuery colorServiceQuery, IColorServiceCommand colorServiceCommand)
        {
			_toastNotification = toastNotification;
			_colorServiceQuery = colorServiceQuery;
			_colorServiceCommand = colorServiceCommand;
        }
		#endregion

		#region در سیستم Color متد نمایش لیست 

		[HttpGet]
        public IActionResult Index()
		{
			return View(_colorServiceQuery.GetColors());
		}

		#endregion

		#region جدید Color متد ثبت 
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateColorViewModel createColor)
		{
			if (!ModelState.IsValid)
			{
				return View(createColor);
			}

			var Result = _colorServiceCommand.CreateColor(createColor);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddSuccessToastMessage("ثبت اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = false,
				NewestOnTop = true,
				Debug = false,
				TimeOut = 2000,
				Title = "موفق...",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region Color متد ویرایش اطلاعات
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindColor = _colorServiceQuery.FindColorByIdForUpdate(Id);

			if (FindColor == null)
				return NotFound();

			return View(FindColor);
		}

		[HttpPost]
		public IActionResult Update(UpdateColorViewModel UpdateColor)
		{
			if (!ModelState.IsValid)
			{
				return View(UpdateColor);
			}

			var Result = _colorServiceCommand.UpdateColor(UpdateColor);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddInfoToastMessage(".ویرایش اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = false,
				NewestOnTop = true,
				Debug = false,
				TimeOut = 2000,
				Title = "بروزرسانی...",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region Color متد حذف 
		[HttpGet]
		public IActionResult Remove(int Id)
		{
			var FindColor = _colorServiceQuery.FindColorByIdForRemove(Id);

			if (FindColor == null)
				return NotFound();

			return View(FindColor);
		}

		[HttpPost]
		public IActionResult Remove(RemoveColorViewModel RemoveColor)
		{
			if (!ModelState.IsValid)
			{
				return View(RemoveColor);
			}

			var Result = _colorServiceCommand.RemoveColor(RemoveColor);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddErrorToastMessage("حذف اطلاعات با موفقیت انجام شد.", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = false,
				NewestOnTop = true,
				Debug = false,
				TimeOut = 2000,
				Title = "حذف...",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
