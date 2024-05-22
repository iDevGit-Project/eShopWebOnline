using eShop.Common.Operations;
using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.ProductGalleriesViewModels.ProductGalleriesVMServer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductGalleryService.ProductGalleryForServer
{
	public class ProductGalleryServiceForServer : IProductGalleryServiceForServer
    {
        #region متد های پیکربندی اطلاعات گالری محصولات در سمت سرور یا مدیرسایت

        private readonly ApplicationDbContext _context;
        public ProductGalleryServiceForServer(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region متد نمایش تمام گالری تصاویر محصولات سایت در سمت سرور یا مدیرسایت
        public List<GetImageProductGalleryForProductViewModel> getImageGalleryForProductById(int ProductId)
        {
            return _context.TBL_ProductGalleries
                .Where(x => x.ProductId == ProductId)
                .Select(x => new GetImageProductGalleryForProductViewModel
                {
                    GalleryId = x.Id,
                    ImgName = x.ImgName,
                    ProductId = x.ProductId,
                })
                .AsNoTracking()
                .ToList();
        }
        #endregion

        #region متد عملیاتی ثبت تصاویر مربوط به گالری محصولات در سایت
        public OperationResult CreateImageForProductGallery(int ProductId, IFormFile ImgName)
        {
            string imageName = ImgName.UplodeImage(ImagePathExtention.PathProductGalleryImageServer);

            TBL_ProductGallery productGalleryNewData = new TBL_ProductGallery()
            {
                CreationDate = DateTime.Now,
                ImgName = imageName,
                ProductId = ProductId,
            };

            _context.TBL_ProductGalleries.Add(productGalleryNewData);
            _context.SaveChanges();

            return new OperationResult
            {
                Code = OperationCode.Success,
                IsSuccess = true,
                Message = OperationResultMessage.Create,
            };
        }
        #endregion
    }
}
