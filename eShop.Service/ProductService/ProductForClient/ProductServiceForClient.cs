using eShop.Data.Context;
using eShop.Data.ViewModels.ProductsViewModels.ProductsVMClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductService.ProductForClient
{
	public class ProductServiceForClient : IProductServiceForClient
	{
		#region متد های پیکربندی سرویس محصولات یا کالا سمت کاربر
		private readonly ApplicationDbContext _context;
		public ProductServiceForClient(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region ID متد دریافت جزئیات محصولات یا کالا با استفاده از 
		public GetDetailProductClientViewModel GetDetailProductById(int ProductId)
		{
			return (from p in _context.TBL_Products
					join c in _context.TBL_Categories on p.CategoryId equals c.Id
					join b in _context.TBL_Brands on p.BrandId equals b.Id

					where (p.Id.Equals(ProductId))

					select new GetDetailProductClientViewModel
					{
						BrandName = b.FaTitle,
						CategortFa = c.FaTitle,
						EnTitle = p.EnTitle,
						FaTitle = p.FaTitle,
						ImgName = p.ImgName,
						ProductId = p.Id,
						Score = p.Score,
					})
					.AsNoTracking()
					.SingleOrDefault();
		}
		#endregion

		#region محصول یا کالا ID متد دریافت اطلاعات تصاویر محصول یا کالا با استفاده از پارامتر 
		public List<GetProductGalleriesViewModel> GetProductGalleries(int ProductId)
		{
			return _context.TBL_ProductGalleries
							.Where(x => x.ProductId == ProductId)
							.Select(x => new GetProductGalleriesViewModel
							{
								ImgName = x.ImgName,
							}).AsNoTracking()
							.ToList();
		}

		#endregion

		#region محصول یا کالا ID متد دریافت قیمت محصول یا کالا با استفاده از پارامتر 
		public List<GetProductPriceClientViewModel> GetProductPriceClient(int ProductId)
		{
			var productPrice = (from pPrice in _context.TBL_ProductPrices
								join g in _context.TBL_Warranties on pPrice.GuaranteeId equals g.Id
								join c in _context.TBL_Colors on pPrice.ColorId equals c.Id

								where (pPrice.ProductId.Equals(ProductId) && pPrice.Count > 0)

								select new GetProductPriceClientViewModel
								{
									ProductPriceId = pPrice.Id,
									ColorCode = c.Code,
									ColorId = c.Id,
									Count = pPrice.Count,
									MaxOrderCount = pPrice.MaxOrderCount,
									Price = pPrice.Price,
									SpecialPrice = pPrice.SpecialPrice,
									SubmitDate = pPrice.SubmitDate,
									SellerId = pPrice.SellerId,
									GuaranteeName = g.WarrantyName,
									GuaranteeId = pPrice.GuaranteeId,

								})
								.AsNoTracking()
								.ToList();

			return productPrice;
		}
		#endregion

		#region ID متد دریافت اطلاعات فروشنده با استفاده از پارامتر 
		public List<GetSellerClientViewModel> GetSellerForProductById(List<int> SellerId)
		{
			return _context.TBL_ProductSelers
							.Where(x => SellerId.Contains(x.Id))
							.Select(x => new GetSellerClientViewModel
							{
								ImgName = x.ImgName,
								SellerId = x.Id,
								SellerName = x.SellerName,
							})
							.AsNoTracking()
							.ToList();
		}
		#endregion

		#region محصول یا کالا ID متد دریافت اطلاعات توضیحات محصول یا کالا با استفاده از پارامتر 
		public GetReviewForClientViewModel GetReviewForClient(int ProductId)
		{
			return _context.TBL_ProductReviews
				.Where(x => x.ProductId == ProductId)
				.Select(x => new GetReviewForClientViewModel
				{
					Negative = x.Negative,
					Positive = x.Positive,
					Review = x.Review,
				})
				.AsNoTracking()
				.FirstOrDefault();
		}

		#endregion

		#region ID متد دریافت اطلاعات ویژه گی ها یا محصولات سمت کاربر برای محصولات سایت از طریق 
		public List<GetPropertyForProductClientViewModel> GetPropertyForProductClient(int ProductId)
		{
			return (from pProperty in _context.TBL_ProductProperties
					join v in _context.TBL_ProductPropertyValues on pProperty.PropertyValueId equals v.Id
					join n in _context.TBL_ProductPropertyNames on v.PropertyNameId equals n.Id
					join g in _context.TBL_ProductPropertyGroups on n.GroupId equals g.Id

					where (pProperty.ProductId == ProductId)
					select new GetPropertyForProductClientViewModel
					{
						GroupTitle = g.Title,
						NameTitle = n.Title,
						Value = v.Value,
					}).AsNoTracking()
					.ToList();
		}

		#endregion

		#region متد دریافت اطلاعات محصول یا کالا برای دسته بندی ها
		public List<GetProductForCategoryViewModel> GetProductForCategory(int CategoryId)
		{
			return (from p in _context.TBL_Products
					join Pprice in _context.TBL_ProductPrices on p.Id equals Pprice.ProductId
					join c in _context.TBL_Categories on p.CategoryId equals c.Id
					where (p.CategoryId == CategoryId)
					select new GetProductForCategoryViewModel
					{
						CategoryName = c.FaTitle,
						FaTitle = p.FaTitle,
						ImgName = p.ImgName,
						ProductId = p.Id,
						GetProductPrices = new GetProductPriceForProductViewModel()
						{
							MainPrice = Pprice.Price,
							SpecialPrice = Pprice.SpecialPrice,
							EndDate = Pprice.EndDisCount,
							StartDate = Pprice.StartDisCount,
						}
					}).AsNoTracking()
					.ToList();
		}
		#endregion
	}
}
