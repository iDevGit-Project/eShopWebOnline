using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.ColorsViewModels.ColorsVMServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ColorService.Query
{
	public class ColorServiceQuery : IColorServiceQuery
	{
		#region در سمت مدیرسایت یا سرور Color متد های پیکربندی اطلاعات

		private readonly ApplicationDbContext _context;
		public ColorServiceQuery(ApplicationDbContext context)
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

		#region جهت حذف رنگ ID بر اساس Color متد جستجوی
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
		#endregion
	}
}
