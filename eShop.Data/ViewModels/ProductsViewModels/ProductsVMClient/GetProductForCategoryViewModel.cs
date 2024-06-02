using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductsViewModels.ProductsVMClient
{
	public class GetProductForCategoryViewModel
	{
		public string CategoryName { get; set; }
		public int ProductId { get; set; }
		public string ImgName { get; set; }
		public string FaTitle { get; set; }
		public GetProductPriceForProductViewModel GetProductPrices { get; set; }
	}
	public class GetProductPriceForProductViewModel
	{
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public int MainPrice { get; set; }
		public int? SpecialPrice { get; set; }
	}
}
