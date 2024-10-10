using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer;
using eShop.Service.CategoryService.Command;
using eShop.Service.CategoryService.Query;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class CategoryController : BaseAdminController
	{
		#region متد سرویس های دسته بندی ها و زیردسته ها

		private readonly ICategoryServiceQuery _categoryServiceQuery;
		private readonly ICategoryServiceCommand _categoryServiceCommand;
		private readonly IToastNotification _toastNotification;

		public CategoryController(ICategoryServiceQuery categoryServiceQuery,
			ICategoryServiceCommand categoryServiceCommand, IToastNotification toastNotification)
		{
			_categoryServiceQuery = categoryServiceQuery;
			_categoryServiceCommand = categoryServiceCommand;
			_toastNotification = toastNotification;
		}
		#endregion

		#region متد نمایش لیست کلیه دسته بندی ها

		[HttpGet]
		public IActionResult Index()
		{
			return View(_categoryServiceQuery.GetCategories());
		}
		#endregion

		#region متد ثبت دسته بندی جدید
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.ParentList = _categoryServiceQuery.GetCategoriesForParentList(0);
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateCategoryViewModel createCategory)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.ParentList = _categoryServiceQuery.GetCategoriesForParentList(0);
				return View();
			}


			var Result = _categoryServiceCommand.CreateCategory(createCategory);

			if (Result.IsSuccess && createCategory.addOrUpdateParent != null)
			{
				createCategory.addOrUpdateParent.SubId = Result.Data;
				var ResultParent = _categoryServiceCommand.AddOrUpdateParentCategory(createCategory.addOrUpdateParent);
				TempData[TempDataName.ResultParentTempdata] = JsonConvert.SerializeObject(ResultParent);
			}

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

		#region متد بروزرسانی دسته بندی ها
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindCategory = _categoryServiceQuery.FindCategoryByIdForUpdate(Id);

			if (FindCategory == null)
				return NotFound();

			ViewBag.Parents = _categoryServiceQuery.GetParentCategoryForAddOrRemoveSub(Id);
			ViewBag.ParentList = _categoryServiceQuery.GetCategoriesForParentList(Id);
			return View(FindCategory);
		}

		[HttpPost]
		public IActionResult Update(UpdateCategoryViewModel UpdateCategory)
		{
			var Result = _categoryServiceCommand.UpdateCategory(UpdateCategory);

			if (Result.IsSuccess)
			{
				UpdateCategory.addOrUpdateParent = UpdateCategory.addOrUpdateParent ?? new AddOrUpdateParentCategoryViewModel();
				UpdateCategory.addOrUpdateParent.SubId = Result.Data;
				var ResultParent = _categoryServiceCommand.AddOrUpdateParentCategory(UpdateCategory.addOrUpdateParent);
				TempData[TempDataName.ResultParentTempdata] = JsonConvert.SerializeObject(ResultParent);
			}

			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			_toastNotification.AddInfoToastMessage("ویرایش اطلاعات با موفقیت انجام شد.", new ToastrOptions()
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

		#region متد حذف دسته بندی ها به صورت نمایش فرم
		[HttpGet]
		public IActionResult Remove(int Id)
		{
			var FindCategory = _categoryServiceQuery.FindCategoryByIdForRemove(Id);

			if (FindCategory == null)
				return NotFound();

			return View(FindCategory);
		}

		[HttpPost]
		public IActionResult Remove(RemoveCategoryViewModel RemoveCategory)
		{
			var Result = _categoryServiceCommand.RemoveCategory(RemoveCategory);
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

		#region متد حذف دسته بندی ها به صورت نمایش فرم مودال
		//[HttpGet]
		//public IActionResult Remove()
		//{
		//	return PartialView(FindCategory);
		//}
		#endregion

	}
}
