using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer
{
	public class CreateDisCountViewModel
	{
		[Display(Name = "کد تخفیف")]
		[Required(ErrorMessage = "{0} الزامیست.")]
		[MinLength(1, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(1024, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string Code { get; set; }
		public int? UserCount { get; set; }

		[Display(Name = "فعال یا غیر کردن")]
		[Required(ErrorMessage = "{0} الزامیست.")]
		public bool IsActive { get; set; }
		public string? StartDisCount { get; set; }
		public string? EndDisCount { get; set; }
	}
}
