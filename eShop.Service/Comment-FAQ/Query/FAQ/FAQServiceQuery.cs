using eShop.Core.ExtentionMethods;
using eShop.Data.Context;
using eShop.Data.ViewModels.ProductFAQViewModel.ProductFAQVMClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.Comment_FAQ.Query.FAQ
{
	public class FAQServiceQuery : IFAQServiceQuery
	{
		private readonly ApplicationDbContext _context;
		public FAQServiceQuery(ApplicationDbContext context)
		{
			_context = context;
		}
		public List<GetFAQQuestionsViewModel> GetQuestionsForClient(int ProductId)
		{
			var qResult = (from q in _context.TBL_ProductQuestions
						   join u in _context.TBL_Users on q.UserId equals u.Id

						   join a in _context.TBL_FAQAnswers on q.Id equals a.QuestionId
			into aFull
						   from a in aFull.DefaultIfEmpty()

						   join uanswer in _context.TBL_Users on a.UserId equals uanswer.Id into UA
						   from uanswer in UA.DefaultIfEmpty()

						   where (q.ProductId.Equals(ProductId) && q.IsConfirm == true)
						   select new GetFAQQuestionsViewModel
						   {
							   CreationDate = ConvertDate.MiladiToShamsi(q.CreationDate),
							   QuestionId = q.Id,
							   QuestionText = q.QuestionText,
							   UserName = u.Name,
							   getFAQAnswer = new GetFAQAnswersViewModel
							   {
								   AnswerId = a.Id,
								   AnswerText = a.AnswerText,
								   CreationDate = ConvertDate.MiladiToShamsi(a.CreationDate),
								   UserName = uanswer.Name,
							   }

						   })
					.AsNoTracking()
					.ToList();
			return qResult;
		}
	}
}
