using eShop.Common.Operations;
using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.BrandsService.BrandsForServer
{
	public interface IBrandsServiceForServer
	{
		// لیستی از نمایش تمام برندهای فروشگاه
		List<GetBrandsViewModel> getBrands();

		// متد عملیات ثبت برند جدید بر اساس ویو مدل مربوطه
		OperationResult<int> CreateBrand(CreateBrandViewModel createBrand);

		// برند جهت بروزرسانی اطلاعات ID متد جستجوی مقدار 
		UpdateBrandViewModel FindBrandByIdForUpdate(int BrandId);

		// متد عملیات بروزرسانی برند بر اساس ویو مدل مربوطه
		OperationResult UpdateBrand(UpdateBrandViewModel UpdateBrand);

		// برند جهت حذف اطلاعات ID متد جستجوی مقدار 
		RemoveBrandViewModel FindBrandByIdForRemove(int BrandId);

		// متد عملیات حذف اطلاعات برند بر اساس ویو مدل مربوطه
		OperationResult RemoveBrand(RemoveBrandViewModel RemoveBrand);
	}
}
