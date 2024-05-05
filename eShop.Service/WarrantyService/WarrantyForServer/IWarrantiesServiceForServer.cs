using eShop.Common.Operations;
using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using eShop.Data.ViewModels.WarrantiesViewModels.WarrantiesVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.WarrantyService.WarrantyForServer
{
	public interface IWarrantiesServiceForServer
	{
		// لیستی از نمایش تمام گارانتی های فروشگاه
		List<GetWarrantiesViewModel> getWarranties();

		// متد عملیات ثبت گارانتی جدید بر اساس ویو مدل مربوطه
		OperationResult<int> CreateWarranty(CreateWarrantyViewModel createWarranty);

		// گارانتی جهت بروزرسانی اطلاعات ID متد جستجوی مقدار 
		UpdateWarrantyViewModel FindWarrantyByIdForUpdate(int WarrantyId);

		// متد عملیات بروزرسانی گارانتی بر اساس ویو مدل مربوطه
		OperationResult UpdateWarranty(UpdateWarrantyViewModel UpdateWarranty);

		// گارانتی جهت حذف اطلاعات ID متد جستجوی مقدار 
		RemoveWarrantyViewModel FindWarrantyByIdForRemove(int WarrantyId);

		// متد عملیات حذف اطلاعات گارانتی بر اساس ویو مدل مربوطه
		OperationResult RemoveWarranty(RemoveWarrantyViewModel RemoveWarranty);
	}
}
