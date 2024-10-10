using eShop.Common.Operations;
using eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.CategoryService.Command
{
	public interface ICategoryServiceCommand
	{
		OperationResult<int> CreateCategory(CreateCategoryViewModel createCategory);
		OperationResult<int> UpdateCategory(UpdateCategoryViewModel updateCategory);
		OperationResult RemoveCategory(RemoveCategoryViewModel RemoveCategory);
		OperationResult AddOrUpdateParentCategory(AddOrUpdateParentCategoryViewModel addOrUpdate);
	}
}
