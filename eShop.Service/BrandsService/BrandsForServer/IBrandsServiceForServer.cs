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
		OperationResult<int> CreateBrand(CreateBrandViewModel createBrand);
		UpdateBrandViewModel FindBrandByIdForUpdate(int BrandId);
		OperationResult UpdateBrand(UpdateBrandViewModel UpdateBrand);
		RemoveBrandViewModel FindBrandByIdForRemove(int BrandId);
		OperationResult RemoveBrand(RemoveBrandViewModel RemoveBrand);
	}
}
