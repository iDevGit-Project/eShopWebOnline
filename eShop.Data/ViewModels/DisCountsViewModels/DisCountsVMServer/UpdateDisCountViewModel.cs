using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer
{
	public class UpdateDisCountViewModel
	{
		public int DiscountId { get; set; }
		public string Code { get; set; }
		public int? UserCount { get; set; }
		public bool IsActive { get; set; }
		public DateTime? StartDisCount { get; set; }
		public DateTime? EndDisCount { get; set; }
		public bool IsPercentage { get; set; }
		public bool FreeShipping { get; set; }
		public bool FirstOrder { get; set; }
		public int Value { get; set; }
	}
}
