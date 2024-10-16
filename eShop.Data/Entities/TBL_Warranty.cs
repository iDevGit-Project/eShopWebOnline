﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_Warranty : TBLMASTER_BaseEntity
	{
		[Required(ErrorMessage = "وارد کردن {0} الزامیست .")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string WarrantyName { get; set; }

		#region جدول ارتباطات
		public List<TBL_ProductPrice> TBLProductPrice { get; set; }
		#endregion
	}
}
