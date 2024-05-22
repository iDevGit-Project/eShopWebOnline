using eShop.Common.Operations;
using eShop.Data.ViewModels.ProductGalleriesViewModels.ProductGalleriesVMServer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductGalleryService.ProductGalleryForServer
{
	public interface IProductGalleryServiceForServer
    {
        List<GetImageProductGalleryForProductViewModel> getImageGalleryForProductById(int ProductId);
        OperationResult CreateImageForProductGallery(int ProductId, IFormFile ImgName);
    }
}
