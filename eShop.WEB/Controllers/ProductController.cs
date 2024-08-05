using eShop.Data.ViewModels.ProductsViewModels.ProductsVMClient;
using eShop.Service.ProductService.ProductForClient;
using Microsoft.AspNetCore.Mvc;

namespace eShop.WEB.Controllers
{
	// این کنترلر برای پیکربندی کلیه محصولات سمت کاربر می باشد
	public class ProductController : BaseController
	{
		#region متد های پیکربندی اطلاعات کالاها یا محصولات سمت کاربر

		private readonly IProductServiceForClient _productServiceClient;

		public ProductController(IProductServiceForClient productServiceClient)
		{
			_productServiceClient = productServiceClient;
		}
		#endregion

		#region متد پیکربندی نمایش اطلاعات محصولات در صفحه اصلی سایت مشتریان
		[Route("Detail/{ProductId}")]
		public IActionResult Detail(int ProductId)
		{
			DetailProductClientViewModel detail = new DetailProductClientViewModel();
			detail.DetailProduct = _productServiceClient.GetDetailProductById(ProductId);

			if (detail.DetailProduct == null)
				return NotFound();

			detail.Gallery = _productServiceClient.GetProductGalleries(ProductId);
			detail.GetProductPrices = _productServiceClient.GetProductPriceClient(ProductId);
			detail.GetSellers = _productServiceClient.GetSellerForProductById(detail.GetProductPrices.GroupBy(x => x.SellerId).Select(x => x.Key).ToList());
			detail.GetReview = _productServiceClient.GetReviewForClient(ProductId);

			if (detail.GetProductPrices == null || detail.GetProductPrices.Count <= 0)
				return View("~/Views/Product/NoProduct.cshtml");

			return View(detail);
		}
		#endregion

		#region ID متد دریافت اطلاعات ویژه گی های محصول یا کالا برای مشتریان توسط پارامتر 
		[HttpPost]
		[Route("PropertyProduct/{ProductId}/{Producten}")]
		public IActionResult PropertyProduct(int ProductId, string Producten)
		{
			TempData[ProductEn] = Producten;
			return View(_productServiceClient.GetPropertyForProductClient(ProductId));
		}
		#endregion
	}
}
