using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.DisCountsViewModels.Query
{
	public class DiscountCalculationViewModel
	{
		public string Code { get; set; }
		public bool IsActive { get; set; }
		public bool IsPercentage { get; set; }
		public bool FreeShipping { get; set; }
		public bool FirstOrder { get; set; }
		public int Value { get; set; }
		public string Message { get; set; }
		public DateTime? StartDisCount { get; set; }
		public DateTime? EndDisCount { get; set; }
		public int SpecialPrice { get; set; }
	}
}
