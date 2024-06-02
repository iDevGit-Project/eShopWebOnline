using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductsViewModels.ProductsVMClient
{
	public class GetProductPriceClientViewModel
	{
		public int ProductPriceId { get; set; }
		public string GuaranteeName { get; set; }
		public int GuaranteeId { get; set; }
		public string ColorCode { get; set; }
		public int ColorId { get; set; }
		public int Count { get; set; }
		public int Price { get; set; }
		public int? SpecialPrice { get; set; }
		public int? MaxOrderCount { get; set; }
		public int? SubmitDate { get; set; }
		public int SellerId { get; set; }
	}
}
