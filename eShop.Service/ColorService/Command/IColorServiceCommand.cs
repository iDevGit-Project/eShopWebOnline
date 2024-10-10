using eShop.Common.Operations;
using eShop.Data.ViewModels.ColorsViewModels.ColorsVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ColorService.Command
{
	public interface IColorServiceCommand
	{
		OperationResult CreateColor(CreateColorViewModel createColor);
		OperationResult UpdateColor(UpdateColorViewModel updateColor);
		OperationResult RemoveColor(RemoveColorViewModel RemoveColor);
	}
}
