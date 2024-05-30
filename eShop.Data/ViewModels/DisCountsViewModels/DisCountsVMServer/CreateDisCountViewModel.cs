using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.DisCountsViewModels.DisCountsVMServer
{
	public class CreateDisCountViewModel
	{
		public string Code { get; set; }
		public int? UserCount { get; set; }
		public bool IsActive { get; set; }
		public string? StartDisCount { get; set; }
		public string? EndDisCount { get; set; }
	}
}
