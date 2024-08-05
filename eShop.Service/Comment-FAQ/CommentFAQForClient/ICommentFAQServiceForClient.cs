using eShop.Data.ViewModels.ProductFAQViewModel.ProductFAQVMClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.Comment_FAQ.CommentFAQForClient
{
	public interface ICommentFAQServiceForClient
	{
		List<GetFAQQuestionsViewModel> GetQuestionsForClient(int ProductId);
	}
}
