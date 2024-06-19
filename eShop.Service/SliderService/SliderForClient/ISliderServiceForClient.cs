using eShop.Data.ViewModels.SlidersViewModels.SlidersVMClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.SliderService.SliderForClient
{
	public interface ISliderServiceForClient
	{
		List<GetSlidersForClientViewModel> getSlidersForClient();
	}
}
