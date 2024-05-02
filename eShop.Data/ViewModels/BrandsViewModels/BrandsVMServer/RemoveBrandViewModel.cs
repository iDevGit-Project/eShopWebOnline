using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer
{
	public class RemoveBrandViewModel
	{
		public int BrandId { get; set; }
		public string OldImgName { get; set; }
		public string FaTitle { get; set; }
		public string EnTitle { get; set; }
		public string? DesCripton { get; set; }
	}
}
