using eShop.Data.Context;
using eShop.Data.ViewModels.SlidersViewModels.SlidersVMClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.SliderService.SliderForClient
{
	public class SliderServiceForClient : ISliderServiceForClient
	{
		#region متد پیکربندی اطلاعات مربوط به اسلایدر سمت کاربر
		private readonly ApplicationDbContext _context;
		public SliderServiceForClient(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد دریافت اطلاعات مربوط به اسلایدر سمت کاربر

		public List<GetSlidersForClientViewModel> getSlidersForClient()
		{
			return _context.TBL_Sliders
				.Where(x => x.IsActive)
				.Select(x => new GetSlidersForClientViewModel
				{
					Link = x.Link,
					SliderId = x.Id,
					SliderImage = x.ImgName,
					SliderSort = x.Sort,
				})
				.AsNoTracking()
				.OrderBy(x => x.SliderSort)
				.ToList();
		}
		#endregion
	}
}
