using eShop.Common.Operations;
using eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.DisCountService.Command
{
	public interface IDisCountServiceCommand
	{
		OperationResult CreateDisCount(CreateDisCountViewModel createDisCount);
		OperationResult UpdateDisCount(UpdateDisCountViewModel UpdateDiscount);
		OperationResult RemoveDisCount(RemoveDisCountViewModel RemoveDisCount);
	}
}
