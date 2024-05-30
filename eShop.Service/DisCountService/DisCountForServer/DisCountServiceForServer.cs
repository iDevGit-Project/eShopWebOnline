using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer;
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
		public TBL_DisCount FindDisCountById(int DiscountId)
		{
			return _context.TBL_DisCounts.Where(x => x.Id == DiscountId)
				.FirstOrDefault();
		}
		#endregion

		#region متد موجود بودن کد تخفیف در سیستم
		public bool ExistDisCount(int DisCountId, string Code)
		{
			return _context.TBL_DisCounts
				.Any(x => x.Id != DisCountId && x.Code == Code);
		}
		#endregion
	}
}
