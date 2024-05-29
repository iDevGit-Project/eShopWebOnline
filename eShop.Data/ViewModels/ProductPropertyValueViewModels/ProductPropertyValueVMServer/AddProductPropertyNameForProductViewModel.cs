using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductPropertyValueViewModels.ProductPropertyValueVMServer
{
	public class AddProductPropertyNameForProductViewModel
	{
		public int NameId { get; set; }
		public string PropertyNameTitle { get; set; }
		public byte type { get; set; }
		public List<GetProductPropertyValuesForPropertyNameViewModel> Values { get; set; }
	}
}
