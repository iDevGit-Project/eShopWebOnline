using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_Brand : TBLMASTER_BaseEntity
	{
		public string? ImgName { get; set; }
		public string FaTitle { get; set; }
		public string EnTitle { get; set; }
		public string? DesCripton { get; set; }
	}
}
