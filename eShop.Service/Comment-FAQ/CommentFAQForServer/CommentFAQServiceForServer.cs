using eShop.Data.Context;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.Comment_FAQ.CommentFAQForServer
{
	public class CommentFAQServiceForServer : ICommentFAQServiceForServer
	{
		private readonly ApplicationDbContext _context;
		public CommentFAQServiceForServer(ApplicationDbContext context)
		{
			_context = context;
		}
	}
}
