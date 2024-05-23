using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductPropertyGroup : TBLMASTER_BaseEntity
	{
		public string Title { get; set; }

		#region جدول ارتباطات
		public List<TBL_ProductPropertyName> PropertyNames { get; set; }
		#endregion
	}
}
