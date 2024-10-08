﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer
{
	public class AddOrUpdateParentCategoryViewModel
	{
		public int SubId { get; set; }

		[Display(Name = "زیردسته ها")]
		[Required(ErrorMessage = "انتخاب {0} الزامیست.")]
		public List<int>? ParentId { get; set; }
	}
}
