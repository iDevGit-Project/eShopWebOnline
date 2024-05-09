using eShop.Core.ExtentionMethods;
using eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer;
using eShop.Service.CategoryService.CategoryForServer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShop.WEB.Areas.Administrator.Controllers
{
	[Area(nameof(Administrator))]
	public class CategoryController : BaseAdminController
	{
		#region متد سرویس های دسته بندی ها و زیردسته ها

		private readonly ICategoriesServiceForServer _categoryService;
		public CategoryController(ICategoriesServiceForServer categoryService)
		{
			this._categoryService = categoryService;
		}
		#endregion

		#region متد نمایش لیست کلیه دسته بندی ها

		[HttpGet]
		public IActionResult Index()
		{
			return View(_categoryService.GetCategories());
		}
		#endregion

		#region متد ثبت دسته بندی جدید
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.ParentList = _categoryService.GetCategoriesForParentList(0);
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateCategoryViewModel createCategory)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.ParentList = _categoryService.GetCategoriesForParentList(0);
				return View();
			}


			var Result = _categoryService.CreateCategory(createCategory);

			if (Result.IsSuccess && createCategory.addOrUpdateParent != null)
			{
				createCategory.addOrUpdateParent.SubId = Result.Data;
				var ResultParent = _categoryService.AddOrUpdateParentCategory(createCategory.addOrUpdateParent);
				TempData[TempDataName.ResultParentTempdata] = JsonConvert.SerializeObject(ResultParent);
			}

			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region متد بروزرسانی دسته بندی ها
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var FindCategory = _categoryService.FindCategoryByIdForUpdate(Id);

			if (FindCategory == null)
				return NotFound();

			ViewBag.Parents = _categoryService.GetParentCategoryForAddOrRemoveSub(Id);
			ViewBag.ParentList = _categoryService.GetCategoriesForParentList(Id);
			return View(FindCategory);
		}

		[HttpPost]
		public IActionResult Update(UpdateCategoryViewModel UpdateCategory)
		{
			var Result = _categoryService.UpdateCategory(UpdateCategory);

			if (Result.IsSuccess)
			{
				UpdateCategory.addOrUpdateParent = UpdateCategory.addOrUpdateParent ?? new AddOrUpdateParentCategoryViewModel();
				UpdateCategory.addOrUpdateParent.SubId = Result.Data;
				var ResultParent = _categoryService.AddOrUpdateParentCategory(UpdateCategory.addOrUpdateParent);
				TempData[TempDataName.ResultParentTempdata] = JsonConvert.SerializeObject(ResultParent);
			}

			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			return RedirectToAction(nameof(Index));
		}
		#endregion

		#region متد حذف دسته بندی ها
		[HttpGet]
		public IActionResult Remove(int Id)
		{
			var FindCategory = _categoryService.FindCategoryByIdForRemove(Id);

			if (FindCategory == null)
				return NotFound();

			return View(FindCategory);
		}

		[HttpPost]
		public IActionResult Remove(RemoveCategoryViewModel RemoveCategory)
		{
			var Result = _categoryService.RemoveCategory(RemoveCategory);
			TempData[TempDataName.ResultTempdata] = JsonConvert.SerializeObject(Result);
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
