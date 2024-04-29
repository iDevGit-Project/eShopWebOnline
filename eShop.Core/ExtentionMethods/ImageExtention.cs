using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Core.ExtentionMethods
{
	public static class ImageExtention
	{
		#region متد بارگزاری فایل تصویر در سمت سرور
		public static string UplodeImage(this IFormFile? image, string path)
		{

			if (image == null)
			{
				return "";
			}
			else
			{
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}

				string imageName = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5) + Path.GetExtension(image.FileName);
				string pathSave = Path.Combine(Directory.GetCurrentDirectory(), path, imageName);

				using (var stream = new FileStream(pathSave, FileMode.Create))
					image.CopyTo(stream);

				return imageName;
			}

		}

		#endregion

		#region متد حذف فایل تصویر در سمت سرور

		public static void RemoveImage(string ImgName, string path)
		{
			if (!String.IsNullOrEmpty(ImgName))
			{
				string imgPath = Path.Combine(Directory.GetCurrentDirectory(), path, ImgName);

				if (File.Exists(imgPath))
				{
					File.Delete(imgPath);
				}
			}

		}
		#endregion
	}
}
