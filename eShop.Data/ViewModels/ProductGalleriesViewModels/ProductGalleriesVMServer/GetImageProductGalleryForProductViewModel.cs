using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductGalleriesViewModels.ProductGalleriesVMServer
{
	public class GetImageProductGalleryForProductViewModel
	{
		public int GalleryId { get; set; }
		public int ProductId { get; set; }
		public string ImgName { get; set; }
	}
}
