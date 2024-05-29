using eShop.Common.Operations;
using eShop.Data.Entities;
using eShop.Data.ViewModels.ProductsViewModels.ProductsVMServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductService.ProductForServer
{
    public interface IProductServiceForServer
	{
		List<GetProductsViewModel> GetProducts();
		OperationResult<int> CreateProduct(CreateProductViewModel createProduct);
		UpdateProductViewModel FindProductByIdForUpdate(int ProductId);
		OperationResult UpdateProduct(UpdateProductViewModel updateProduct);
		TBL_Product FindProductById(int ProductId);
		AddOrUpdateProductReviewViewModel FindProductReviewById(int ProductId);
		OperationResult UpdateProductReview(AddOrUpdateProductReviewViewModel addOrUpdateProduct);
	}
}
