using eShop.Common.Operations;
using eShop.Data.Context;
using eShop.Data.ViewModels.ProductPropertyGroupViewModels.ProductPropertyGroupVMServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductPropertyGroupService.ProductPropertyGroupForServer
{
	public class ProductPropertyGroupForServer : IProductPropertyGroupForServer
	{
		#region متد های پیکربندی اطلاعات نام گروه بندی خصوصیات یا ویژه گی های کالاها یا محصولات در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
		public ProductPropertyGroupForServer(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد دریافت اطلاعات مربوط به نام گروه بندی خصوصیات یا ویژه گی های کالا یا محصولات

		public List<GetPropertyGroupsViewModel> GetPropertyGroups()
		{
			return _context.TBL_ProductPropertyGroups
				.Select(x => new GetPropertyGroupsViewModel
				{
					GroupTitle = x.Title,
					PropertyGroupId = x.Id,
				})
				.AsNoTracking()
				.ToList();
		}
		#endregion

		#region متد عملیاتی ثبت اطلاعات مربوط به نام گروه بندی خصوصیات یا ویژه گی های کالا یا محصولات

		public OperationResult CreatePropertyGroup(CreatePropertyGroupViewModel propertyGroups)
		{
			throw new NotImplementedException();
		}
		#endregion



	}
}
