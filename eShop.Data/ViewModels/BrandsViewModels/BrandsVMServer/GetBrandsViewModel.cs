using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer
{
    public class GetBrandsViewModel
    {
        public int BrandId { get; set; }
        public string ImgName { get; set; }

		[Display(Name = "نام برند -فارسی")]
		[Required(ErrorMessage = " {0} الزامیست.")]
		public string FaTitle { get; set; }

		[Display(Name = "نام برند-انگلیسی")]
		[Required(ErrorMessage = " {0} الزامیست.")]
		public string EnTitle { get; set; }
    }
}
