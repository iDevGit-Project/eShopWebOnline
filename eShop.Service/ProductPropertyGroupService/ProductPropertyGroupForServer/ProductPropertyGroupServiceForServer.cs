using eShop.Common.Operations;
using eShop.Data.Context;
using eShop.Data.Entities;
using eShop.Data.ViewModels.ProductPropertyGroupViewModels.ProductPropertyGroupVMServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Service.ProductPropertyGroupService.ProductPropertyGroupForServer
{
	public class ProductPropertyGroupServiceForServer : IProductPropertyGroupServiceForServer
	{
		#region متد های پیکربندی اطلاعات نام گروه بندی خصوصیات یا ویژه گی های کالاها یا محصولات در سمت سرور یا مدیرسایت

		private readonly ApplicationDbContext _context;
		public ProductPropertyGroupServiceForServer(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region متد دریافت اطلاعات مربوط به نام گروه بندی خصوصیات یا ویژه گی های کالا یا محصولات

		public List<GetPropertyGroupsViewModel> GetProductPropertyGroups()
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

		public OperationResult CreateProductPropertyGroups(CreatePropertyGroupViewModel propertyGroups)
		{
			bool Exist = ExistPropertyGroup(0, propertyGroups.GroupTitle);
			if (Exist)
			{
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};
			}

			TBL_ProductPropertyGroup propertyGroup = new TBL_ProductPropertyGroup()
			{
				CreationDate = DateTime.Now,
				Title = propertyGroups.GroupTitle,
			};

			_context.TBL_ProductPropertyGroups.Add(propertyGroup);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create,
			};
		}
		#endregion

		#region متد موجود بودن اطلاعات مربوط به نام گروه بندی خصوصیات یا ویژه گی های کالا یا محصولات
		public bool ExistPropertyGroup(int GroupId, string GroupTitle)
		{
			return _context.TBL_ProductPropertyGroups.Any(x => x.Title == GroupTitle.ToLower().Trim() && x.Id != GroupId);
		}
		#endregion

		#region ID متد جستجوی اطلاعات مربوط به نام گروه بندی خصوصیات یا ویژه گی های کالا بر اساس 
		public TBL_ProductPropertyGroup FindGroupById(int GroupId)
		{
			return _context.TBL_ProductPropertyGroups
				.Where(x => x.Id.Equals(GroupId))
				.AsNoTracking()
				.SingleOrDefault();
		}
		#endregion

		#region جهت بروزرسانی ID متد جستجوی اطلاعات مربوط به نام گروه بندی خصوصیات یا ویژه گی های کالا بر اساس 

		public UpdateProductPropertyGroupViewModel FindProductPropertyGroupByIdForUpdate(int titleId)
		{
			return _context.TBL_ProductPropertyGroups
				.Where(p => p.Id == titleId)
				.Select(p => new UpdateProductPropertyGroupViewModel
				{
					TitleId = p.Id,
					Title = p.Title,
				})
				.SingleOrDefault();
		}
		#endregion

		#region آن ID متد حذف اطلاعات مربوط به نام گروه بندی خصوصیات یا ویژه گی های کالا بر اساس نام گروه بندی و
		//public RemoveProductPropertyGroupViewModel FindProductPropertyGroupByIdForRemove(int titleId)
		//{
		//	return _context.TBL_ProductPropertyGroups
		//		.Where(p => p.Id == titleId)
		//		.Select(p => new RemoveProductPropertyGroupViewModel
		//		{
		//			TitleId = p.Id,
		//			Title = p.Title,
		//		})
		//		.SingleOrDefault();
		//}
		#endregion

		#region متد عملیاتی حذف اطلاعات مربوط به نام گروه بندی خصوصیات یا ویژه گی های کالا

		//public OperationResult RemoveProductPropertyGroup(RemoveProductPropertyGroupViewModel RemoveTitle)
		//{
		//	var FindPPG = FindGroupById(RemoveTitle.TitleId);

		//	if (FindPPG == null)
		//		return new OperationResult
		//		{
		//			Code = OperationCode.Failed,
		//			IsSuccess = false,
		//			Message = OperationResultMessage.NotFound,
		//		};

		//	FindPPG.RemoveDate = DateTime.Now;
		//	FindPPG.IsRemove = true;

		//	_context.TBL_ProductPropertyGroups.Update(FindPPG);
		//	_context.SaveChanges();

		//	return new OperationResult
		//	{
		//		Code = OperationCode.Success,
		//		IsSuccess = true,
		//		Message = OperationResultMessage.Remove
		//	};
		//}
		#endregion

		#region متد عملیاتی بروزرسانی اطلاعات مربوط به نام گروه بندی خصوصیات یا ویژه گی های کالا یا محصولات

		public OperationResult UpdateProductPropertyGroup(UpdateProductPropertyGroupViewModel UpdateTitle)
		{
			var FindPPG = FindGroupById(UpdateTitle.TitleId);

			if (FindPPG == null)
				return new OperationResult
				{
					Code = OperationCode.Failed,
					IsSuccess = false,
					Message = OperationResultMessage.NotFound,
				};

			bool existPPG = ExistPPG(UpdateTitle.Title, UpdateTitle.TitleId);
			if (existPPG)
				return new OperationResult
				{
					Code = OperationCode.duplicate,
					IsSuccess = false,
					Message = OperationResultMessage.Duplicate,
				};

			FindPPG.Title = UpdateTitle.Title;
			FindPPG.LastModified = DateTime.Now;

			_context.TBL_ProductPropertyGroups.Update(FindPPG);
			_context.SaveChanges();

			return new OperationResult
			{
				Code = OperationCode.Success,
				IsSuccess = true,
				Message = OperationResultMessage.Create
			};
		}
		#endregion

		#region متد موجود بودن گروه بندی خصوصیات یا ویژه گی های کالا در سمت سرور و عملیات بر روی آن
		public bool ExistPPG(string titleName, int titleId)
		{
			return _context.TBL_ProductPropertyGroups.Any(x => x.Title == titleName.Trim().ToLower() && x.Id != titleId
			);
		}
		#endregion



	}
}
