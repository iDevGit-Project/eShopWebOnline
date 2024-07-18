using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductPropertyValueViewModels.ProductPropertyValueVMServer
{
	public class CreateProductPropertyValueViewModel
	{
		[Display(Name = "مقدار ویژه گی")]
		[Required(ErrorMessage = "{0} الزامیست.")]
		public string Value { get; set; }
		public int PropertyNameId { get; set; }
	}
}
