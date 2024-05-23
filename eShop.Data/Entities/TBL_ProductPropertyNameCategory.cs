using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductPropertyNameCategory : TBLMASTER_BaseEntity
	{
		public int PropertyNameId { get; set; }
		public int CategoryId { get; set; }

		#region جدول ارتباطات
		[ForeignKey(nameof(PropertyNameId))]
		public TBL_ProductPropertyName PropertyName { get; set; }

		[ForeignKey(nameof(CategoryId))]
		public TBL_Category Category { get; set; }
		#endregion
	}
}
