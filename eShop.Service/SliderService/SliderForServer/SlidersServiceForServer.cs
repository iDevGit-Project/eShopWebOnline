using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using eShop.Data.ViewModels.SlidersViewModels.SlidersVMServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.SliderService.SliderForServer
{
	public class SlidersServiceForServer : ISlidersServiceForServer
	{
		#region متد های پیکربندی اطلاعات اسلایدر در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
		public SlidersServiceForServer(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد نمایش تمام اسلایدرهای فروشگاه در سمت سرور یا مدیرسایت
		public List<GetSlidersViewModel> GetSliders()
		{
			return _context.TBL_Sliders

				.Select(s => new GetSlidersViewModel
				{
					SliderId = s.Id,
					ImgName = s.ImgName,
					IsActive = s.IsActive,
				})
				.AsNoTracking()
				.ToList();
		}
		#endregion

		#region متد ثبت اطلاعات اسلایدر جدید
		public OperationResult<int> CreateSlider(CreateSliderViewModel createSlider)
		{
			string imageName = createSlider.ImgName.UplodeImage(ImagePathExtention.PathSliderImageServer);
			TBL_Slider newDataslider = new TBL_Slider()
			{
				CreationDate = DateTime.Now,
				ImgName = imageName,
				IsActive = createSlider.IsActive,
				Link = createSlider.Link,
				Sort = createSlider.Sort,

			};

			_context.TBL_Sliders.Add(newDataslider);
			_context.SaveChanges();

			return new OperationResult<int>
			{
				Code = OperationCode.Success,
				Data = newDataslider.Id,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion

		#region جهت عملیات بروزرسانی ID متد جستجوی اسلایدر بر اساس 
		public UpdateSliderViewModel FindSliderByIdForUpdate(int SliderId)
		{
			return _context.TBL_Sliders

				.Where(s => s.Id == SliderId)
				.Select(s => new UpdateSliderViewModel
				{
					SliderId = s.Id,
					IsActive = s.IsActive,
					OldImage = s.ImgName,
					Link = s.Link,
					Sort = s.Sort,
				})
				.SingleOrDefault();
		}
		#endregion

		#region متد عملیاتی بروزرسانی اطلاعات اسلایدر

		public OperationResult UpdateSlider(UpdateSliderViewModel updateSlider)
		{
			var FindSlider = FindSliderById(updateSlider.SliderId);

			if (FindSlider == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			if (updateSlider.ImgName != null)
			{
				ImageExtention.RemoveImage(FindSlider.ImgName, ImagePathExtention.PathSliderImageServer);
				FindSlider.ImgName = updateSlider.ImgName.UplodeImage(ImagePathExtention.PathSliderImageServer);
			}

			FindSlider.Link = updateSlider.Link;
			FindSlider.Sort = updateSlider.Sort;
			FindSlider.IsActive = updateSlider.IsActive;
			FindSlider.LastModified = DateTime.Now;

			_context.TBL_Sliders.Update(FindSlider);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Update,
			};
		}
		#endregion

		#region جهت عملیات حذف اطلاعات ID متد جستجوی اسلایدر بر اساس

		public RemoveSliderViewModel FindSliderByIdForRemove(int SliderId)
		{
			return _context.TBL_Sliders

				.Where(s => s.Id == SliderId)
				.Select(s => new RemoveSliderViewModel
				{
					SliderId = s.Id,
					OldImage = s.ImgName,
					IsActive = s.IsActive,
					Link = s.Link,
					Sort = s.Sort,
				})
				.AsNoTracking()
				.SingleOrDefault();
		}
		#endregion

		#region متد عملیاتی حذف اطلاعات اسلایدر

		public OperationResult RemoveSlider(RemoveSliderViewModel RemoveSlider)
		{
			var FindSlider = FindSliderById(RemoveSlider.SliderId);

			if (FindSlider == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			ImageExtention.RemoveImage(FindSlider.ImgName, ImagePathExtention.PathSliderImageServer);

			_context.TBL_Sliders.Remove(FindSlider);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Remove,
			};
		}
		#endregion

		#region ID متد جستجوی اسلایدر بر اساس مقدار 
		public TBL_Slider FindSliderById(int SliderId)
		{
			return _context.TBL_Sliders
				.Where(x => x.Id == SliderId)
				.AsNoTracking()
				.FirstOrDefault();
		}
		#endregion

	}
}
