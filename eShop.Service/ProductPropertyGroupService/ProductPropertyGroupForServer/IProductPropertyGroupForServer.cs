using eShop.Common.Operations;
using eShop.Data.ViewModels.ProductPropertyGroupViewModels.ProductPropertyGroupVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductPropertyGroupService.ProductPropertyGroupForServer
{
	public interface IProductPropertyGroupForServer
	{
		List<GetPropertyGroupsViewModel> GetProductPropertyGroups();
		OperationResult CreateProductPropertyGroups(CreatePropertyGroupViewModel propertyGroups);
	}
}
