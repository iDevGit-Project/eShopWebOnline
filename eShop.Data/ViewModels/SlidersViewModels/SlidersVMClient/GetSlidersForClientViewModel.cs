using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.SlidersViewModels.SlidersVMClient
{
	public class GetSlidersForClientViewModel
	{
		public int SliderId { get; set; }
		public int SliderSort { get; set; }
		public string SliderImage { get; set; }
		public string? Link { get; set; }
	}
}
