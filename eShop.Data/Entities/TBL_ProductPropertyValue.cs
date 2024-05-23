using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductPropertyValue : TBLMASTER_BaseEntity
	{
		public string Value { get; set; }
		public int PropertyNameId { get; set; }

		#region جدول ارتباطات
		[ForeignKey(nameof(PropertyNameId))]
		public TBL_ProductPropertyName PropertyName { get; set; }

		public List<TBL_ProductProperty> PropertyProducts { get; set; }
		#endregion
	}
}
