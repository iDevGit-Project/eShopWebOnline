using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_DisCount : TBLMASTER_BaseEntity
	{
		public string Code { get; set; }

		// چه تعداد کاربر می تواند از این کد تخفیف استفاده کند
		public int? UserCount { get; set; }
		public bool IsActive { get; set; }

		// تاریخ شروع کد تخفیف که میتواند دارای تاریح هم نباشد
		public DateTime? StartDisCount { get; set; }

		// تاریخ انقضاء از کد تخفیف که میتواند دارای تاریح هم نباشد
		public DateTime? EndDisCount { get; set; }

		#region جدول ارتباطات
		public List<TBL_PaymentDetail> TBLPaymentDetails { get; set; }
		#endregion
	}
}
