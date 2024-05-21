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
		[Display(Name = "دسته بندی")]
		[Required(ErrorMessage = "وارد کردن {0} اجباری می باشد.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string FaTitle { get; set; }

		[Display(Name = "دسته بندی")]
		[Required(ErrorMessage = "وارد کردن {0} اجباری می باشد.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string EnTitle { get; set; }
		public string? Icon { get; set; }
		public IFormFile? ImgName { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "وارد کردن {0} اجباری می باشد.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string? Description { get; set; }
		public bool IsActive { get; set; }
		public bool IsMain { get; set; }
		public AddOrUpdateParentCategoryViewModel? addOrUpdateParent { get; set; }
	}
}
