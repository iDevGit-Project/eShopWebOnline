using eShop.Data.Entities;
using eShop.Data.ViewModels.ColorsViewModels.ColorsVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ColorService.Query
{
	public interface IColorServiceQuery
	{
		List<GetColorsViewModel> GetColors();
		UpdateColorViewModel FindColorByIdForUpdate(int ColorId);
		RemoveColorViewModel FindColorByIdForRemove(int ColorId);
		bool ExistColor(int ColorId, string ColorName, string ColorCode);
		TBL_Color FindColorById(int ColorId);
	}
}
