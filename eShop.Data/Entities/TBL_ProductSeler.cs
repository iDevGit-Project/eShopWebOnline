using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductSeler : TBLMASTER_BaseEntity
	{
		public string SellerName { get; set; }
		public string Password { get; set; }
		public string? Phone { get; set; }
		public string Email { get; set; }
		public string? ImgName { get; set; }

		#region جدول ارتباطات
		public List<TBL_ProductPrice> TBLProductPrice { get; set; }
		#endregion
	}
}
