using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductPrice : TBLMASTER_BaseEntity
	{
		public int Price { get; set; }
		public int? SpecialPrice { get; set; }
		public int Count { get; set; }
		public int? MaxOrderCount { get; set; }
		public int? SubmitDate { get; set; }
		public int ProductId { get; set; }
		public int GuaranteeId { get; set; }
		public int ColorId { get; set; }
		public int SellerId { get; set; }
		public DateTime? StartDisCount { get; set; }
		public DateTime? EndDisCount { get; set; }

		#region جدول کلیه ارتباطات
		[ForeignKey(nameof(ProductId))]
		public TBL_Product TBLProduct { get; set; }

		[ForeignKey(nameof(GuaranteeId))]
		public TBL_Warranty TBLWarranty { get; set; }

		[ForeignKey(nameof(ColorId))]
		public TBL_Color TBLColor { get; set; }

		[ForeignKey(nameof(SellerId))]
		public TBL_ProductSeler TBLProductSeler { get; set; }

		//public List<TBL_ProductCartDetail> TBLProductCartDetail { get; set; }
		#endregion
	}
}
