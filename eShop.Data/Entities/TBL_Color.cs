using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_Color : TBLMASTER_BaseEntity
	{
		public string ColorName { get; set; }
		public string Code { get; set; }
		public bool IsActive { get; set; }
	}
}
