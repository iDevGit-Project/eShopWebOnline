using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductReview : TBLMASTER_BaseEntity
	{
		public int ProductId { get; set; }
		public string? Review { get; set; }
		public string? Positive { get; set; }
		public string? Negative { get; set; }

		#region Product جدول ارتباط با 
		[ForeignKey(nameof(ProductId))]
		public TBL_Product TBLProduct { get; set; }
		#endregion
	}
}
