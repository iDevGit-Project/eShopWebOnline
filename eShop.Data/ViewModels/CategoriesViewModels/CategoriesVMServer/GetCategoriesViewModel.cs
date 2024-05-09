using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer
{
	public class GetCategoriesViewModel
	{
		public int CategoryId { get; set; }
		public string FaTitle { get; set; }
		public string EnTitle { get; set; }
		public string? ImgName { get; set; }
		public bool IsActive { get; set; }
		public bool IsMain { get; set; }
	}
}
