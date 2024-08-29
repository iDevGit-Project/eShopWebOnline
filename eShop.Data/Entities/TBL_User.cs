using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_User : TBLMASTER_BaseEntity
	{
		public string Email { get; set; }
		public string? Phone { get; set; }
		public string? ImgName { get; set; }
		public string? Name { get; set; }
		public string Password { get; set; }
		public string? CartNumber { get; set; }
		public string? NationalCode { get; set; }
		public byte type { get; set; }
		public string? ActiveCode { get; set; }

		public List<TBL_ProductQuestion> TBLProductQuestions { get; set; }
		public List<TBL_ProductCart> TBLProductCarts { get; set; }
		public List<TBL_FAQAnswer> TBLFAQAnswers { get; set; }
	}
}
