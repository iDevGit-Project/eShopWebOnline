using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.BrandsService.BrandsForServer
{
	public class BrandsServiceForServer : IBrandsServiceForServer
	{
		#region متد های پیکربندی اطلاعات برند در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
        public BrandsServiceForServer(ApplicationDbContext context)
        {
			_context = context;
        }
		#endregion

		#region متد نمایش تمام برندهای فروشگاه در سمت سرور یا مدیرسایت
		public List<GetBrandsViewModel> getBrands()
		{
			return _context.TBL_Brands

				.Select(b => new GetBrandsViewModel
				{
					BrandId = b.Id,
					EnTitle = b.EnTitle,
					FaTitle = b.FaTitle,
					ImgName = b.ImgName,
				})
				.AsNoTracking()
				.ToList();
		}
		#endregion

		#region متد ثبت اطلاعات برند جدید

		public OperationResult<int> CreateBrand(CreateBrandViewModel createBrand)
		{
			bool existBrand = ExistBrand(0, createBrand.FaTitle, createBrand.EnTitle);

			if (existBrand)
			{
				return new OperationResult<int>
				{
					Data = 0,
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};
			}

			string imageName = createBrand.ImgName.UplodeImage(ImagePathExtention.PathBrandImageServer);
			TBL_Brand newDataBrand = new TBL_Brand()
			{
				CreationDate = DateTime.Now,
				DesCripton = createBrand.DesCripton,
				FaTitle = createBrand.FaTitle,
				EnTitle = createBrand.EnTitle,
				ImgName = imageName,
			};

			_context.TBL_Brands.Add(newDataBrand);
			_context.SaveChanges();

			return new OperationResult<int>
			{
				Code = OperationCode.Success,
				Data = newDataBrand.Id,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion

		#region جهت عملیات بروزرسانی ID متد جستجوی برند بر اساس 
		public UpdateBrandViewModel FindBrandByIdForUpdate(int BrandId)
		{
			return _context.TBL_Brands

				.Where(x => x.Id == BrandId)
				.Select(x => new UpdateBrandViewModel
				{
					BrandId = x.Id,
					EnTitle = x.EnTitle,
					FaTitle = x.FaTitle,
					DesCripton = x.DesCripton,
					OldImgName = x.ImgName,
				})
				.SingleOrDefault();
		}
		#endregion

		#region متد عملیاتی بروزرسانی اطلاعات برند

		public OperationResult UpdateBrand(UpdateBrandViewModel UpdateBrand)
		{
			var FindBrand = FindBrandById(UpdateBrand.BrandId);

			if (FindBrand == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.Failed,
				};

			bool existBrand = ExistBrand(UpdateBrand.BrandId, UpdateBrand.FaTitle, UpdateBrand.EnTitle);

			if (existBrand)
			{
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};
			}

			if (UpdateBrand.ImgName != null)
			{
				ImageExtention.RemoveImage(FindBrand.ImgName, ImagePathExtention.PathBrandImageServer);
				FindBrand.ImgName = UpdateBrand.ImgName.UplodeImage(ImagePathExtention.PathBrandImageServer);
			}

			FindBrand.FaTitle = UpdateBrand.FaTitle;
			FindBrand.EnTitle = UpdateBrand.EnTitle;
			FindBrand.DesCripton = UpdateBrand.DesCripton;
			FindBrand.LastModified = DateTime.Now;

			_context.TBL_Brands.Update(FindBrand);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Update,
			};
		}
		#endregion

		#region ID متد جستجوی برند بر اساس مقدار 
		public TBL_Brand FindBrandById(int BrandId)
		{
			return _context.TBL_Brands

				.Where(x => x.Id == BrandId)
				.FirstOrDefault();
		}
		#endregion

		#region متد موجود بودن برند در سمت سرور و عملیات بر روی آن
		public bool ExistBrand(int BrandId, string FaTitle, string EnTitle)
		{
			return _context.TBL_Brands.Any(
				x => (x.FaTitle == FaTitle.ToLower().Trim() ||
				x.EnTitle == EnTitle.ToLower().Trim()) &&
				x.Id != BrandId
				);
		}
		#endregion

		#region جهت عملیات حذف اطلاعات ID متد جستجوی برند بر اساس

		public RemoveBrandViewModel FindBrandByIdForRemove(int BrandId)
		{
			return _context.TBL_Brands

				.Where(x => x.Id == BrandId)
				.Select(x => new RemoveBrandViewModel
				{
					BrandId = x.Id,
					EnTitle = x.EnTitle,
					FaTitle = x.FaTitle,
					DesCripton = x.DesCripton,
					OldImgName = x.ImgName,
				})
				.SingleOrDefault();
		}
		#endregion

		#region متد عملیاتی حذف اطلاعات برند

		public OperationResult RemoveBrand(RemoveBrandViewModel RemoveBrand)
		{
			var FindBrand = FindBrandById(RemoveBrand.BrandId);

			if (FindBrand == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.Failed,
				};

			FindBrand.IsRemove = true;
			FindBrand.RemoveDate = DateTime.Now;

			_context.TBL_Brands.Update(FindBrand);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Remove,
			};
		}
		#endregion
	}
}
