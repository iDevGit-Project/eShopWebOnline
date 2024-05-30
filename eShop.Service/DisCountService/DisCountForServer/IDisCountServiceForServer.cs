using eShop.Common.Operations;
using eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.DisCountService.DisCountForServer
{
	public interface IDisCountServiceForServer
	{
		List<GetDisCountsViewModel> GetDisCounts();
		OperationResult CreateDisCount(CreateDisCountViewModel createDisCount);
	}
}
