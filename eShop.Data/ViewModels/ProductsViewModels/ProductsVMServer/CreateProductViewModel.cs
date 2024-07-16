using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductsViewModels.ProductsVMServer
{
    public class CreateProductViewModel
    {
        public IFormFile ImgName { get; set; }

        [Display(Name = "نام کالا (فارسی)")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string FaTitle { get; set; }

        [Display(Name = "نام کالا (انگلیسی)")]
        [Required(ErrorMessage = "وارد کردن {0} الزامیست.")]
        [MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
        public string EnTitle { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "انتخاب {0} الزامیست.")]
        public int CategoryId { get; set; }

        //[Display(Name = "برند")]
        //[Required(ErrorMessage = "انتخاب {0} الزامیست.")]
        public int BrandId { get; set; }
        public bool IsActive { get; set; }
        public int Score { get; set; }
        public List<GetCategoriesViewModel> GetCategories { get; set; }
        public List<GetBrandsViewModel> Brands { get; set; }
    }
}
