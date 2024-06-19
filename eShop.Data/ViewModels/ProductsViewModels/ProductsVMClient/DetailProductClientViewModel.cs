using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductsViewModels.ProductsVMClient
{
	public class DetailProductClientViewModel
	{
		public GetDetailProductClientViewModel? DetailProduct { get; set; }
		public List<GetProductGalleriesViewModel>? Gallery { get; set; }
		public List<GetProductPriceClientViewModel>? GetProductPrices { get; set; }
		public List<GetSellerClientViewModel>? GetSellers { get; set; }
		public GetReviewForClientViewModel? GetReview { get; set; }
	}
}
