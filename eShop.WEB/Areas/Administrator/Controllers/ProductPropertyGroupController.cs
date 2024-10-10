using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.ProductPropertyGroupViewModels.ProductPropertyGroupVMServer;
using eShop.Service.ProductPropertyGroupService.ProductPropertyGroupForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class ProductPropertyGroupController : BaseAdminController
	{
		#region متد های سرویس گروه بندی اطلاعات کالا یا محصولات 
		private readonly IProductPropertyGroupServiceForServer _propertyGroupService;
		private readonly IToastNotification _toastNotification;

		public ProductPropertyGroupController(IProductPropertyGroupServiceForServer propertyGroupService, IToastNotification toastNotification)
		{
			_propertyGroupService = propertyGroupService;
			_toastNotification = toastNotification;
		}
		#endregion

		#region متد های نمایش کلیه اطلاعات گروه بندی کالا یا محصولات
		public IActionResult Index()
		{
			return View(_propertyGroupService.GetProductPropertyGroups());
		}

		#endregion

		#region متد ثبت اطلاعات گروه بندی کالا یا محصولات

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreatePropertyGroupViewModel propertyGroup)
		{
			var Result = _propertyGroupService.CreateProductPropertyGroups(propertyGroup);
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

		#region متد ویرایش اطلاعات گروه بندی کالا یا محصولات
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindPPG = _propertyGroupService.FindProductPropertyGroupByIdForUpdate(Id);

			if (FindPPG == null)
				return NotFound();

			return View(FindPPG);
		}

		[HttpPost]
		public IActionResult Update(UpdateProductPropertyGroupViewModel UpdateTitle)
		{
			var Result = _propertyGroupService.UpdateProductPropertyGroup(UpdateTitle);
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

		#region  متد حذف اطلاعات گروه بندی کالا یا محصولات
		//[HttpGet]
		//public IActionResult Remove(int Id)
		//{
		//	var FindPPG = _propertyGroupService.FindProductPropertyGroupByIdForRemove(Id);

		//	if (FindPPG == null)
		//		return NotFound();

		//	return View(FindPPG);
		//}

		//[HttpPost]
		//public IActionResult Remove(RemoveProductPropertyGroupViewModel RemoveTitle)
		//{
		//	var Result = _propertyGroupService.RemoveProductPropertyGroup(RemoveTitle);
		//	TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
		//	_toastNotification.AddErrorToastMessage("حذف اطلاعات با موفقیت انجام شد.", new ToastrOptions()
		//	{
		//		ProgressBar = true,
		//		CloseButton = true,
		//		NewestOnTop = true,
		//		TimeOut = 2000,
		//		Title = "حذف",
		//		PositionClass = ToastPositions.TopFullWidth,
		//	});
		//	return RedirectToAction(nameof(Index));
		//}
		#endregion
	}
}
