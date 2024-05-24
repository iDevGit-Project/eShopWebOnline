using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.ProductPropertyGroupViewModels.ProductPropertyGroupVMServer;
using eShop.Service.BrandsService.BrandsForServer;
using eShop.Service.CategoryService.CategoryForServer;
using eShop.Service.ProductPropertyGroupService.ProductPropertyGroupForServer;
using eShop.Service.ProductService.ProductForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class ProductPropertyGroupController : BaseAdminController
	{
		#region متد های سرویس گروه بندی اطلاعات کالا یا محصولات 
		private readonly IProductPropertyGroupForServer _propertyGroupService;
		private readonly IToastNotification _toastNotification;

		public ProductPropertyGroupController(IProductPropertyGroupForServer propertyGroupService, IToastNotification toastNotification)
		{
			_propertyGroupService = propertyGroupService;
			_toastNotification = toastNotification;
		}
		#endregion

		#region متد های نمایش کلیه اطلاعات گروه بندی اطلاعات کالا یا محصولات
		public IActionResult Index()
		{
			return View(_propertyGroupService.GetProductPropertyGroups());
		}

		#endregion

		#region متد ثبت اطلاعات گروه بندی اطلاعات کالا یا محصولات

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
				CloseButton = true,
				NewestOnTop = true,
				TimeOut = 2000,
				Title = "ثبت",
				PositionClass = ToastPositions.TopFullWidth,
			});
			return RedirectToAction(nameof(Create));
		}
		#endregion
	}
}
