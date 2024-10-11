using eShop.Data.Entities;
using eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer;
using eShop.Data.ViewModels.DisCountsViewModels.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.DisCountService.Query
{
	public interface IDisCountServiceQuery
	{
		List<GetDisCountsViewModel> GetDisCounts();
		TBL_DisCount FindDisCountById(int discountId);
		bool ExistDisCount(int DisCountId, string Code);
		bool ExistDiscountCode(string discountCodeName, int discountId);
		DiscountCalculationViewModel DiscountCalculation(string disCount, int UserId);
		//UpdateDisCountViewModel FindDiscountByIdForUpdate(int DiscountId);
		//RemoveDisCountViewModel FindDisCountByIdForRemove(int DiscountId);
	}
}
