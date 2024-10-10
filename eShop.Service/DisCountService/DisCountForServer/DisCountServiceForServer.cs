using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer;
using eShop.Data.ViewModels.WarrantiesViewModels.WarrantiesVMServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.DisCountService.DisCountForServer
{
	public class DisCountServiceForServer : IDisCountServiceForServer
	{



		#region جهت بروزرسانی کد تخفیف ID متد جستجوی کد های تخفیف بر اساس
		public UpdateDisCountViewModel FindDiscountByIdForUpdate(int DiscountId)
		{
			return _context.TBL_DisCounts
				.Where(d => d.Id == DiscountId)
				.Select(d => new UpdateDisCountViewModel
				{
					DiscountId = d.Id,
					Code = d.Code,
					IsActive = d.IsActive,
					UserCount = d.UserCount,
					StartDisCount = d.StartDisCount,
					EndDisCount = d.EndDisCount,
				})
				.AsNoTracking()
				.SingleOrDefault();
		}
		#endregion

		#region متد موجود بودن کد تخفیف در سمت سرور و عملیات بر روی آن
		public bool ExistDiscountCode(string discountCodeName, int discountId)
		{
			return _context.TBL_DisCounts.Any(x => x.Code == discountCodeName.Trim().ToLower() && x.Id != discountId
			);
		}
		#endregion

		#region جهت حذف کد تخفیف ID متد جستجوی کد های تخفیف بر اساس
		public RemoveDisCountViewModel FindDisCountByIdForRemove(int DiscountId)
		{
			return _context.TBL_DisCounts

				.Where(d => d.Id == DiscountId)
				.Select(d => new RemoveDisCountViewModel
				{
					DisCountId = d.Id,
					Code = d.Code,
					EndDisCount = d.EndDisCount,
					StartDisCount = d.StartDisCount,
					IsActive = d.IsActive,
					UserCount = d.UserCount,
				})
				.AsNoTracking()
				.SingleOrDefault();
		}
		#endregion


	}
}
