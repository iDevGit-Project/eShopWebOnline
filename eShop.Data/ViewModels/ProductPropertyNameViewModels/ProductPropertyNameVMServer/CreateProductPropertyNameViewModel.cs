using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductPropertyNameViewModels.ProductPropertyNameVMServer
{
	public class CreateProductPropertyNameViewModel
	{
		[Display(Name = "نام ویژه گی")]
		[Required(ErrorMessage = "درج {0} الزامیست.")]
		public string PropertyNameTitle { get; set; }

		[Display(Name = "گروه ویژه گی ها")]
		[Required(ErrorMessage = "انتخاب {0} الزامیست.")]
		public int PropertyGroupId { get; set; }
		public List<int> Categories { get; set; }
		public byte type { get; set; }
	}
}
