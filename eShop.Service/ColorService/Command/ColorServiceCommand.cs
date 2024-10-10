using eShop.Common.Operations;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.ColorsViewModels.ColorsVMServer;
using eShop.Service.ColorService.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ColorService.Command
{
	public class ColorServiceCommand : IColorServiceCommand
	{
		#region در سمت مدیرسایت یا سرور Color متد های پیکربندی اطلاعات

		private readonly ApplicationDbContext _context;
		private readonly IColorServiceQuery _colorServiceQuery;
		public ColorServiceCommand(ApplicationDbContext context, IColorServiceQuery colorServiceQuery)
		{
			_context = context;
			_colorServiceQuery = colorServiceQuery;
		}
		#endregion

		#region جدید Color متد عملیاتی ثبت 
		public OperationResult CreateColor(CreateColorViewModel createColor)
		{
			bool existColor = _colorServiceQuery.ExistColor(0, createColor.ColorName, createColor.ColorCode);

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
			var FindColor = _colorServiceQuery.FindColorById(updateColor.ColorId);

			if (FindColor == null)
			{
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};
			}

			bool exist = _colorServiceQuery.ExistColor(updateColor.ColorId, updateColor.ColorName, updateColor.ColorCode);
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

		#region متد عملیاتی حذف اطلاعات رنگ
		public OperationResult RemoveColor(RemoveColorViewModel RemoveColor)
		{
			var FindColor = _colorServiceQuery.FindColorById(RemoveColor.ColorId);

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
