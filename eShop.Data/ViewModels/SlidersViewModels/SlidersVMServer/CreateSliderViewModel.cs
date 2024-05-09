using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.SlidersViewModels.SlidersVMServer
{
	public class CreateSliderViewModel
	{
		public IFormFile ImgName { get; set; }
		public string? Link { get; set; }
		public int Sort { get; set; }
		public bool IsActive { get; set; }
	}
}
