using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_SubCategory : TBLMASTER_BaseEntity
	{
		// منوی اصلی یا زیرمنویی که قرار است برای آن منو تعریف شود
		public int ParentId { get; set; }
		public int SubId { get; set; }

		#region ارتباطات این جدول با جدول اصلی دسته بندی ها
		[ForeignKey(nameof(ParentId))]
		[InverseProperty("PSubCategory")]
		public TBL_Category Parent { get; set; }

		[ForeignKey(nameof(SubId))]
		[InverseProperty("SSubCategory")]
		public TBL_Category  Sub { get; set; }
		#endregion
	}
}
