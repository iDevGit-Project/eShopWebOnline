using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Core.ExtentionMethods
{
	public static class ImagePathExtention
	{
		#region متد بارگزاری تصاویر مربوط به برندها  
		public static string PathBrandImageServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/BrandImage/");
		public static string PathBrandImageClient = "/upload/BrandImage/";
		#endregion

		#region متد بارگزاری تصاویر مربوط به اسلایدرها
		public static string PathSliderImageServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/SliderImage/");
		public static string PathSliderImageClient = "/upload/SliderImage/";
		#endregion

		#region متد بارگزاری تصاویر مربوط به دسته بندی ها
		public static string PathCategoryImageServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/CategoryImage/");
		public static string PathCategoryImageClient = "/upload/CategoryImage/";
		#endregion

		#region متد بارگزاری تصاویر مربوط به کالاها
		public static string PathProductImageServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/ProductImage/");
		public static string PathProductImageClient = "/upload/ProductImage/";
		#endregion

		#region متد بارگزاری تصاویر مربوط به گالری تصاویر
		public static string PathGalleryImageServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/GalleryImage/");
		public static string PathGalleryImageClient = "/upload/GalleryImage/";
		#endregion
	}
}
