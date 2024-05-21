using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductGallery : TBLMASTER_BaseEntity
	{
		public int ProductId { get; set; }
		public string ImgName { get; set; }

		#region Product جدول ارتباط با 
		[ForeignKey(nameof(ProductId))]
		public TBL_Product TBLProduct { get; set; }
		#endregion
	}
}
