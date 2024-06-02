using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_PaymentDetail : TBLMASTER_BaseEntity
	{
		public int Price { get; set; }
		public string RefId { get; set; }
		public string UserIp { get; set; }
		public string Athourity { get; set; }
		public int DisCountId { get; set; }
		public int CartId { get; set; }
		public byte PaymentType { get; set; }


		#region جدول ارتباطات
		[ForeignKey(nameof(CartId))]
		public TBL_ProductCart TBLProductCart { get; set; }

		[ForeignKey(nameof(DisCountId))]
		public TBL_DisCount TBLDisCount { get; set; }
		#endregion
	}
}
