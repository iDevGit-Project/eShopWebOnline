using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductPropertyValueViewModels.ProductPropertyValueVMServer
{
	public class AddOrUpdateProductPropertyValueForProductViewModel
	{
		public List<int> nameid { get; set; }
		public List<string> value { get; set; }
		public int ProductId { get; set; }
		public int categoryid { get; set; }
		public List<AddProductPropertyNameForProductViewModel> propertyNameForProduct { get; set; }
	}
}
