using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductPropertyNameViewModels.ProductPropertyNameVMServer
{
	public class GetProductPropertyNamesViewModel
	{
		public int PropertyNameId { get; set; }
		public string PropertyNameTitle { get; set; }
		public string GroupTitle { get; set; }
		public byte type { get; set; }
	}
}
