using eShop.Data.Entities;
using eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer;
using eShop.Data.ViewModels.CategoriesViewModels.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.CategoryService.Query
{
	public interface ICategoryServiceQuery
	{
		List<GetCategoriesViewModel> GetCategories();
		UpdateCategoryViewModel FindCategoryByIdForUpdate(int CategoryId);
		RemoveCategoryViewModel FindCategoryByIdForRemove(int CategoryId);
		List<GetCategoriesForParentListViewModel> GetCategoriesForParentList(int SubId);
		List<GetParentCategoryForAddOrRemoveSubViewModel> GetParentCategoryForAddOrRemoveSub(int SubId);
		bool ExistCategory(int CategoryId, string FaTitle, string EnTitle);
		TBL_Category FindCategoryById(int CategoryId);
		List<TBL_SubCategory> GetAllParentBySubId(int SubId);
		List<GetCategoryForMenuViewModel> getCategoryForMenu();
	}
}
