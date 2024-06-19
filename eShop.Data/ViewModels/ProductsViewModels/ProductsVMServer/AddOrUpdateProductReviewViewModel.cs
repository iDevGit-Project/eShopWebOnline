using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductsViewModels.ProductsVMServer
{
    public class AddOrUpdateProductReviewViewModel
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		public string Review { get; set; }

		[Display(Name = "نقاط قوت")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		public string Positive { get; set; }

		[Display(Name = "نقاط ضعف")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		public string Negative { get; set; }
    }
}
