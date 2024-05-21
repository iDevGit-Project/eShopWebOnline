using eShop.Data.ViewModels.BrandsViewModels.BrandsVMServer;
using eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductsViewModels
{
	public class UpdateProductViewModel
	{
		public int ProductId { get; set; }
		public IFormFile? ImgName { get; set; }
		public string? OldImage { get; set; }
		public string FaTitle { get; set; }
		public string EnTitle { get; set; }
		public int CategoryId { get; set; }
		public int BrandId { get; set; }
		public bool IsActive { get; set; }
		public int Score { get; set; }
		public List<GetCategoriesViewModel>? GetCategories { get; set; }
		public List<GetBrandsViewModel>? Brands { get; set; }
	}
}
