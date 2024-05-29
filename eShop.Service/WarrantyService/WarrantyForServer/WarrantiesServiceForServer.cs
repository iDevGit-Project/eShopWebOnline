using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using eShop.Data.ViewModels.WarrantiesViewModels.WarrantiesVMServer;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.WarrantyService.WarrantyForServer
{
	public class WarrantiesServiceForServer : IWarrantiesServiceForServer
	{
		#region متد های پیکربندی اطلاعات گارانتی در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
		public WarrantiesServiceForServer(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد نمایش تمام گارانتی های فروشگاه در سمت سرور یا مدیرسایت

		public List<GetWarrantiesViewModel> getWarranties()
		{
			return _context.TBL_Warranties

				.Select(w => new GetWarrantiesViewModel
				{
					WarrantyId = w.Id,
					WarrantyName = w.WarrantyName,
				})
				.AsNoTracking()
				.ToList();
		}
		#endregion

		#region متد عملیاتی ثبت گارانتی جدید
		public OperationResult<int> CreateWarranty(CreateWarrantyViewModel createWarranty)
		{
			bool existWarranty = this.ExistWarranty(createWarranty.WarrantyName, 0);

			if (existWarranty)
			{
				return new OperationResult<int>
				{
					Data = 0,
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};
			}


			TBL_Warranty newDataWarranty = new TBL_Warranty()
			{
				CreationDate = DateTime.Now,
				WarrantyName = createWarranty.WarrantyName
			};

			_context.TBL_Warranties.Add(newDataWarranty);
			_context.SaveChanges();

			return new OperationResult<int>
			{
				Code = OperationCode.Success,
				Data = newDataWarranty.Id,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion

		#region جهت عملیات بروزرسانی ID متد جستجوی گارانتی بر اساس 
		public UpdateWarrantyViewModel FindWarrantyByIdForUpdate(int warrantyId)
		{
			return _context.TBL_Warranties

				.Where(w => w.Id == warrantyId)
				.Select(w => new UpdateWarrantyViewModel
				{
					WarrantyId = w.Id,
					WarrantyName = w.WarrantyName,
				})
				.SingleOrDefault();
		}
		#endregion
		
		#region ID متد جستجوی گارانتی بر اساس مقدار 

		public TBL_Warranty FindWarrantyById(int warrantyId)
		{
			return _context.TBL_Warranties
				.Where(w => w.Id == warrantyId)
				.AsNoTracking()
				.FirstOrDefault();
		}
		#endregion

		#region متد عملیاتی بروزرسانی اطلاعات گارانتی
		public OperationResult UpdateWarranty(UpdateWarrantyViewModel UpdateWarranty)
		{
			var FindWarranty = FindWarrantyById(UpdateWarranty.WarrantyId);

			if (FindWarranty == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			bool existWarranty = ExistWarranty(UpdateWarranty.WarrantyName, UpdateWarranty.WarrantyId);
			if (existWarranty)
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};

			FindWarranty.WarrantyName = UpdateWarranty.WarrantyName;
			FindWarranty.LastModified = DateTime.Now;

			_context.TBL_Warranties.Update(FindWarranty);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create
			};
		}

		#endregion

		#region جهت عملیات حذف اطلاعات ID متد جستجوی گارانتی بر اساس
		public RemoveWarrantyViewModel FindWarrantyByIdForRemove(int WarrantyId)
		{
			return _context.TBL_Warranties

				.Where(w => w.Id == WarrantyId)
				.Select(w => new RemoveWarrantyViewModel
				{
					WarrantyId = w.Id,
					WarrantyName = w.WarrantyName,
				})
				.SingleOrDefault();
		}

		#endregion

		#region متد عملیاتی حذف اطلاعات گارانتی
		public OperationResult RemoveWarranty(RemoveWarrantyViewModel RemoveWarranty)
		{
			var FindWarranty = FindWarrantyById(RemoveWarranty.WarrantyId);

			if (FindWarranty == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			FindWarranty.RemoveDate = DateTime.Now;
			FindWarranty.IsRemove = true;

			_context.TBL_Warranties.Update(FindWarranty);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Remove
			};
		}

		#endregion

		#region متد موجود بودن گارانتی در سمت سرور و عملیات بر روی آن
		public bool ExistWarranty(string warantyName, int warantyId)
		{
			return _context.TBL_Warranties.Any(x => x.WarrantyName == warantyName.Trim().ToLower() && x.Id != warantyId
			);
		}
		#endregion
	}
}
