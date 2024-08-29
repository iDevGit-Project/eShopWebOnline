using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductCartDetail : TBLMASTER_BaseEntity
	{
		public int Count { get; set; }
		public int Price { get; set; }
		public int CartId { get; set; }
		public int ProductPriceId { get; set; }

		#region جدول ارتباطات
		[ForeignKey(nameof(CartId))]
		public TBL_ProductCart TBLProductCarts { get; set; }

		[ForeignKey(nameof(ProductPriceId))]
		public TBL_ProductPrice TBLProductPrices { get; set; }
		#endregion
	}
}
