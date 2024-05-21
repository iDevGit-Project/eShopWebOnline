using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.ProductsViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductService.ProductForServer
{
	public class ProductServiceForServer : IProductServiceForServer
	{
		#region متد های پیکربندی اطلاعات محصولات در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
		public ProductServiceForServer(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد نمایش تمام محصولات سایت در سمت سرور یا مدیرسایت
		public List<GetProductsViewModel> GetProducts()
		{
			var pr = (from p in _context.TBL_Products
					  join b in _context.TBL_Brands on p.BrandId equals b.Id
					  join c in _context.TBL_Categories on p.CategoryId equals c.Id

					  select new GetProductsViewModel
					  {
						  BrandName = b.FaTitle,
						  CategoryName = c.FaTitle,
						  FaTitle = p.FaTitle,
						  ImgName = p.ImgName,
						  ProductId = p.Id,

					  })
					.AsNoTracking()
					.ToList();
			return pr;
		}
		#endregion

		#region متد ثبت کالای جدید به همراه دسته بندی های انتخای کاربرسایت
		public OperationResult<int> CreateProduct(CreateProductViewModel createProduct)
		{
			bool exist = ExistProduct(0, createProduct.FaTitle, createProduct.EnTitle);
			if (exist)
			{
				return new OperationResult<int>
				{
					Code = OperationCode.duplicate,
					Data = 0,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};
			}

			string imageName = createProduct.ImgName.UplodeImage(ImagePathExtention.PathProductImageServer);

			TBL_Product productNewData = new TBL_Product()
			{
				BrandId = createProduct.BrandId,
				CategoryId = createProduct.CategoryId,
				CreationDate = DateTime.Now,
				EnTitle = createProduct.EnTitle,
				FaTitle = createProduct.FaTitle,
				IsActive = createProduct.IsActive,
				ImgName = imageName,
				Score = createProduct.Score,

			};

			_context.TBL_Products.Add(productNewData);
			_context.SaveChanges();

			return new OperationResult<int>
			{
				Code = OperationCode.Success,
				Data = productNewData.Id,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion

		#region متد عملیاتی بروزرسانی اطلاعات محصولات سایت
		public OperationResult UpdateProduct(UpdateProductViewModel updateProduct)
		{
			var FindProduct = FindProductById(updateProduct.ProductId);
			if (FindProduct == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			bool exist = ExistProduct(updateProduct.ProductId, updateProduct.FaTitle, updateProduct.EnTitle);
			if (exist)
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};

			if (updateProduct.ImgName != null)
			{
				ImageExtention.RemoveImage(FindProduct.ImgName, ImagePathExtention.PathProductImageServer);
				FindProduct.ImgName = updateProduct.ImgName.UplodeImage(ImagePathExtention.PathProductImageServer);
			}

			FindProduct.FaTitle = updateProduct.FaTitle;
			FindProduct.EnTitle = updateProduct.EnTitle;
			FindProduct.CategoryId = updateProduct.CategoryId;
			FindProduct.BrandId = updateProduct.BrandId;
			FindProduct.IsActive = updateProduct.IsActive;
			FindProduct.Score = updateProduct.Score;
			FindProduct.LastModified = DateTime.Now;

			_context.TBL_Products.Update(FindProduct);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Update,
			};
		}
		#endregion

		#region جهت بروزرسانی ID متد جستجوی اطلاعات کالا بر اساس 
		public UpdateProductViewModel FindProductByIdForUpdate(int ProductId)
		{
			return _context.TBL_Products
				.Where(x => x.Id == ProductId)
				.Select(x => new UpdateProductViewModel
				{
					ProductId = x.Id,
					BrandId = x.BrandId,
					CategoryId = x.CategoryId,
					EnTitle = x.EnTitle,
					FaTitle = x.FaTitle,
					IsActive = x.IsActive,
					OldImage = x.ImgName,
					Score = x.Score,

				})
				.AsNoTracking()
				.FirstOrDefault();
		}
		#endregion

		#region  جهت بروزرسانی ID متد جستجوی توضیحات کالا بر اساس 
		public AddOrUpdateProductReviewViewModel FindProductReviewById(int ProductId)
		{
			return _context.TBL_ProductReviews
				.Where(x => x.ProductId == ProductId)
				.Select(x => new AddOrUpdateProductReviewViewModel
				{
					Negative = x.Negative,
					Positive = x.Positive,
					ProductId = ProductId,
					Review = x.Review,
					ReviewId = x.Id,
				})
				.AsNoTracking()
				.FirstOrDefault();
		}
		#endregion

		#region متد عملیاتی توضیحات کالا
		public OperationResult UpdateProductReview(AddOrUpdateProductReviewViewModel addOrUpdateProduct)
		{
			var FindReview = FindReviewByProductId(addOrUpdateProduct.ProductId);

			if (FindReview == null)
			{
				TBL_ProductReview productReviewNewData = new TBL_ProductReview()
				{
					ProductId = addOrUpdateProduct.ProductId,
					CreationDate = DateTime.Now,
					Negative = addOrUpdateProduct.Negative,
					Positive = addOrUpdateProduct.Positive,
					Review = addOrUpdateProduct.Review,
				};
				_context.TBL_ProductReviews.Add(productReviewNewData);
			}
			else
			{
				FindReview.Review = addOrUpdateProduct.Review;
				FindReview.Positive = addOrUpdateProduct.Positive;
				FindReview.Negative = addOrUpdateProduct.Negative;
				FindReview.LastModified = DateTime.Now;
				_context.TBL_ProductReviews.Update(FindReview);
			}
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Update,
			};
		}
		#endregion

		#region ID متد جستجوی کالا بر اساس
		public TBL_Product FindProductById(int ProductId)
		{
			return _context.TBL_Products
				.Where(x => x.Id == ProductId)
				.AsNoTracking().SingleOrDefault();
		}
		#endregion

		#region ID متد جستجوی توضیحات کالا بر اساس 
		public TBL_ProductReview FindReviewByProductId(int ProductId)
		{
			return _context.TBL_ProductReviews
				.Where(x => x.ProductId == ProductId)
				.FirstOrDefault();
		}
		#endregion

		#region متد موجود بودن اطلاعات کالا در سایت
		public bool ExistProduct(int ProductId, string FaTitle, string EnTitle)
		{
			return _context.TBL_Products.Any(x => (x.FaTitle == FaTitle.Trim().ToLower()
			|| x.EnTitle == EnTitle.Trim().ToLower())
			&& x.Id != ProductId);
		}

		#endregion
	}
}
