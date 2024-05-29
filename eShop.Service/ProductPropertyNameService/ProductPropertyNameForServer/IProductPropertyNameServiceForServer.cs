using eShop.Common.Operations;
using eShop.Data.ViewModels.ProductPropertyNameViewModels.ProductPropertyNameVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductPropertyNameService.ProductPropertyNameForServer
{
	public interface IProductPropertyNameServiceForServer
	{
		List<GetProductPropertyNamesViewModel> GetProductPropertyNames();
		OperationResult CreateProductPropertyName(CreateProductPropertyNameViewModel propertyName);
	}
}
