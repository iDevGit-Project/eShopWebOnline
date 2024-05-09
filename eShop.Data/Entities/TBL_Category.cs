using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_Category : TBLMASTER_BaseEntity
	{
		public string FaTitle { get; set; }
		public string EnTitle { get; set; }

		// در صورتی که بخواهیم برای منوی اصلی از آیکن استفاده کنیم
		public string? Icon { get; set; }

		// در صورتی که بخواهیم برای زیرمنوهای منوی اصلی در پنجره مگامنوی آن از تصویر استفاده کنیم
		public string? ImgName { get; set; }

		// در صورتی که بخواهیم برای زیرمنوهای منوی اصلی در پنجره مگامنوی آن از توضیحات استفاده کنیم
		public string? Description { get; set; }

		// فعال یا غیرفعالسازی منو
		public bool IsActive { get; set; }

		// آیا منو در قسمت اصلی سایت قراربگیرد یا خیر
		public bool IsMain { get; set; }

		#region ارتباطات جداول
		public List<TBL_SubCategory> PSubCategory { get; set; }
		public List<TBL_SubCategory> SSubCategory { get; set; }
		#endregion
	}
}
