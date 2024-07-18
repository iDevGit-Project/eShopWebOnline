using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer
{
	public class CreateCategoryViewModel
	{
		[Display(Name = "دسته بندی -فارسی")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		public string FaTitle { get; set; }

		[Display(Name = "دسته بندی -انگلیسی")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		public string EnTitle { get; set; }
		public string? Icon { get; set; }
		public IFormFile? ImgName { get; set; }
		public string? Description { get; set; }
		public bool IsActive { get; set; }
		public bool IsMain { get; set; }
		public AddOrUpdateParentCategoryViewModel? addOrUpdateParent { get; set; }
	}
}
