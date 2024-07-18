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
		public IFormFile? ImgName { get; set; }

		[Display(Name = "نام برند به فارسی")]
		[Required(ErrorMessage = " {0} الزامیست.")]
		public string FaTitle { get; set; }

		[Display(Name = "نام برند به انگلیسی")]
		[Required(ErrorMessage = " {0} الزامیست.")]
		public string EnTitle { get; set; }
		public string? DesCripton { get; set; }
	}
}
