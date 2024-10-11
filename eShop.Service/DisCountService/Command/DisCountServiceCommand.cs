using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer;
using eShop.Service.DisCountService.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.DisCountService.Command
{
	public class DisCountServiceCommand : IDisCountServiceCommand
	{
		#region متدهای پیکربندی تخفیفات در سیستم
		private readonly ApplicationDbContext _context;
		private readonly IDisCountServiceQuery _disCountServiceQuery;
		public DisCountServiceCommand(ApplicationDbContext context, IDisCountServiceQuery disCountServiceQuery)
		{
			_context = context;
			_disCountServiceQuery = disCountServiceQuery;
		}
		#endregion

		#region متد ثبت پیکربندی تخفیفات در سیستم
		public OperationResult CreateDisCount(CreateDisCountViewModel createDisCount)
		{
			bool Exist = _disCountServiceQuery.ExistDisCount(0, createDisCount.Code);

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
				FirstOrder = createDisCount.FirstOrder,
				FreeShipping = createDisCount.FreeShipping,
				IsPercentage = createDisCount.IsPercentage,
				Value = createDisCount.Value,
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

		#region متد عملیاتی جهت بروزرسانی کد تخفیف
		public OperationResult UpdateDisCount(UpdateDisCountViewModel UpdateDiscount)
		{
			var FindDiscountCode = _disCountServiceQuery.FindDisCountById(UpdateDiscount.DiscountId);

			if (FindDiscountCode == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			bool existDiscount = _disCountServiceQuery.ExistDiscountCode(UpdateDiscount.Code, UpdateDiscount.DiscountId);
			if (existDiscount)
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};

			FindDiscountCode.Code = UpdateDiscount.Code;
			FindDiscountCode.UserCount = UpdateDiscount.UserCount;
			FindDiscountCode.IsActive = UpdateDiscount.IsActive;
			//FindDiscountCode.StartDisCount = UpdateDiscount.StartDisCount;
			//FindDiscountCode.EndDisCount = UpdateDiscount.EndDisCount;
			FindDiscountCode.LastModified = DateTime.Now;

			_context.TBL_DisCounts.Update(FindDiscountCode);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create
			};
		}
		#endregion

		#region متد عملیاتی جهت حذف کد تخفیف
		public OperationResult RemoveDisCount(RemoveDisCountViewModel RemoveDisCount)
		{
			var FindDiscounts = _disCountServiceQuery.FindDisCountById(RemoveDisCount.DisCountId);

			if (FindDiscounts == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			//FindDiscounts.RemoveDate = DateTime.Now;
			//FindDiscounts.IsRemove = true;

			_context.TBL_DisCounts.Remove(FindDiscounts);
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
