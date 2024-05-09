using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_Slider : TBLMASTER_BaseEntity
	{
		public string ImgName { get; set; }
		public string? Link { get; set; }
		public int Sort { get; set; }
		public bool IsActive { get; set; }
	}
}
