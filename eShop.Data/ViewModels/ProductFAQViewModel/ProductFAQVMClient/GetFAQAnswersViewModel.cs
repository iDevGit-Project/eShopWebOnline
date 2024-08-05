using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductFAQViewModel.ProductFAQVMClient
{
	public class GetFAQAnswersViewModel
	{
		public int? AnswerId { get; set; }
		public string? UserName { get; set; }
		public string? AnswerText { get; set; }
		public string? CreationDate { get; set; }
	}
}
