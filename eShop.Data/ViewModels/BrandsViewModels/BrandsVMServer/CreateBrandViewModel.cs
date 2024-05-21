using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer
{
    public class CreateBrandViewModel
    {
		[Display(Name = "نام تصویر")]
		[Required(ErrorMessage = "وارد کردن {0} اجباری می باشد.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public IFormFile? ImgName { get; set; }

		[Display(Name = "نام برند -فارسی")]
		[Required(ErrorMessage = "وارد کردن {0} اجباری می باشد.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string FaTitle { get; set; }

		[Display(Name = "نام برند-انگلیسی")]
		[Required(ErrorMessage = "وارد کردن {0} اجباری می باشد.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string EnTitle { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "وارد کردن {0} اجباری می باشد.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string? DesCripton { get; set; }
	}
}
