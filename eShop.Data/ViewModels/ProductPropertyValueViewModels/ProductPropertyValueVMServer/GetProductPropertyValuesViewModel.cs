using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductPropertyValueViewModels.ProductPropertyValueVMServer
{
	public class GetProductPropertyValuesViewModel
	{
		public int PropertyValueId { get; set; }
		public string Value { get; set; }
		public string PropertyNameTitle { get; set; }
	}
}
