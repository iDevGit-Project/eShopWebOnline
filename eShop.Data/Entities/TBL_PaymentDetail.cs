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

		//مبلغ تسویه حساب کاربری که خرید کرده است
		public string RefId { get; set; }
		public string UserIp { get; set; }
		public string Athourity { get; set; }
		public int DisCountId { get; set; }
		public int CartId { get; set; }

		//موفق یا عدم موفق آمیز بودن خرید از درگاه بانک
		public byte PaymentType { get; set; }


		#region جدول ارتباطات
		[ForeignKey(nameof(CartId))]
		public TBL_ProductCart TBLProductCarts { get; set; }

		[ForeignKey(nameof(DisCountId))]
		public TBL_DisCount TBLDisCounts { get; set; }
		#endregion
	}
}
