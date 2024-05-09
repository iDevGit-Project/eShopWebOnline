using eShop.Common.Operations;
using eShop.Data.ViewModels.SlidersViewModels.SlidersVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.SliderService.SliderForServer
{
	public interface ISlidersServiceForServer
	{
		List<GetSlidersViewModel> GetSliders();
		OperationResult<int> CreateSlider(CreateSliderViewModel createSlider);
		UpdateSliderViewModel FindSliderByIdForUpdate(int SliderId);
		OperationResult UpdateSlider(UpdateSliderViewModel updateSlider);
		RemoveSliderViewModel FindSliderByIdForRemove(int SliderId);
		OperationResult RemoveSlider(RemoveSliderViewModel RemoveSlider);
	}
}
