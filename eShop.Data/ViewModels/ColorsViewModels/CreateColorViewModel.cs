using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ColorsViewModels
{
	public class CreateColorViewModel
	{
		[Display(Name = "نام رنگ")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string ColorName { get; set; }

		[Display(Name = "کد رنگ")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string ColorCode { get; set; }
		public bool IsActive { get; set; }
	}
}
