using eShop.Core.ExtentionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBL_Brand : TBLMASTER_BaseEntity
	{
		[Required(ErrorMessage = ValidationMessages.IsRequired)]
		public string? ImgName { get; set; }

		[Required(ErrorMessage = ValidationMessages.IsRequired)]
		public string FaTitle { get; set; }

		[Required(ErrorMessage = ValidationMessages.IsRequired)]
		public string EnTitle { get; set; }

		[Required(ErrorMessage = ValidationMessages.IsRequired)]
		public string? DesCripton { get; set; }
	}
}
