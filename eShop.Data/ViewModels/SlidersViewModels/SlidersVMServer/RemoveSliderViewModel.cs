using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.SlidersViewModels.SlidersVMServer
{
	public class RemoveSliderViewModel
	{
		public int SliderId { get; set; }
		public string OldImage { get; set; }
		public string? Link { get; set; }
		public int Sort { get; set; }
		public bool IsActive { get; set; }
	}
}
