using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductsViewModels.ProductsVMServer
{
    public class GetProductsViewModel
    {
        public int ProductId { get; set; }
        public string ImgName { get; set; }

		[Display(Name = "نام کالا (فارسی)")]
		[Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
		public string FaTitle { get; set; }

		[Display(Name = "برند کالا)")]
		[Required(ErrorMessage = "انتخاب {0} الزامیست.")]
		public string BrandName { get; set; }

		[Display(Name = "دسته بندی)")]
		[Required(ErrorMessage = "انتخاب {0} الزامیست.")]
		public string CategoryName { get; set; }
    }
}
