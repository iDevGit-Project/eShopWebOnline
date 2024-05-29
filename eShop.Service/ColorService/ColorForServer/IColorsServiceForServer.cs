using eShop.Common.Operations;
using eShop.Data.ViewModels.ColorsViewModels.ColorsVMServer;
using eShop.Data.ViewModels.WarrantiesViewModels.WarrantiesVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ColorService.ColorForServer
{
    public interface IColorsServiceForServer
	{
		List<GetColorsViewModel> GetColors();
		OperationResult CreateColor(CreateColorViewModel createColor);
		UpdateColorViewModel FindColorByIdForUpdate(int ColorId);
		OperationResult UpdateColor(UpdateColorViewModel updateColor);

		// گارانتی جهت حذف اطلاعات ID متد جستجوی مقدار 
		RemoveColorViewModel FindColorByIdForRemove(int ColorId);

		// متد عملیات حذف اطلاعات گارانتی بر اساس ویو مدل مربوطه
		OperationResult RemoveColor(RemoveColorViewModel RemoveColor);
	}
}
