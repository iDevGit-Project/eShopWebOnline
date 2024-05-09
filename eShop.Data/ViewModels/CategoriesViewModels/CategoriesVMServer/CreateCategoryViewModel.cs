using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer
{
	public class CreateCategoryViewModel
	{
		public string FaTitle { get; set; }
		public string EnTitle { get; set; }
		public string? Icon { get; set; }
		public IFormFile? ImgName { get; set; }
		public string? Description { get; set; }
		public bool IsActive { get; set; }
		public bool IsMain { get; set; }
		public AddOrUpdateParentCategoryViewModel? addOrUpdateParent { get; set; }
	}
}
