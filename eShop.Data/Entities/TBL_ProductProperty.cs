using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductProperty : TBLMASTER_BaseEntity
	{
		public int PropertyValueId { get; set; }
		public int ProductId { get; set; }

		#region  و جدول  Product جدول ارتباط با 
		//[ForeignKey(nameof(PropertyValueId))]
		//public PropertyValue PropertyValue { get; set; }

		[ForeignKey(nameof(ProductId))]
		public TBL_Product TBLProduct { get; set; }
		#endregion
	}
}
