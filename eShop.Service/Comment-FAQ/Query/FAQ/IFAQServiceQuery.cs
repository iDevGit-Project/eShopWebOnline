using eShop.Data.ViewModels.ProductFAQViewModel.ProductFAQVMClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.Comment_FAQ.Query.FAQ
{
	public interface IFAQServiceQuery
	{
		List<GetFAQQuestionsViewModel> GetQuestionsForClient(int ProductId);
	}
}
