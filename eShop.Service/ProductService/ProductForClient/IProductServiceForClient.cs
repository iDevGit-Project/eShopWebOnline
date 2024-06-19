using eShop.Data.ViewModels.ProductsViewModels.ProductsVMClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductService.ProductForClient
{
	public interface IProductServiceForClient
	{
		GetDetailProductClientViewModel GetDetailProductById(int ProductId);
		List<GetProductGalleriesViewModel> GetProductGalleries(int ProductId);
		List<GetProductPriceClientViewModel> GetProductPriceClient(int ProductId);
		List<GetSellerClientViewModel> GetSellerForProductById(List<int> SellerId);
		GetReviewForClientViewModel GetReviewForClient(int ProductId);
		List<GetPropertyForProductClientViewModel> GetPropertyForProductClient(int ProductId);
		List<GetProductForCategoryViewModel> GetProductForCategory(int CategoryId);
	}
}
