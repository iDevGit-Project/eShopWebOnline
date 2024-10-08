﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductPropertyGroupViewModels.ProductPropertyGroupVMServer
{
	public class CreatePropertyGroupViewModel
	{
		[Display(Name = "نام گروه بندی")]
		[Required(ErrorMessage = "{0} الزامیست.")]
		[MinLength(3, ErrorMessage = "{0} نمیتواند کمتر از {1} باشد")]
		[MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} باید")]
		public string GroupTitle { get; set; }
	}
}
