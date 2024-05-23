using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.ColorsViewModels;
using eShop.Service.ColorService.ColorForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class ColorController : BaseAdminController
	{
		#region Color متد سرویس های 
		private readonly IToastNotification _toastNotification;
		private readonly IColorsServiceForServer _colorsServiceForServer;
        public ColorController(IToastNotification toastNotification, IColorsServiceForServer colorsServiceForServer)
        {
			_toastNotification = toastNotification;
			_colorsServiceForServer = colorsServiceForServer;
        }
		#endregion

		#region در سیستم Color متد نمایش لیست 

		[HttpGet]
        public IActionResult Index()
		{
			return View(_colorsServiceForServer.GetColors());
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

			var Result = _colorsServiceForServer.CreateColor(createColor);
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

		#region Color متد ویرایش اطلاعات
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindColor = _colorsServiceForServer.FindColorByIdForUpdate(Id);

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

			var Result = _colorsServiceForServer.UpdateColor(UpdateColor);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddInfoToastMessage(".ویرایش اطلاعات با موفقیت انجام شد", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = true,
				NewestOnTop = true,
				Debug = false,
				TimeOut = 2000,
				Title = "ویرایش",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region Color متد حذف 
		[HttpGet]
		public IActionResult Remove(int Id)
		{
			var FindColor = _colorsServiceForServer.FindColorByIdForRemove(Id);

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

			var Result = _colorsServiceForServer.RemoveColor(RemoveColor);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddErrorToastMessage("حذف اطلاعات با موفقیت انجام شد", new ToastrOptions()
			{
				ProgressBar = true,
				CloseButton = true,
				NewestOnTop = true,
				Debug = false,
				TimeOut = 2000,
				Title = "حذف",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
