using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductPropertyName : TBLMASTER_BaseEntity
	{
		public string Title { get; set; }
		public int GroupId { get; set; }
		public byte type { get; set; }

		#region جدول ارتباطات
		[ForeignKey(nameof(GroupId))]
		public TBL_ProductPropertyGroup PropertyGroup { get; set; }
		public List<TBL_ProductPropertyValue> PropertyValues { get; set; }
		public List<TBL_ProductPropertyNameCategory> PropertyNameCategories { get; set; }
		#endregion
	}
}
