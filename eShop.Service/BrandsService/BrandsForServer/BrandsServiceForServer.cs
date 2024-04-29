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
		#region متد های پیکربندی پروژه در سمت سرور یا مدیرسایت

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

		public RemoveBrandViewModel FindBrandByIdForRemove(int BrandId)
		{
			throw new NotImplementedException();
		}

		public UpdateBrandViewModel FindBrandByIdForUpdate(int BrandId)
		{
			throw new NotImplementedException();
		}

		public OperationResult RemoveBrand(RemoveBrandViewModel RemoveBrand)
		{
			throw new NotImplementedException();
		}

		public OperationResult UpdateBrand(UpdateBrandViewModel UpdateBrand)
		{
			throw new NotImplementedException();
		}

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
	}
}
