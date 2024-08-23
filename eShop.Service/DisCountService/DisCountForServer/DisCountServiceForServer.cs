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
		#region متدهای پیکربندی تخفیفات در سیستم
		private readonly ApplicationDbContext _context;
		public DisCountServiceForServer(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد ثبت پیکربندی تخفیفات در سیستم

		public OperationResult CreateDisCount(CreateDisCountViewModel createDisCount)
		{
			bool Exist = ExistDisCount(0, createDisCount.Code);

			if (Exist)
			{
				return new OperationResult()
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};
			}

			TBL_DisCount disCount = new TBL_DisCount()
			{
				Code = createDisCount.Code,
				CreationDate = DateTime.Now,
				IsActive = createDisCount.IsActive,
				UserCount = createDisCount.UserCount,
				StartDisCount = createDisCount.StartDisCount.ShamsiToMiladi(),
				EndDisCount = createDisCount.EndDisCount.ShamsiToMiladi(),
			};

			_context.TBL_DisCounts.Add(disCount);
			_context.SaveChanges();

			return new OperationResult()
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
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

		#region ID متد جستجوی کد های تخفیف بر اساس 
		//public TBL_DisCount FindDisCountById(int DiscountId)
		//{
		//	return _context.TBL_DisCounts
		//		.Where(x => x.Id == DiscountId)
		//		//.AsNoTracking()
		//		.FirstOrDefault();
		//}
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

		#region جهت بروزرسانی کد تخفیف ID متد جستجوی کد های تخفیف بر اساس

		public UpdateDisCountViewModel FindWarrantyByIdForUpdate(int DisCountId)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region متد عملیاتی جهت بروزرسانی کد تخفیف

		public OperationResult UpdateDisCount(UpdateDisCountViewModel UpdateDisCount)
		{
			throw new NotImplementedException();
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
				})
				.SingleOrDefault();
		}
		#endregion

		#region متد عملیاتی جهت حذف کد تخفیف
		public OperationResult RemoveDisCount(RemoveDisCountViewModel RemoveDisCount)
		{
			var FindDiscounts = FindDisCountById(RemoveDisCount.DisCountId);

			if (FindDiscounts == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			FindDiscounts.RemoveDate = DateTime.Now;
			FindDiscounts.IsRemove = true;

			_context.TBL_DisCounts.Update(FindDiscounts);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Remove
			};
		}
		#endregion
	}
}
