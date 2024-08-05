using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.ViewModels.ProductFAQViewModel.ProductFAQVMClient
{
	public class GetFAQQuestionsViewModel
	{
		public int QuestionId { get; set; }
		public string UserName { get; set; }
		public string QuestionText { get; set; }
		public string CreationDate { get; set; }
		public GetFAQAnswersViewModel? getFAQAnswer { get; set; }
	}
}
