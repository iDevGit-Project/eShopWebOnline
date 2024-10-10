using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.CategoriesViewModels.Query
{
	public class GetCategoryForMenuViewModel
	{
		public int CategoryId { get; set; }
		public string FaTitle { get; set; }
		public bool IsMain { get; set; }
		public int? ParentId { get; set; }
	}
}
