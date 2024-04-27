using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Entities
{
	public class TBLMASTER_BaseEntity
	{
		[Key]
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime? LastModified { get; set; }
		public DateTime? RemoveDate { get; set; }
		public bool IsRemove { get; set; }
	}
}
