using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductPropertyValueViewModels.ProductPropertyValueVMServer
{
	public class ProductPropertyOldValueForProductViewModel
	{
		public int PropertyValueId { get; set; }
		public DateTime CreationDate { get; set; }
		public int ProductPropertyId { get; set; }
		public int NameId { get; set; }
		public int ValueId { get; set; }
		public string Value { get; set; }
	}
}
