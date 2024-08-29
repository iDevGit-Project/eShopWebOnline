using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductCart : TBLMASTER_BaseEntity
	{
		public string? Province { get; set; }
		public string? City { get; set; }
		public string? FullAddress { get; set; }
		public int UserId { get; set; }
		public int SumOrder { get; set; }

		// مشخص کردن اینکه کاربر در چه مرحله ای از پرداخت قرار دارد
		public byte OrderType { get; set; }

		#region جدول ارتباطات
		[ForeignKey(nameof(UserId))]
		public TBL_User TBLUsers { get; set; }
		public List<TBL_ProductCartDetail> TBLProductCartDetails { get; set; }
		public List<TBL_PaymentDetail> TBLPaymentDetails { get; set; }
		#endregion
	}
}
