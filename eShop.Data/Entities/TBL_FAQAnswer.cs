using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_FAQAnswer : TBLMASTER_BaseEntity
	{
		public int UserId { get; set; }
		public int QuestionId { get; set; }
		public string AnswerText { get; set; }
		public bool IsConfirm { get; set; }

		#region جدول ارتباطات
		//[ForeignKey(nameof(UserId))]
		//public User User { get; set; }

		//[ForeignKey(nameof(QuestionId))]
		//public Question Question { get; set; }
		#endregion
	}
}
