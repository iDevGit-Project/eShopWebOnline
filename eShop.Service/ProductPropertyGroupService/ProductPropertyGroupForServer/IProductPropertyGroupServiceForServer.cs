using eShop.Common.Operations;
using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using eShop.Data.ViewModels.ProductPropertyGroupViewModels.ProductPropertyGroupVMServer;
using eShop.Data.ViewModels.WarrantiesViewModels.WarrantiesVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductPropertyGroupService.ProductPropertyGroupForServer
{
	public interface IProductPropertyGroupServiceForServer
	{
		List<GetPropertyGroupsViewModel> GetProductPropertyGroups();
		OperationResult CreateProductPropertyGroups(CreatePropertyGroupViewModel propertyGroups);
		UpdateProductPropertyGroupViewModel FindProductPropertyGroupByIdForUpdate(int TitleId);
		OperationResult UpdateProductPropertyGroup(UpdateProductPropertyGroupViewModel UpdateTitle);
		//RemoveProductPropertyGroupViewModel FindProductPropertyGroupByIdForRemove(int TitleId);
		//OperationResult RemoveProductPropertyGroup(RemoveProductPropertyGroupViewModel RemoveTitle);
	}
}
