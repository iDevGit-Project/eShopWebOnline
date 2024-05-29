using eShop.Common.Operations;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.ColorsViewModels.ColorsVMServer;
using eShop.Data.ViewModels.WarrantiesViewModels.WarrantiesVMServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ColorService.ColorForServer
{
    public class ColorsServiceForServer : IColorsServiceForServer
	{
		#region در سمت مدیرسایت یا سرور Color متد های پیکربندی اطلاعات

		private readonly ApplicationDbContext _context;
        public ColorsServiceForServer(ApplicationDbContext context)
        {
			_context = context;
        }
		#endregion

		#region Color متد نمایش لیست اطلاعات 
		public List<GetColorsViewModel> GetColors()
		{
			return _context.TBL_Colors
				.Select(x => new GetColorsViewModel
				{
					ColorCode = x.Code,
					ColorId = x.Id,
					ColorName = x.ColorName,
				})
				.AsNoTracking()
				.ToList();
		}
		#endregion

		#region جدید Color متد ثبت 

		public OperationResult CreateColor(CreateColorViewModel createColor)
		{
			bool existColor = ExistColor(0, createColor.ColorName, createColor.ColorCode);

			if (existColor)
			{
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate
				};
			}

			TBL_Color colorNewData = new TBL_Color()
			{
				Code = createColor.ColorCode,
				ColorName = createColor.ColorName,
				IsActive = createColor.IsActive,
				CreationDate = DateTime.Now,
			};

			_context.TBL_Colors.Add(colorNewData);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion

		#region Color متد عملیاتی ویرایش اطلاعات 
		public OperationResult UpdateColor(UpdateColorViewModel updateColor)
		{
			var FindColor = FindColorById(updateColor.ColorId);

			if (FindColor == null)
			{
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};
			}

			bool exist = ExistColor(updateColor.ColorId, updateColor.ColorName, updateColor.ColorCode);
			if (exist)
			{
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};
			}

			FindColor.Code = updateColor.ColorCode;
			FindColor.ColorName = updateColor.ColorName;
			FindColor.IsActive = updateColor.IsActive;
			FindColor.CreationDate = DateTime.Now;

			_context.TBL_Colors.Update(FindColor);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Update,

			};
		}

		#endregion

		#region Color متد ویرایش اطلاعات
		public UpdateColorViewModel FindColorByIdForUpdate(int ColorId)
		{
			return _context.TBL_Colors
				.Where(x => x.Id == ColorId)
				.Select(x => new UpdateColorViewModel
				{
					ColorCode = x.Code,
					ColorName = x.ColorName,
					IsActive = x.IsActive,
					ColorId = x.Id,
				})
				.FirstOrDefault();
		}
		#endregion

		#region در بانک اطلاعاتی Color متد موجود بودن 
		public bool ExistColor(int ColorId, string ColorName, string ColorCode)
		{
			return _context.TBL_Colors.Any(x => (x.ColorName == ColorName || x.Code == ColorCode) && x.Id != ColorId);
		}
		#endregion

		#region ID بر اساس  Color متد جستجوی 
		public TBL_Color FindColorById(int ColorId)
		{
			return _context.TBL_Colors.Where(x => x.Id == ColorId).FirstOrDefault();
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

		#region متد عملیاتی حذف اطلاعات رنگ
		public RemoveColorViewModel FindColorByIdForRemove(int ColorId)
		{
			return _context.TBL_Colors

				.Where(w => w.Id == ColorId)
				.Select(w => new RemoveColorViewModel
				{
					ColorId = w.Id,
					ColorName = w.ColorName,
				})
				.SingleOrDefault();
		}

		public OperationResult RemoveColor(RemoveColorViewModel RemoveColor)
		{
			var FindColor = FindColorById(RemoveColor.ColorId);

			if (FindColor == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			FindColor.RemoveDate = DateTime.Now;
			FindColor.IsRemove = true;

			_context.TBL_Colors.Remove(FindColor);
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
