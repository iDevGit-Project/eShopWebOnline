using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.SlidersViewModels.SlidersVMServer
{
	public class CreateSliderViewModel
	{
		//[Display(Name = "نام تصویر")]
		//[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		//[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		//[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public IFormFile ImgName { get; set; }

		[Display(Name = "آدرس لینک")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string? Link { get; set; }
		public int Sort { get; set; }
		public bool IsActive { get; set; }
	}
}
