using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer;
using eShop.Data.ViewModels.DisCountsViewModels.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.DisCountService.Query
{
	public class DisCountServiceQuery : IDisCountServiceQuery
	{
		#region متدهای پیکربندی تخفیفات در سیستم
		private readonly ApplicationDbContext _context;
		public DisCountServiceQuery(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد نمایش کلیه لیست ها و اطلاعات تخفیف در سیستم
		public List<GetDisCountsViewModel> GetDisCounts()
		{
			return _context.TBL_DisCounts
				.Select(d => new GetDisCountsViewModel
				{
					Code = d.Code,
					DisCountId = d.Id,
					EndDisCount = d.EndDisCount,
					IsActive = d.IsActive,
					StartDisCount = d.StartDisCount,
					UserCount = d.UserCount,

				})
				.AsNoTracking()
				.ToList();
		}
		#endregion

		#region متد موجود بودن کد تخفیف در سیستم جهت عملیات در سیستم
		public bool ExistDisCount(int DisCountId, string Code)
		{
			return _context.TBL_DisCounts
				.Any(x => x.Id != DisCountId && x.Code == Code);
		}
		#endregion

		#region ID متد جستجوی کد تخفیف بر اساس مقدار 
		public TBL_DisCount FindDisCountById(int discountId)
		{
			return _context.TBL_DisCounts
				.Where(w => w.Id == discountId)
				.AsNoTracking()
			.FirstOrDefault();
		}
		#endregion

		#region متد مربوط به محاسبه کد های تخفیف در هنگام تکمیل و ثبت سفارش محصول
		public DiscountCalculationViewModel DiscountCalculation(string disCount, int UserId)
		{
			var FindUserCart = _context.TBL_ProductCarts
				.Where(x => x.UserId.Equals(UserId))
				.ToList();

			var ActiveCart = FindUserCart
				.Where(x => x.OrderType == OrderType.Product_selection)
				.FirstOrDefault();

			var FindDisCount = _context.TBL_DisCounts
							.Where(x => x.Code.Equals(disCount))
							.Select(x => new DiscountCalculationViewModel
							{
								Code = x.Code,
								FirstOrder = x.FirstOrder,
								FreeShipping = x.FreeShipping,
								IsActive = x.IsActive,
								IsPercentage = x.IsPercentage,
								Value = x.Value,
								EndDisCount = x.EndDisCount,
								StartDisCount = x.StartDisCount,
							})
			.FirstOrDefault();

			if (FindDisCount == null)
				return new DiscountCalculationViewModel
				{
					Message = "کد تخفیف وارد شده نا معتبر است",
				};

			if (FindUserCart.Count() > 0)
			{
				bool check = FindUserCart.Any(x => x.DisCountId.Equals(FindDisCount.FirstOrder));
				if (check)
				{
					return new DiscountCalculationViewModel
					{
						Message = "این کد تخفیف فقط برای سفارش اول می باشد.",
					};
				}
			}

			if (FindDisCount.IsActive == false)
				return new DiscountCalculationViewModel
				{
					Message = "کد تخفیف وارد شده نا معتبر است.",
				};

			if (FindDisCount.StartDisCount > DateTime.Now.Date || FindDisCount.EndDisCount < DateTime.Now.Date)
				return new DiscountCalculationViewModel
				{
					Message = "تاریخ کد تخفیف به اتمام رسیده است.",
				};

			if (FindDisCount.IsPercentage)
			{
				var spacialPrice = (ActiveCart.SumOrder - ((ActiveCart.SumOrder * FindDisCount.Value) / 100));
				FindDisCount.SpecialPrice = spacialPrice;
			}
			else
			{
				var SumOrder = ActiveCart.SumOrder - FindDisCount.Value;
				FindDisCount.SpecialPrice = SumOrder;
			}

			FindDisCount.Message = "کد تخفیف با موفقیت ثبت و اعمال شد.";
			return FindDisCount;
		}
		#endregion

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

		public bool ExistDiscountCode(string discountCodeName, int discountId)
		{
			return _context.TBL_DisCounts
				.Any(x => x.Code == discountCodeName.Trim().ToLower() && x.Id != discountId);
		}
		#endregion
	}
}
