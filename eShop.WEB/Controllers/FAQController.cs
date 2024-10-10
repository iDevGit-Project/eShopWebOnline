using eShop.Service.Comment_FAQ.CommentFAQForClient;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace eShop.WEB.Controllers
{
    public class FAQController : BaseController
    {
        #region متد های سرویس پرسش و پاسخ کاربران سمت سرور
        private readonly ICommentFAQServiceForClient _fAQService;
        private readonly IToastNotification _toastNotification;

        public FAQController(ICommentFAQServiceForClient fAQService, IToastNotification toastNotification)
        {
            _fAQService = fAQService;
            _toastNotification = toastNotification;
        }
		#endregion
		[HttpPost]
		[Route("Question/{productId}/{productEn}")]
		public IActionResult FAQQuestion(int productId, string productEn)
		{
			TempData[ProductEn] = productEn;
			return View(_fAQService.GetQuestionsForClient(productId));
		}
	}
}
