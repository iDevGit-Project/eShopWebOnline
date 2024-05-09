using eShop.Common.Operations;
using eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.CategoryService.CategoryForServer
{
	public interface ICategoriesServiceForServer
	{
		List<GetCategoriesViewModel> GetCategories();
		OperationResult<int> CreateCategory(CreateCategoryViewModel createCategory);
		UpdateCategoryViewModel FindCategoryByIdForUpdate(int CategoryId);
		OperationResult<int> UpdateCategory(UpdateCategoryViewModel updateCategory);
		RemoveCategoryViewModel FindCategoryByIdForRemove(int CategoryId);
		OperationResult RemoveCategory(RemoveCategoryViewModel RemoveCategory);
		OperationResult AddOrUpdateParentCategory(AddOrUpdateParentCategoryViewModel addOrUpdate);
		List<GetCategoriesForParentListViewModel> GetCategoriesForParentList(int SubId);
		List<GetParentCategoryForAddOrRemoveSubViewModel> GetParentCategoryForAddOrRemoveSub(int SubId);
	}

}
