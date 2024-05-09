using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.CategoriesViewModels.CategoriesVMServer
{
	public class AddOrUpdateParentCategoryViewModel
	{
		public int SubId { get; set; }
		public List<int>? ParentId { get; set; }
	}
}
