using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_ProductQuestion : TBLMASTER_BaseEntity
	{
		public int UserId { get; set; }
		public int ProductId { get; set; }
		public string QuestionText { get; set; }
		public bool IsConfirm { get; set; }

		#region Relations
		//[ForeignKey(nameof(UserId))]
		//public User User { get; set; }

		[ForeignKey(nameof(ProductId))]
		public TBL_Product TBLProduct { get; set; }
		//public List<FAQAnswer> FAQAnswers { get; set; }
		#endregion
	}
}
